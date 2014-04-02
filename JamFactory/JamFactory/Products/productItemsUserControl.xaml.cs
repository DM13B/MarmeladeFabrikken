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
using Controller.Products;

namespace JamFactory.Products
{
    /// <summary>
    /// Interaction logic for productItemsUserControl.xaml
    /// </summary>
    public partial class productItemsUserControl : UserControl
    {
        private ProductController pc;
        public productItemsUserControl()
        {
            InitializeComponent();
            pc = new ProductController();
            LoadProducts();
        }

        public void LoadProducts()
        {
            dGrid.ItemsSource = pc.GetAllProducts();
        }
    }
}
