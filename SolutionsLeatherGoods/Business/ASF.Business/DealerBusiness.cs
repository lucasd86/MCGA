using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class DealerBusiness
    {

        public Dealer Add(Dealer dealer)
        {
            var dealerDAC = new DealerDAC();
            return dealerDAC.Create(dealer);
        }

        public void Remove(int id)
        {
            var dealerDAC = new DealerDAC();
            dealerDAC.DeleteById(id);
        }

        public List<Dealer> All()
        {
            var dealerDAC = new DealerDAC();
            var result = dealerDAC.Select();
            return result;
        }
        public Dealer Find(int id)
        {
            var dealerDAC = new DealerDAC();
            var result = dealerDAC.SelectById(id);
            return result;
        }
        public void Edit(Dealer dealer)
        {
            var dealerDAC = new DealerDAC();
            dealerDAC.UpdateById(dealer);
        }
    }
}
