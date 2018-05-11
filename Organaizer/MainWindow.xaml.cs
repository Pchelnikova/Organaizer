using System;
using System.Collections.Generic;
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
using MahApps.Metro.Controls;

namespace Organaizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        //глобальная змінна для ІД
        public static class Global 
            {
                public static int userID { get; set; }
            }
         
        //Старт. Авторизація
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login_Window window2 = new Login_Window(); 
            window2.Show();
            this.Close();
        }
    }
}
 