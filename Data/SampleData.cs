using System;
using System.Collections.Generic;
using System.Linq;
using CodeOne.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CodeOne.Data
{
    public class SampleData {
    public static void Initialize(IApplicationBuilder app) { 
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();

      // Look for any teams.
      if (context.Provinces.Any()) {
          return;   // DB has already been seeded
      }

      var provinces = GetProvinces().ToArray();
      context.Provinces.AddRange(provinces);
      context.SaveChanges();

      var cities = GetCities(context).ToArray();
      context.Cities.AddRange(cities);
      context.SaveChanges();
    }
  }

    public static List<Province> GetProvinces() {
        List<Province> provinces = new List<Province>() {
            new Province() {
                ProvinceName="British Columbia",
                ProvinceCode="BC"
            },
            new Province() {
                ProvinceName="Ontario",
                ProvinceCode="ON"
            },
            new Province() {
                ProvinceName="Alberta",
                ProvinceCode="AB"
            }
        };

        return provinces;
    }

    public static List<City> GetCities(ApplicationDbContext context) {
        List<City> cities = new List<City>() {
            new City {
                CityName = "Vancouver",
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                Population = 321213
            },
            new City {
                CityName = "Burnaby",
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                Population = 32121332
            },
            new City {
                CityName = "Richmond",
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,
                Population = 321213213
            },
            new City {
                CityName = "Edmonton",
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
                Population = 13212123
            },
            new City {
                CityName = "Calgary",
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
                Population = 23414221
            },
            new City {
                CityName = "Banff",
                ProvinceCode = context.Provinces.Find("AB").ProvinceCode,
                Population = 412412
            },
            new City {
                CityName = "Ottawa",
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
                Population = 2341421
            },
            new City {
                CityName = "Toronto",
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
                Population = 412412213
            },
            new City {
                CityName = "Waterloo",
                ProvinceCode = context.Provinces.Find("ON").ProvinceCode,
                Population = 412412123
            },
        };

        return cities;
    }
}

}