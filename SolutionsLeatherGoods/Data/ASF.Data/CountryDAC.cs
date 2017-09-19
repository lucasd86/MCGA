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
    public class CountryDAC : DataAccessComponent
    {
        
        public Country Create(Country country)
        {
            country.ChangedBy = 0;
            country.CreatedBy = 0;
            country.CreatedOn = DateTime.Now;
            country.ChangedOn = DateTime.Now;

            const string sqlStatement = "INSERT INTO dbo.Country ([Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@Name, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, country.Name);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, country.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, country.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, country.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, country.ChangedBy);
                // Obtener el valor de la primary key.
                country.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return country;
        }

        public void UpdateById(Country country)
        {
            country.ChangedBy = 0;
            country.ChangedOn = DateTime.Now;
            const string sqlStatement = "UPDATE dbo.Country " +
                "SET [Name]=@Name, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, country.Name);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, country.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, country.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, country.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, country.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, country.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Country WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
        

        public Country SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Country WHERE [Id]=@Id ";

            Country country = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) country = LoadCountry(dr);
                }
            }

            return country;
        }

        	
        public List<Country> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Country ";

            var result = new List<Country>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var country = LoadCountry(dr); // Mapper
                        result.Add(country);
                    }
                }
            }

            return result;
        }
	
        private static Country LoadCountry(IDataReader dr)
        {
            var country = new Country
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return country;
        }
    }
}

