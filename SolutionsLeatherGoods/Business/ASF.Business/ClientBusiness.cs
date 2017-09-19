using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class ClientBusiness
    {

        public Client Add(Client client)
        {
            var ClientDAC = new ClientDAC();
            return ClientDAC.Create(client);
        }

        public void Remove(int id)
        {
            var ClientDAC = new ClientDAC();
            ClientDAC.DeleteById(id);
        }

        public List<Client> All()
        {
            var ClientDAC = new ClientDAC();
            var result = ClientDAC.Select();
            return result;
        }
        public Client Find(int id)
        {
            var ClientDAC = new ClientDAC();
            var result = ClientDAC.SelectById(id);
            return result;
        }
        public void Edit(Client client)
        {
            var ClientDAC = new ClientDAC();
            ClientDAC.UpdateById(client);
        }
    }
}
