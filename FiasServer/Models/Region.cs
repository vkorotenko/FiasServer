using System;
using Newtonsoft.Json;

namespace FiasServer.Models
{
    /// <summary>
    /// Регион для выбора
    /// </summary>
    public class Region
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Название региона
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Край, область и т.д.
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// Название для ЧПУ
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        [JsonIgnore]
        public Guid RegionId { get; set; }
    }
}