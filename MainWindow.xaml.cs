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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var context = new ObrazPlusIbragimov();
            {
                var materialCards = context.Materials
                    .AsEnumerable()
                    .Select(x => new MaterialCard
                    {
                        Type = x.Type,
                        Title = x.Title,
                        MinQuantity = x.MinQuantity.ToString(),
                        StockQuantity = x.StockQuantity.ToString(),
                        PriceAndUnit = x.Price.ToString() + " / " + x.Unit,
                        PackageQuantity = x.PackageQuantity.ToString(),
                        NeededQuantity = ((double)x.StockQuantity / (double)x.PackageQuantity).ToString("F2")
                    })
                    .ToList();  
                MaterialList.ItemsSource = materialCards;    
            }
        }
           
        public class MaterialCard
        {
            public string Type { get; set; }
            public string Title { get; set; }   

            public string MinQuantity { get; set; }
            public string StockQuantity { get; set; }
            public string PriceAndUnit { get; set; }
            public string PackageQuantity { get; set; }
            public string NeededQuantity { get; set; }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void BtnAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            AddMaterial window = new AddMaterial(); 
            window.Show();
            this.Close();
        }
    }
}
