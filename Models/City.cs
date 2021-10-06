using System.ComponentModel.DataAnnotations.Schema;

namespace CodeOne.Models
{
    public class City
    {
    public int CityId { get; set; }
    public string CityName { get; set; }

    public string ProvinceCode { get; set; }
    public Province Province { get; set; }
    [ForeignKey("ProvinceCode")]
    public int Population { get; set; }
    }
}