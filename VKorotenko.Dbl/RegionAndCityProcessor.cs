#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.06.2020 8:57

#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Kvn.Translit;
using Kvn.Translit.Countries;
using VKorotenko.Poco;

namespace VKorotenko.Dbl
{
    public class RegionAndCityProcessor
    {
        private readonly string _connectionStr;
        private readonly RuEngParser _trans;
        public List<Region> Regions { get; private set; }
        public List<City> Cityes { get; private set; }
        private readonly List<Parent> _parent;
        public RegionAndCityProcessor(string connection)
        {
            _connectionStr = connection;
            Regions = new List<Region>();
            Cityes = new List<City>();
            _parent = new List<Parent>();
            _trans = new RuEngParser(Schema.A);
            FillRegion();
            FillCity();
        }

        private void FillCity()
        {
            const string sql = @"SELECT  [AOGUID]   
                               ,[REGIONCODE]      
                               ,[OFFNAME]
                               ,[POSTALCODE]      
	                           ,[SHORTNAME]
                               ,[PARENTGUID]
                               ,[AREACODE]
	                           ,[CITYCODE]
                      FROM [FIAS2].[dbo].[_ADDROBJ]
                      WHERE  [SHORTNAME] = N'г' AND actstatus = 1   ORDER BY REGIONCODE";

            using (var connection = new SqlConnection(_connectionStr))
            {
                var command = new SqlCommand(sql, connection);
                command.Connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadSingleCity((IDataRecord)reader);
                }
                reader.Close();
                command.ExecuteNonQuery();
            }
        }
        private void ReadSingleCity(IDataRecord record)
        {
            var aoguid = record.GetGuid(record.GetOrdinal("AOGUID"));
            var code = record.GetString(record.GetOrdinal("REGIONCODE"));
            var offname = record.GetString(record.GetOrdinal("OFFNAME"));
            var prefix = record.GetString(record.GetOrdinal("SHORTNAME"));
            var citycode = record.GetString(record.GetOrdinal("CITYCODE"));
            var areacode = record.GetString(record.GetOrdinal("AREACODE"));
            var id = int.Parse($"{code}{areacode}{citycode}");

            var nregion = new City
            {
                Id = id,
                Name = offname,
                Slug = _trans.Transliterate(offname).GetWebSafe(),
                Prefix = $"{prefix}.",
                Guid = aoguid,
                RegionId = int.Parse(code)
            };
            var pos = record.GetOrdinal("PARENTGUID");
            if (!record.IsDBNull(pos))
            {
                var parent = record.GetGuid(pos);
                nregion.Parent = GetParent(parent);
            }
            Cityes.Add(nregion);
        }

        private string GetParent(Guid parent)
        {
            var par = Regions.FirstOrDefault(x => x.Guid == parent);
            if (par != null)
                return $"{par.Name} {par.Prefix} ";
            else
            {
                var p0 = TryGetFromCache(parent);
                var stout = $"{p0.OffName} {p0.ShortName}.";

                if (!p0.ParentGuid.HasValue) return stout;
                var p1 = TryGetFromCache(p0.ParentGuid.Value);
                stout = $"{p1.OffName} {p1.ShortName}., {stout}";

                if (!p1.ParentGuid.HasValue) return stout;
                var p2 = TryGetFromCache(p1.ParentGuid.Value);
                stout = $"{p2.OffName} {p2.ShortName}., {stout}";

                return stout;
            }
        }

        private Parent TryGetFromCache(Guid parent)
        {
            Parent p0;
            var pp = _parent.FirstOrDefault(x => x.AoGuid == parent);
            if (pp != null)
            {
                p0 = pp;
            }
            else
            {
                p0 = GetParentSql(parent);
                _parent.Add(p0);
            }

            return p0;
        }

        private void FillRegion()
        {
            const string query = @"SELECT TOP (1000) [AOGUID]   
                              ,[REGIONCODE]      
                              ,[OFFNAME]
                              ,[SHORTNAME]      
                              FROM [FIAS2].[dbo].[_ADDROBJ]
                               WHERE AOLEVEL = 1 AND ACTSTATUS = 1 ORDER BY REGIONCODE";

            using var connection = new SqlConnection(_connectionStr);
            var command = new SqlCommand(query, connection);
            command.Connection.Open();

            var reader = command.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                ReadSingleRegion((IDataRecord)reader);
            }
            // Call Close when done reading.
            reader.Close();
            command.ExecuteNonQuery();
        }
        private void ReadSingleRegion(IDataRecord record)
        {


            var aoguid = record.GetGuid(0);
            var code = record.GetString(1);
            var id = int.Parse(code);
            var offname = record.GetString(2);
            var prefix = record.GetString(3);

            var nRegion = new Region
            {
                Id = id,
                Name = offname,
                Slug = _trans.Transliterate(offname).GetWebSafe(),
                Prefix = $"{prefix}.",
                Guid = aoguid
            };
            Regions.Add(nRegion);
        }


        private Parent GetParentSql(Guid parent)
        {
            const string sql = @"SELECT 
                        aoguid, 
                        offname, 
                        parentguid, 
                        shortname 
	                   FROM [_ADDROBJ]

                       WHERE actstatus=1 and  aoguid = @Parent";


            using var connection = new SqlConnection(_connectionStr);
            var command = new SqlCommand(sql, connection);
            var param = new SqlParameter("@Parent", SqlDbType.UniqueIdentifier)
            {
                Value = parent
            };
            command.Parameters.Add(param);
            command.Connection.Open();

            var reader = command.ExecuteReader();
            reader.Read();
            var record = (IDataRecord)reader;

            var aoGuid = record.GetGuid(record.GetOrdinal("AOGUID"));
            var offName = record.GetString(record.GetOrdinal("OFFNAME"));
            var shortName = record.GetString(record.GetOrdinal("SHORTNAME"));
            var ordinal = record.GetOrdinal("PARENTGUID");
            Guid? pGuid = null;
            if (!record.IsDBNull(ordinal))
            {
                pGuid = record.GetGuid(ordinal);
            }

            var p = new Parent
            {
                AoGuid = aoGuid,
                OffName = offName,
                ParentGuid = pGuid,
                ShortName = shortName
            };
            reader.Close();
            return p;
        }
    }
}