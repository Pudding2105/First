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
using ООО_Ткани.Models;

namespace ООО_Ткани.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        Product Product;

        /// <summary>
        /// Конструктор ProductUserControl
        /// </summary>
        /// <param name="product">Продукт</param>
        public ProductUserControl(Product product)
        {
            InitializeComponent();
            Product = product;

            LoadLabels();
            LoadImage();
        }

        /// <summary>
        /// Функция для загрузки Label
        /// </summary>
        private void LoadLabels()
        {
            NameProductLabel.Content = $"Наименование: {Product.ProductName}";
            DescriptionProductLabel.Content = $"Описание: {Product.ProductDescription}";
            ManufracturerProductLabel.Content = $"Производитель: {Product.ProductManufacturer.ManufracturerName}";
            CostProductLabel.Content = $"Цена: {Product.ProductCost}";

            QuantityInStockLabel.Content = $"На складе: {Product.ProductQuantityInStock}";
        }

        /// <summary>
        /// Функция для загрузки изображения
        /// </summary>
        private void LoadImage()
        {
            if (Product.ProductPhoto != null && Product.ProductPhoto.Length > 0)
            {
                Uri resUri = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "Images", Product.ProductPhoto), UriKind.Absolute);
                ProductImage.Source = new BitmapImage(resUri);
            }
            else
            {
                ProductImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/picture.png"));
            }
        }
    }
}
