using LocationWFPApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace LocationWFPApp.Outils
{
    internal static class Outils
    {
        public static void Connection(string Path) // PATH==> XML FILE
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load(Path);
            string cnx_path = Doc.DocumentElement.SelectSingleNode("connection").InnerText;
            App.Cnx = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + cnx_path + "; Persist Security Info = False");
            if (App.Cnx.State != System.Data.ConnectionState.Open)
                App.Cnx.Open();
        }

        public static async Task<DataTable> GetDataSet(string query) => await Task.Run(() => {
            DataTable dataTable = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, App.Cnx);
            adapter.Fill(dataTable);
            return dataTable;
        });

        public static bool Execute_Query(string query)
        {
            try
            {
                OleDbCommand command = new OleDbCommand(query, App.Cnx);
                OleDbDataReader reader = command.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        // Date verification

        public static string _IsDate(object date)
        {
            if (String.IsNullOrEmpty(date.ToString()))
            {
                return null;
            }
            else
            {
                DateTime dt = new DateTime();
                if (DateTime.TryParse(date.ToString(), out dt))
                {
                    return dt.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        public static string _Date_Print(string date)
        {
            if (String.IsNullOrEmpty(date))
            {
                return "Null";
            }
            else
            {
                return "'" + date + "'";
            }
        }

        // Int verification
        public static decimal _IsNumber(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return 0;
            }
            else
            {
                return decimal.Parse(value);
            }
        }
    }
}
