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

using Interface;

//temp
using DataAccess;
namespace MarmeladeFabrikken
{
    public partial class MainWindow : Window
    {
        internal DataAccessBinary DT = new DataAccessBinary();

        internal List<IProduct> IPlist = new List<IProduct>();
        internal List<IBatch> IBlist = new List<IBatch>();

        public MainWindow()
        {
            //Sacrifices a baby to the elder gods
            InitializeComponent();

            //Populates the product dropdown menu with the saved products
            InitProductMenu();

            //PopulateListviews();
        }

        /// <summary>
        /// Loads the product list and loads it into the product dropdown menu
        /// </summary>
        private void InitProductMenu()
        {            
            List<IProduct> IPlist = DT.LoadShopItems();

            ProductMenu.ItemsSource = IPlist;

            ProductMenu.SelectedIndex = 0;
        }

        /// <summary>
        /// opens the "Add Product" window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProduct AddProductWindow = new AddProduct();
            AddProductWindow.Show();
        }
        
        private void PopulateListviews() 
        {
            int productNumber = ProductMenu.SelectedIndex;

            IBlist = IPlist[0].Batches;

            BatchListView.ItemsSource = IBlist;


        }

        private void ProductMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int productNumber = ProductMenu.SelectedIndex;

            IPlist = DT.LoadShopItems();
            IBlist = IPlist[0].Batches;

            BatchListView.ItemsSource = IBlist;
        }

    }
}