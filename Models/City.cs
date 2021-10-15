using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CodeOne.Models
{
    public class City
    {
        public int CityId {get; set;}
        public string CityName {get; set;}
        public int Population {get; set;}
		[Display(Name="Province Code")]
        public string ProvinceCode {get; set;}
        [ForeignKey("ProvinceCode")]
		[JsonIgnore]
        public Province Province {get; set;}
    }
}