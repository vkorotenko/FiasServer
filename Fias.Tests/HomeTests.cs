#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 17:24
#endregion

using System;
using Fias.Loader.EfMsSql;
using System.Collections.Generic;
using System.Linq;
using VKorotenko.FiasServer.Bl;
using VKorotenko.FiasServer.Bl.Data;
using Xunit;

namespace Fias.Tests
{
    public class HomeTests
    {
        [Fact]
        public void DublicateTest()
        {
            var connstr = "Data Source=HP;Initial Catalog=FIAS_622;Integrated Security=True";
            var back = new EfMsSql();
            back.Init(connstr);
            var list = new List<HouseNum>();
            for (var i = 0; i < 1000; i++)
            {
                list.Add(new HouseNum{Name = i.ToString()});
            }
            back.HouseNumbers.AddRange(list);
            var houses = back.HouseNumbers.All().ToList();
            Assert.Equal(1000, houses.Count);
            list.Clear();
            for (var i = 0; i < 1000; i++)
            {
                list.Add(new HouseNum { Name = i.ToString() });
            }
            back.HouseNumbers.AddRange(list);
            houses = back.HouseNumbers.All().ToList();
            Assert.Equal(1000, houses.Count);
        }

        [Fact]
        public void CaseTest()
        {
            var connstr = "Data Source=HP;Initial Catalog=FIAS_622;Integrated Security=True";
            var back = new EfMsSql();
            back.Init(connstr);
            var list = new List<HouseNum>();
            var lover = "абвгдежзийклмопрстуф";
            var hg = "АБВГДЕЖЗИЙКЛМОПРСТУФ";
            foreach (var l in lover)
            {
                list.Add(new HouseNum{Name = l.ToString()});
            }
            foreach (var l in hg)
            {
                list.Add(new HouseNum { Name = l.ToString() });
            }

            back.HouseNumbers.AddRange(list);
            var houses = back.HouseNumbers.All().ToList();
        }


        private List<House> _houses;
        private List<string> _buildNumNames;
        private HashSet<string> _houseNumsNames;
        private readonly  EfMsSql _back = new EfMsSql();

        [Fact]
        public void InsertTest()
        {
            var connstr = "Data Source=HP;Initial Catalog=FIAS_622;Integrated Security=True";
            var fullPath = "v:\\FIAS\\data\\fias.zip";
            _back.Init(connstr);
            
            _houses = new List<House>();
            _buildNumNames = new List<string>();
            _houseNumsNames = new HashSet<string>();
            
            var proc = new HouseProcessor(fullPath);
            proc.Complete += HouseComplete;
            proc.ItemParsed += OnHouseParsed;
            proc.RunDictionary(1000).Wait();
        }

        private void OnHouseParsed(object sender, HouseEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(args.Item.HOUSENUM) && !_houseNumsNames.Contains(args.Item.HOUSENUM))
            {
                _houseNumsNames.Add(args.Item.HOUSENUM);
            }
            if (!string.IsNullOrWhiteSpace(args.Item.BUILDNUM) && !_houseNumsNames.Contains(args.Item.BUILDNUM))
            {
                _buildNumNames.Add(args.Item.BUILDNUM);
            }
        }

        private void HouseComplete(object sender, EventArgs args)
        {
            var builds = _buildNumNames.Select(name => new BuildNum { Name = name });
            _back.BuildNumbers.AddRange(builds);

            var houses = _houseNumsNames.Select(name => new HouseNum() { Name = name });
            _back.HouseNumbers.AddRange(houses);

            var buildex = _back.BuildNumbers.All().ToList();
            var houseex = _back.HouseNumbers.All().ToHashSet();
        }
    }
}
