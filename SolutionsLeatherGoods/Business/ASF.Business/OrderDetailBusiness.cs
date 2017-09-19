using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class OrderDetailBusiness
    {

        public OrderDetail Add(OrderDetail orderdetail)
        {
            var orderdetailDAC = new OrderDetailDAC();
            return orderdetailDAC.Create(orderdetail);
        }

        public void Remove(int id)
        {
            var orderdetailDAC = new OrderDetailDAC();
            orderdetailDAC.DeleteById(id);
        }

        public List<OrderDetail> All()
        {
            var orderdetailDAC = new OrderDetailDAC();
            var result = orderdetailDAC.Select();
            return result;
        }
        public OrderDetail Find(int id)
        {
            var orderdetailDAC = new OrderDetailDAC();
            var result = orderdetailDAC.SelectById(id);
            return result;
        }
        public void Edit(OrderDetail orderdetail)
        {
            var orderdetailDAC = new OrderDetailDAC();
            orderdetailDAC.UpdateById(orderdetail);
        }
    }
}
