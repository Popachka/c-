using MySql.Data.MySqlClient;

using Npgsql;
using System.Data.Common;

abstract class Bd
{

    public Bd(string server, string database, int port, string userId, string password)
    {
        this.server = server;
        this.database = database;
        this.userId = userId;
        this.password = password;
        this.port = port;
        if (port == 3306)
        {
            this.connectionString = $"Server={server};Database={database};User Id={userId};Password={password}";
        }
        if(port == 5432){
            this.connectionString = $"Server={server};Port={port};Database={database};UserId={userId};Password = {password};";
        }
    }
   
    public string connectionString = "Server={server};Database={database}; port= 3306;User Id={userId};Password={password}";

    public string server { get; set; }
    public string database { get; set; }
    public string userId { get; set; }
    public string password { get; set; }

    public int port { get; set; }



    public abstract bool IsConnect();
    public abstract void Close();

}

class mySql : Bd
{

    public mySql(string server, string database,int port, string userId, string password) : base(server, database, port, userId, password) { }
    
    public MySqlConnection Connection;
    private bool IsConnected = false;
    private MySqlCommand command;
    public override bool IsConnect()
    {

        if (Connection == null)
        {
            if (String.IsNullOrEmpty(database))
            {
                return false;
            }
            Connection = new MySqlConnection(connectionString);
            Console.WriteLine("Connection Open MySql");
            try
            {
                Connection.Open();
                IsConnected = true;
                
            }
            catch
            {
                Console.WriteLine("Подключение к MySql не открыто");
                IsConnected = false;
            }
        }
        return true;
    }
    public override void Close()
    {
        Console.WriteLine("Connection Close MySql");
        Connection.Close();
        IsConnected = false;
    }
    public void Request(string req)
    {
        string sqlExpression;
        if (IsConnected)
        {
            Console.WriteLine("делается запрос "  + req);
            sqlExpression = req;
            command = new MySqlCommand(sqlExpression, Connection);
            int number = command.ExecuteNonQuery();
            Console.WriteLine("добавлено " + number);
            return;
            
        }
        else
        {
            Console.WriteLine("Request невозможен так как подключение не открыто");
            return;
        }
    }
}
class PostgreSQL : Bd
{
    
    public PostgreSQL(string server, string database, int port, string userId, string password) : base(server, database, port, userId, password) { }
    public NpgsqlConnection Connection;

    private bool IsConnected = false;
    public override bool IsConnect()
    {
        if (Connection == null)
        {
            if (String.IsNullOrEmpty(database))
            {
               
                return false;
            }
            Connection = new NpgsqlConnection(connectionString);
            try
            {
                Connection.Open();
                Console.WriteLine("Connection Open PostgreSQL");
                IsConnected = true;
            }
            catch
            {
                Console.WriteLine("Подключение к PostgresSQL не открыто");
                IsConnected = false;
            }
        }
        return true;
    }


    public override void Close()
    {
      
        Connection.Close();
        Console.WriteLine("Connection Close PostgreSQL");
    }
}