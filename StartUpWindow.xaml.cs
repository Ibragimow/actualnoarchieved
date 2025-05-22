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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : Window
    {
        public StartUpWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAllMaterials_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();  
            window.Show();  
        }

        private void BtnAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            AddMaterial window = new AddMaterial(); 
            window.Show();  
        }
    }
}
