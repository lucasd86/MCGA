using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Entities;

namespace ASF.Data
{
    public class ClientDAC : DataAccessComponent

    {
        public Client Create(Client client)
        {
           
            {
               
            }

            return client;
        }

       
        public void UpdateById(Client client)
        {
            
            
           
        }

       
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Category WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        
        public Client SelectById(int id)
        {
         

            Client client = null;
           
            {
             
            }

            return client;
        }

      
        public List<Client> Select()
        {
           
            var result = new List<Client>();
            return result;
        }

        
    }
}
