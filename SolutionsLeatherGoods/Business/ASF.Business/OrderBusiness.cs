using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class OrderBusiness
    {

        public Order Add(Order order)
        {
            var orderDAC = new OrderDAC();
            return orderDAC.Create(order);
        }

        public void Remove(int id)
        {
            var orderDAC = new OrderDAC();
            orderDAC.DeleteById(id);
        }

        public List<Order> All()
        {
            var orderDAC = new OrderDAC();
            var result = orderDAC.Select();
            return result;
        }
        public Order Find(int id)
        {
            var orderDAC = new OrderDAC();
            var result = orderDAC.SelectById(id);
            return result;
        }
        public void Edit(Order order)
        {
            var orderDAC = new OrderDAC();
            orderDAC.UpdateById(order);
        }
    }
}
