using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace LIMS.Models
{
    public class ConnectionHelper
    {
        public readonly static IConfiguration configuration;
        static ConnectionHelper()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

        }
        public static string OracleString
        {
            get { return configuration.GetConnectionString("OracleConnection"); }
        }
    }
  
    public class DBHelper
    {
        string ConnectionString = ConnectionHelper.OracleString;

        public DataTable ExecuteTable(string cmdText, params OracleParameter[] oraParameters)
        {

            using OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                Console.WriteLine("Connection Success!");
            }
            
            OracleCommand cmd = new OracleCommand(cmdText, conn);
            cmd.Parameters.AddRange(oraParameters);
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            oracleDataAdapter.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }
    }
    public class DBController : Controller
    {
        public ViewResult Index()
        {
            string ConnectionString = ConnectionHelper.OracleString;
            using OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            Console.WriteLine(conn.State);
            return View();
        }

    }
}
