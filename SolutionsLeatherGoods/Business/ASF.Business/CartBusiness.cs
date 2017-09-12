using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CartBusiness
    {

        public Cart Add(Cart cart)
        {
            var CartDAC = new CartDAC();
            return CartDAC.Create(cart);
        }

        public void Remove(int id)
        {
            var CartDAC = new CartDAC();
            CartDAC.DeleteById(id);
        }

        public List<Cart> All()
        {
            var CartDAC = new CartDAC();
            var result = CartDAC.Select();
            return result;
        }
        public Cart Find(int id)
        {
            var CartDAC = new CartDAC();
            var result = CartDAC.SelectById(id);
            return result;
        }
        public void Edit(Cart cart)
        {
            var CartDAC = new CartDAC();
            CartDAC.UpdateById(cart);
        }
    }
}
