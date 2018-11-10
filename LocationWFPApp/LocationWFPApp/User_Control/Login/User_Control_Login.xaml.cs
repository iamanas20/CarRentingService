using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocationWFPApp.User_Control
{
    /// <summary>
    /// Interaction logic for User_Control_Login.xaml
    /// </summary>
    public partial class User_Control_Login : UserControl
    {
        public User_Control_Login()
        {
            InitializeComponent();
        }

        private async void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt_user = await Outils.Outils.GetDataSet("SELECT * FROM [User] WHERE Login = \'" + Username_Txt.Text.Replace("'", "''") + "\' AND Password = \'" + Password_Pbox.Password.Replace("'", "''") + "\'");

            if (dt_user.Rows.Count != 0)
            {
                ((MainWindow)Application.Current.MainWindow).Main_Windows.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("User does not exist!");
                // Display Error Message!
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Username_Txt.Focus();
        }
    }
}
