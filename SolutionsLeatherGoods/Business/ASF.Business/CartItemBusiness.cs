using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CartItemBusiness
    
    { 

    public CartItem Add(CartItem cart)
    {
        var CartDAC = new CartItemDAC();
        return CartDAC.Create(cart);
    }

    public void Remove(int id)
    {
        var CartDAC = new CartItemDAC();
        CartDAC.DeleteById(id);
    }

    public List<CartItem> All()
    {
        var CartDAC = new CartItemDAC();
        var result = CartDAC.Select();
        return result;
    }
    public CartItem Find(int id)
    {
        var CartDAC = new CartItemDAC();
        var result = CartDAC.SelectById(id);
        return result;
    }
    public void Edit(CartItem cart)
    {
        var CartDAC = new CartItemDAC();
        CartDAC.UpdateById(cart);
    }
}
}
