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

using JamFactory;
using Controller.QualityControl;
using Common.Interfaces;
using JamFactory.QualityControl;


namespace JamFactory.QualityControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class QualityControl : UserControl
    {
        QualityController qController = new QualityController();
        List<IProductionProduct> productList = new List<IProductionProduct>();


        public QualityControl()
        {
            InitializeComponent();

            //tabControl_Create.Content = new AddProductWindow();

            productList = loadAllProductionItems();
             foreach (IProductionProduct product in productList)
             {
                 productionDropdownMenu.Items.Add(product);
             }
             
        }
        
        private List<IProductionProduct> loadAllProductionItems()
        {
            return qController.loadAllProductionItems();
        }

        private void NewProductButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new AddProduction();
        }

        private void NewBatchButton_Click(object sender, RoutedEventArgs e)
        {
            //Lav ny batch i valgt produktion (productionDropdownMenu)
        }
    }
}
