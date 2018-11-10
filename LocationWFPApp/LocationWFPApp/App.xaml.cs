using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace LocationWFPApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static OleDbConnection Cnx;

        private static bool s_failedToUpdate;
        private static List<string> history;

        public static bool FailedToUpdate { get => s_failedToUpdate; set => s_failedToUpdate = value; }

        public static List<String> History { get => history; set => history = value; }
    }
}
