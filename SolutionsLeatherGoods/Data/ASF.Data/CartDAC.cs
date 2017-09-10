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
    public class CartDAC : DataAccessComponent
    {

        public Cart Create(Cart cart) {

            const string sqlStatement = "INSERT INTO dbo.CartItem ([Cookie], [CartDate],[ItemCount],[Rowid],[CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@Cookie, @CartDate, @ItemCount, @Rowid, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))

            {
                db.AddInParameter(cmd, "@Cookie", DbType.String, cart.Cookie);
                db.AddInParameter(cmd, "@CartDate", DbType.DateTime2, cart.CartDate);
                db.AddInParameter(cmd, "@ItemCount", DbType.Int32, cart.ItemCount);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, cart.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, cart.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, cart.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, cart.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, cart.ChangedBy);
                // Obtener el valor de la primary key.
                cart.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }



            return cart;

        }


        public void UpdateById(Cart cart)
        {
            const string sqlStatement = "UPDATE dbo.Cart " +
                "SET [Cookie]=@Cookie, " +
                    "[CartDate]=,@CartDate " +
                    "[ItemCount]=,@ItemCount " +
                    "[Rowid]=,@Rowid " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Cookie", DbType.String, cart.Cookie);
                db.AddInParameter(cmd, "@CartDate", DbType.DateTime2, cart.CartDate);
                db.AddInParameter(cmd, "@ItemCount", DbType.Int32, cart.ItemCount);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, cart.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, cart.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, cart.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, cart.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, cart.ChangedBy);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Cart WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }


        public Cart SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Cookie], [CartDate], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Cart WHERE [Id]=@Id ";

            Cart cart = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) cart = LoadCart(dr);
                }
            }

            return cart;
        }


        public List<Cart> Select()
        {
            const string sqlStatement = "SELECT [Id], [Cookie], [CartDate], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Cart ";

            var result = new List<Cart>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var cart = LoadCart(dr); 
                        result.Add(cart);
                    }
                }
            }

            return result;
        }
        private static Cart LoadCart(IDataReader dr)
        {
            var cart = new Cart
            {
                Id = GetDataValue<int>(dr, "Id"),
                Cookie = GetDataValue<string>(dr, "Cookie"),
                CartDate = GetDataValue<DateTime>(dr, "CartDate"),
                ItemCount = GetDataValue<int>(dr, "ItemCount"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return cart;
        }

    }
}