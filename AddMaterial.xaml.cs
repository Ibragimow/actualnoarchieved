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
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddMaterial.xaml
    /// </summary>
    public partial class AddMaterial : Window
    {
        public AddMaterial()
        {
            InitializeComponent();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

private void BtnAddMaterial_Click(object sender, RoutedEventArgs e)
{
    string materialType = CbMaterialType.Text;
    string priceText = TbPrice.Text;
    string materialTitle = TbMaterialTitle.Text;
    string unit = CbUnit.Text;
    string packageQuantityText = TbPackageQuantity.Text;
    string stockQuantityText = TbStockQuantity.Text;
    string minQuantityText = TbMinQuantity.Text;

    // Проверка на пустые значения
    if (materialTitle.Length < 5)
    {
        TbMaterialTitle.ToolTip = "Длина поля не может быть меньше 5 символов";
        TbMaterialTitle.Background = Brushes.Red;
        return;
    }

    // Безопасное преобразование чисел
    if (!double.TryParse(priceText.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double price) ||
        !double.TryParse(packageQuantityText.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double packageQuantity) ||
        !double.TryParse(stockQuantityText.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double stockQuantity) ||
        !double.TryParse(minQuantityText.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double minQuantity))
    {
        MessageBox.Show("Пожалуйста, введите корректные числовые значения.");
        return;
    }

    // Очистка стилей
    TbMaterialTitle.ToolTip = "";
    TbMaterialTitle.Background = Brushes.Transparent;

    // Создание объекта
    var newMaterial = new Material
    {
        Type = materialType,
        Price = price,
        Title = materialTitle,
        Unit = unit,
        PackageQuantity = packageQuantity,
        StockQuantity = stockQuantity,
        MinQuantity = minQuantity
    };

    // Сохранение в БД
    using (var db = new ObrazPlusIbragimov())
    {
        db.Materials.Add(newMaterial);
        db.SaveChanges();
    }

    MessageBox.Show("Материал успешно добавлен.");
    this.Close();
}

        private void TbPackageQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[1234567890,]$");
        }

        private void TbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[1234567890,]$");
        }

        private void TbStockQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[1234567890,]$");
        }

        private void TbMinQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[1234567890,]$");
        }

        private void TbMaterialTitle_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[А-Яа-яЁё 1234567890,.]$");
        }
    }
}
