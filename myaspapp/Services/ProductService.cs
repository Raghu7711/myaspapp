using myaspapp.models;
using System.Data.SqlClient;
namespace myaspapp.Services
{
    public class ProductService
    {
        private static string db_source = "sqlserver7711.database.windows.net";
        private static string db_user = "adm";
        private static string db_password = "Pranika@2022";
        private static string db_database = "mysqldb";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);

        }

        public List<product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<product> _product_lst = new List<product>();
            string statement = "SELECT prod_id, prod_name, price from products";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    product prod = new product()
                    {
                        prod_id = reader.GetInt32(0),
                        prod_name = reader.GetString(1),
                        price = reader.GetInt32(2)
                    };

                    _product_lst.Add(prod);

                }
            }
            conn.Close();
            return _product_lst;
        }
    }
}  
