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


        static bool firstTake = true;
        private static bool s_failedToUpdate;
        internal static bool FirstTake { get => firstTake; set => firstTake = value; }
        public static bool FailedToUpdate { get => s_failedToUpdate; set => s_failedToUpdate = value; }
    }
}
