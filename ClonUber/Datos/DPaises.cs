using ClonUber.Modelo;
using PhoneNumbers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ClonUber.Datos
{
    public class DPaises
    {
        public static List<RegionInfo> PaisesIso3166()
        {
            var paises = new List<RegionInfo>();
            var listaPaises = CultureInfo.GetCultures(CultureTypes.SpecificCultures).ToList();
            for (int i = 0; i < listaPaises.Count; i++)
            {
                var cultura = listaPaises[i];

                // Id from each country.
                var info = new RegionInfo(cultura.LCID);

                // Prevent repeat countries.
                if (paises.All(x => x.Name != info.Name))
                    paises.Add(info);
            }

            return paises.OrderBy(x => x.EnglishName).ToList();
        }

        // Create list of countries.
        public List<MPaises> MostrarPaises()
        {
            var phonrNumberUtil = PhoneNumberUtil.GetInstance();
            var listaPaises = new List<MPaises>();
            var isoPaises = PaisesIso3166();
            listaPaises.AddRange(isoPaises.Select(x => new MPaises
            {
                CodigoPais = phonrNumberUtil.GetCountryCodeForRegion(x.TwoLetterISORegionName).ToString(),
                Pais = x.EnglishName,
                IconUrl = $"https://hatscripts.github.io/circle-flags/flags/{x.TwoLetterISORegionName.ToLower()}.svg"
            }));
            return listaPaises;
        }

        public MPaises MostrarPaisesXNombre(string pais)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var isoPais = PaisesIso3166();
            var regionInfo = isoPais.FirstOrDefault(x => x.EnglishName == pais);
            var paises = new MPaises();

            return regionInfo!=null
                ? new MPaises
                {
                    CodigoPais = phoneNumberUtil.GetCountryCodeForRegion(regionInfo.TwoLetterISORegionName).ToString(),
                    Pais = regionInfo.EnglishName,
                    IconUrl = $"https://hatscripts.github.io/circle-flags/flags/{regionInfo.TwoLetterISORegionName.ToLower()}.svg"
                } 
                : new MPaises 
                { 
                    Pais = pais
                };

        //if (regionInfo != null)
        //{
        //    paises.CodigoPais = phoneNumberUtil.GetCountryCodeForRegion(regionInfo.TwoLetterISORegionName).ToString();
        //    paises.Pais = regionInfo.EnglishName;
        //    paises.IconUrl = $"https://hatscripts.github.io/circle-flags/flags/{regionInfo.TwoLetterISORegionName.ToLower()}.svg";
        //    return paises;
        //}
        //else
        //{
        //    paises.Pais = pais;
        //    return paises;
        //}
    }


        public List<MPaises> ListShowCountriesByName(string country)
        {
            var phonrNumberUtil = PhoneNumberUtil.GetInstance();
            var listaPaises = new List<MPaises>();
            var isoPaises = PaisesIso3166();
            //var regionInfo = isoPaises.FirstOrDefault(x => x.EnglishName == country);
            var regionInfo = isoPaises.FirstOrDefault(x => x.EnglishName.Contains(country));
            var countries = new MPaises();
            if (regionInfo != null)
            {
                countries.Pais = regionInfo.EnglishName;
                countries.CodigoPais = phonrNumberUtil.GetCountryCodeForRegion(
                    regionInfo.TwoLetterISORegionName).ToString();
                countries.IconUrl = $"https://hatscripts.github.io/circle-flags/flags/{regionInfo.TwoLetterISORegionName.ToLower()}.svg";
                listaPaises.Add(countries);
            }
            
            return listaPaises;
        }
    }
}
