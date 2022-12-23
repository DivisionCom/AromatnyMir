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
using Ароматный_мир.AppData;

namespace Ароматный_мир.Pages
{
    /// <summary>
    /// Interaction logic for PageProducts.xaml
    /// </summary>
    public partial class PageProducts : Page
    {
        List<Product> _product = new List<Product>();
        private int _currentData;
        private int _maxData;
        public PageProducts()
        {
            InitializeComponent();

            _product = ConnectOdb.conObj.Product.ToList();

            if(Flag.role != 3)
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnEdit.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
            }

            ListProducts.ItemsSource = ConnectOdb.conObj.Product.ToList();

            List<Product> discount = new List<Product>();
            discount.Add(new Product() { ProductName = "Все диапазоны" });
            discount.Add(new Product() { ProductName = "0-9,99%" });
            discount.Add(new Product() { ProductName = "10-14,99%" });
            discount.Add(new Product() { ProductName = "15% и более" });
            cmbFiltering.ItemsSource = discount;

            List<Product> cost = new List<Product>();
            cost.Add(new Product() { ProductName = "Сортировка" });
            cost.Add(new Product() { ProductName = "Стоимость(по возрастанию)" });
            cost.Add(new Product() { ProductName = "Стоимость(по убыванию)" });
            cmbSorting.ItemsSource = cost;


            UpdateProducts();

            cmbFiltering.SelectedIndex = 0;
        }

        public void UpdateProducts()
        {
            if (cmbFiltering.SelectedItem != null)
            {
                if ((cmbFiltering.SelectedItem as Product).ProductName == "0-9,99%")
                {
                    _product = _product.Where(p => p.ProductDiscountAmount < 3).ToList();
                }
                else if ((cmbFiltering.SelectedItem as Product).ProductName == "10-14,99%")
                {
                    _product = _product.Where(p => p.ProductDiscountAmount >= 3 && p.ProductDiscountAmount < 15).ToList();
                }
                else if ((cmbFiltering.SelectedItem as Product).ProductName == "15% и более")
                {
                    _product = _product.Where(p => p.ProductDiscountAmount >= 15).ToList();
                }
                else if ((cmbFiltering.SelectedItem as Product).ProductName == "Все диапазоны")
                {
                    _product = ConnectOdb.conObj.Product.ToList();
                }
            }

            if (cmbSorting.SelectedItem != null)
            {
                if ((cmbSorting.SelectedItem as Product).ProductName == "Стоимость(по возрастанию)")
                {
                    _product = _product.OrderBy(p => p.ProductCost).ToList();
                }
                else if ((cmbSorting.SelectedItem as Product).ProductName == "Стоимость(по убыванию)")
                {
                    _product = _product.OrderByDescending(p => p.ProductCost).ToList();
                }
                else if ((cmbSorting.SelectedItem as Product).ProductName == "Сортировка")
                {
                    _product = ConnectOdb.conObj.Product.ToList();
                }
            }


            if (tboxSearch.Text != "")
            {
                _product = _product.Where(p => p.ProductName.ToLower().Contains(tboxSearch.Text.ToLower())).ToList();
            }
            else
            {
                _product = _product.ToList();
            }

            ListProducts.ItemsSource = _product;


            _maxData = ConnectOdb.conObj.Product.ToList().Count();
            _currentData = _product.ToList().Count();
            tblockCurrentData.Text = _currentData + " из " + _maxData;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageProductsAdd());
        }

        private void cmbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _product = ConnectOdb.conObj.Product.ToList();
            UpdateProducts();
        }

        private void cmbFiltering_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _product = ConnectOdb.conObj.Product.ToList();
            UpdateProducts();
        }

        private void tboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _product = ConnectOdb.conObj.Product.ToList();
            UpdateProducts();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранный отель?",
                "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var productObj = ListProducts.SelectedItems.Cast<Product>().ToList();
                ConnectOdb.conObj.Product.RemoveRange(productObj);
                ConnectOdb.conObj.SaveChanges();

                UpdateProducts();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AddToOrder_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageOrder());
        }
    }
}
