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

using DataAccess;
using Interface;
using Model;

namespace MarmeladeFabrikken
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {      
        public AddProduct()
        {
            InitializeComponent();
        }

        private void ButtonSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            //Hook op inputs

            /*
            DataAccessBinary dt = new DataAccessBinary();

            List<IQualityControl> IQlist = new List<IQualityControl>();
            List<IProduct> IPlist = new List<IProduct>();

            QualityControl Qtest = new QualityControl("testKontrol", "Test for ekstra vagina", "Lugter af fisk");
            
            IQlist.Add(Qtest);


            Product dummy = new Product("testProdukt1");                        
            dummy.QualityControls = IQlist;

            IPlist.Add(dummy);

            dt.SaveShopItems(IPlist);
             */


        }
    }
}
