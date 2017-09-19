using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Data;
using ASF.Entities;

namespace ASF.Business
{
  public   class CountryBusiness

        {
          
            public Country Add(Country country)
            {
                var countryDAC = new CountryDAC();
                return countryDAC.Create(country);
            }
        
            public void Remove(int id)
            {
            var countryDAC = new CountryDAC();
            countryDAC.DeleteById(id);
            }
        
            public List<Country> All()
            {
                var countryDAC = new CountryDAC();
                var result = countryDAC.Select();
                return result;
            }
            public Country Find(int id)
            {
                var countryDAC = new CountryDAC();
                var result = countryDAC.SelectById(id);
                return result;
            }
            public void Edit(Country country)
            {

                var countryDAC = new CountryDAC();
            country.ChangedOn = DateTime.Now;
            countryDAC.UpdateById(country);
            }
        }
    }
