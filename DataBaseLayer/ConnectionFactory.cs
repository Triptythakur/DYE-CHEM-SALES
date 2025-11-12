using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MySql.Data.MySqlClient;

namespace DataBaseLayer
{
    public class ConnectionFactory
    {
        

        public static Database CreateDataBase()
        {
            try
            {
               

                var fileMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = Path.Combine(Directory.GetCurrentDirectory(), "App.config")
                };

                var configuration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                var settings = configuration.ConnectionStrings.ConnectionStrings["Local"];

                if (settings == null)
                {
                    
                    throw new Exception("Connection string 'Local' not found.");
                }

                var db = new GenericDatabase(settings.ConnectionString, MySqlClientFactory.Instance);
               
                return db;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
