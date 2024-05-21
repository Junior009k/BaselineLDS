using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Logging.Console;

namespace blogBlazor.Components.DB
{
    public class DBConfiguration
    {
        private string connetionString = @"Data Source=SERVIDOR\SERVIDOR;Initial Catalog=Blog;User ID=sa;Password=Demo123$";
        private SqlConnection cnn;
        private SqlCommand cmd;
        private SqlDataReader datareader;
        private int i;
        public DBConfiguration()
        {
            cnn = new SqlConnection(connetionString);
            Console.WriteLine("Connectionconfigured");
            return;
        }

        public void DBOpen()
        {
            cnn.Open();
            Console.WriteLine("Connection Open  !");
            return;
        }

        public void DBClose()
        {
            cnn.Close();
            Console.WriteLine("Connection Close  !");
            
            return;
        }

        public List<String> Select(string consulta,int columnas)
        {
            List<String> list = new List<String>();
            Console.WriteLine(consulta);
            cmd = new SqlCommand(consulta, cnn);
            datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {   
                i= 0;
                while(i<columnas)
                {
                    
                    if(i==0)
                    {
                        
                        list.Add(datareader.GetInt32(i).ToString());
                        Console.WriteLine("agregando {0}", datareader.GetInt32(i));
                    }
                    else
                    {
                        list.Add(datareader.GetString(i));
                        Console.WriteLine("agregando {0}", datareader.GetString(i));
                    }
                    ++i;
                }
            }
            return list;
        }

        public void Insert(string consulta)
        {
            Console.WriteLine(consulta);
            cmd = new SqlCommand(consulta, cnn);
            cmd.ExecuteNonQuery();
            return;
        }

        public void Update(string consulta)
        {
            Console.WriteLine(consulta);
            cmd = new SqlCommand(consulta, cnn);
            cmd.ExecuteNonQuery();
            return;
        }

        public void Delete(string consulta)
        {
            Console.WriteLine(consulta);
            cmd = new SqlCommand(consulta, cnn);
            cmd.ExecuteNonQuery();
            return;
        }
        public void ConfiguracionInicial()
        {
            return;
        }
    }
}
