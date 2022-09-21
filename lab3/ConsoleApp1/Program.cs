using MySql.Data.MySqlClient;
using System.Text;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var Sql = new mySql("127.0.0.1","lab3",3306,"root","HW3a94kx");
            var Pst = new PostgreSQL("127.0.0.1", "lab3", 5432, "postgres", "HW3a94kx");
            Sql.IsConnect();
            Sql.Request("insert into users (name,age) values('Tom',18);");
            
        }
    }
}