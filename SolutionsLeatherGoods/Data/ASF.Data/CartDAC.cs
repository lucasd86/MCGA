using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Data
{
    public class CartDAC : DataAccessComponent
    {

        public Cart Create(Cart cart) {

            return cart;

        }


        public void UpdateById(Cart cart) {


        }


        public void DeleteById(int id) {


        }


        public Cart SelectById(int id) {

            Cart cart = new Cart();

            return cart;
        }


        public List<Cart> Select() { 


            List<Cart> listaCart = new List<Cart>();

            return listaCart;


        }

    }
}
