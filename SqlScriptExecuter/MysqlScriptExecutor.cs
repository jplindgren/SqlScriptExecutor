using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace SqlScriptExecuter {    
    public class MysqlScriptExecutor  : ISqlScriptExecutor{
        public string ConnectionString { get; set; }
        public string[] ScriptsFiles { get; set; }

        public void ExecuteScripts(){
            if (string.IsNullOrEmpty(ConnectionString))
                throw new ArgumentNullException("Connection string shouldn´t be null.");
            
            if (ScriptsFiles == null)
                throw new ArgumentNullException("You must add a script to execute.");

            Assembly thisAssembly = Assembly.GetCallingAssembly();

            MySqlConnection connMySql = null;
            try {
                connMySql = new MySqlConnection(ConnectionString);
                foreach (string file in ScriptsFiles) {
                    string result = string.Empty;
                    using (Stream stream = thisAssembly.GetManifestResourceStream(file)) {
                        using (StreamReader reader = new StreamReader(stream)) {
                            result = reader.ReadToEnd();
                        }
                    }                
                    
                    MySqlScript script = new MySqlScript(connMySql, result);
                    script.Delimiter = "$$";
                    script.Execute();                
                }

            } catch (MySqlException ex) {
                throw new Exception("Problems with the database sorry...", ex);
            } catch (Exception ex) {
                throw;
            } finally {
                connMySql.Close();
            }
            
            //sql server
            //FileInfo file = new FileInfo("C:\\myscript.sql");
            //string script = file.OpenText().ReadToEnd();
            //SqlConnection conn = new SqlConnection(sqlConnectionString);
            //Server server = new Server(new ServerConnection(conn));
            //server.ConnectionContext.ExecuteNonQuery(script);    
        }

        public static TextReader GetInputFile(string filename) {
            Assembly thisAssembly = Assembly.GetCallingAssembly();
            var resources = thisAssembly.GetManifestResourceNames();
            string path = "Tests.SqlScriptExecuter.ScriptsFiles";
            string fullName = path + "." + filename;
            var teste = thisAssembly.GetManifestResourceStream(fullName);
            return new StreamReader(teste);
        } 
    } //class
}
