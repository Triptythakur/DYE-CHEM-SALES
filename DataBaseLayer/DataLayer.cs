using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DataBaseLayer
{
    public class DataLayer
    {
        public static void Add(Messagess message)
        {
            Database db = ConnectionFactory.CreateDataBase();
            string query1 = $"INSERT INTO  Message(Name, PhoneNumber,Subject,Message,Email ) VALUES (@Name, @PhoneNumber,@Subject,@Message,@Email)";
            DbCommand cmd1 = db.GetSqlStringCommand(query1);


            db.AddInParameter(cmd1, "Name", DbType.String, message.Name);
            db.AddInParameter(cmd1, "PhoneNumber", DbType.String, message.PhoneNumber);
            
            db.AddInParameter(cmd1, "Subject", DbType.String, message.Subject);
            db.AddInParameter(cmd1, "Message", DbType.String, message.Message);
            db.AddInParameter(cmd1, "Email", DbType.String, message.Email);
            db.ExecuteNonQuery(cmd1);

        }
    }
}
