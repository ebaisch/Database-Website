using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for Connector
/// </summary>
public static class Connector
{
    static MySqlConnection connection;
    private static String ip = "127.0.0.1";
    //private static String ip = "192.168.100.3";
    private static String port = "3306";
    private static String database = "ecom_website";
    private static String username = "";
    private static String password = "";

    public static bool ConnectionStatus()
    {
        string connStr = "server=" + ip + ";user=" + username + ";database=" + database + ";port=" + port + 
            ";password=" + password + ";";
        connection = new MySqlConnection(connStr);

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            connection.Open();
            Console.Write("Connected!");
            //string sql = "INSERT INTO Country (Name, HeadOfState, Continent) VALUES ('Disneyland','Mickey Mouse', 'North America')";
            //MySqlCommand cmd = new MySqlCommand(sql, connection);
            //cmd.ExecuteNonQuery();

            //string sql = "SELECT Name, HeadOfState FROM Country WHERE Continent='Oceania'";
            //MySqlCommand cmd = new MySqlCommand(sql, connection);
            //MySqlDataReader rdr = cmd.ExecuteReader();

            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        connection.Close();
        return false;
    }

    public static DataTable SelectStatements(String statement)
    {
        DataTable dt = new DataTable();
        string connStr = "server=" + ip + ";user=" + username + ";database=" + database + ";port=" + port +
            ";password=" + password + ";";
        connection = new MySqlConnection(connStr);

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            connection.Open();

            //string sql = "SELECT Name, HeadOfState FROM Country WHERE Continent='Oceania'";
            MySqlCommand cmd = new MySqlCommand(statement, connection);
            //MySqlDataReader rdr = cmd.ExecuteReader();
            dt.Load(cmd.ExecuteReader());
            dt.AsEnumerable().ToArray();
            //rdr.Close();

            connection.Close();
            return dt;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        connection.Close();
        return null;
    }

    public static bool EditStatements(String statement)
    {
        string connStr = "server=" + ip + ";user=" + username + ";database=" + database + ";port=" + port +
            ";password=" + password + ";";
        connection = new MySqlConnection(connStr);


        try
        {
            Console.WriteLine("Connecting to MySQL...");
            connection.Open();

            //string sql = "SELECT Name, HeadOfState FROM Country WHERE Continent='Oceania'";
            MySqlCommand cmd = new MySqlCommand(statement, connection);
            cmd.ExecuteNonQuery();

            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        connection.Close();
        return false;
    }

}