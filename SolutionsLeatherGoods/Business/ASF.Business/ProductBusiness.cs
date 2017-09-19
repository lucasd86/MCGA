using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class ProductBusiness
    {


        public Product Add(Product product)
        {
            var productDAC = new ProductDAC();
            return productDAC.Create(product);
        }

        public void Remove(int id)
        {
            var productDAC = new ProductDAC();
            productDAC.DeleteById(id);
        }

        public List<Product> All()
        {
            var productDAC = new ProductDAC();
            var result = productDAC.Select();
            return result;
        }
        public Product Find(int id)
        {
            var productDAC = new ProductDAC();
            var result = productDAC.SelectById(id);
            return result;
        }
        public void Edit(Product product)
        {
            var productDAC = new ProductDAC();
            productDAC.UpdateById(product);
        }
    }
}
