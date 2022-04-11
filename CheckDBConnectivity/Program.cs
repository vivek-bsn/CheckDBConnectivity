using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDBConnectivity
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create the connection to the resource!  
                // This is the connection, that is established and  
                // will be available throughout this block.  
                using (SqlConnection conn = new SqlConnection())
                {
                    // Create the connectionString  
                    // Trusted_Connection is used to denote the connection uses Windows Authentication  
                    conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                    conn.Open();
                    // Create the command  ;
                    string selectQuery = ConfigurationManager.AppSettings["SelectQuery"];
                    SqlCommand command = new SqlCommand("SELECT * FROM tblSample", conn);
                    /* Get the rows and display on the screen!  
                     * This section of the code has the basic code 
                     * that will display the content from the Database Table 
                     * on the screen using a SqlDataReader. */
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("FirstColumn\tSecond Column\t");
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0} \t | {1} \t",
                            reader[0], reader[1]));
                        }
                    }
                    Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                    /* Above code was used to display the data from the Database table! 
                     * This following section explains the key features to use  
                     * to add the data to the table. This is an example of another 
                     * SQL Command (INSERT INTO), this will teach the usage of parameters and connection.*/
                    Console.WriteLine("INSERT INTO command");

                    // Create the command, to insert the data into the Table!  
                    // this is a simple INSERT INTO command!  
                    string InsertQuery = ConfigurationManager.AppSettings["InsertQuery"];
                    SqlCommand insertCommand = new SqlCommand(InsertQuery, conn);

                    // In the command, there are some parameters denoted by @, you can   
                    // change their value on a condition, in my code, they're hardcoded.  

                    //insertCommand.Parameters.Add(new SqlParameter("0", 10));
                    //insertCommand.Parameters.Add(new SqlParameter("1", "Test Column"));
                    //insertCommand.Parameters.Add(new SqlParameter("2", DateTime.Now));
                    //insertCommand.Parameters.Add(new SqlParameter("3", false));

                    // Execute the command and print the values of the columns affected through  
                    // the command executed.  

                    Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + ex.Message);
                Console.WriteLine("Inner Exception & Stack Trace: \n" + ex.InnerException + "\n" + ex.StackTrace);
                throw ex;
            }
        }
    }
}
