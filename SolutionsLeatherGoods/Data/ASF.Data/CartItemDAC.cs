using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Data
{
    public class CartItemDAC
    {
        public CartItem Create(CartItem cartItem)
        {

            return cartItem;

        }


        public void UpdateById(CartItem cartItem)
        {


        }


        public void DeleteById(int id)
        {


        }


        public CartItem SelectById(int id)
        {

            CartItem cartItem = new CartItem();

            return cartItem;
        }


        public List<CartItem> Select()
        {


            List<CartItem> listaCartItem = new List<CartItem>();

            return listaCartItem;


        }


    }
}
