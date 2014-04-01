using Controller.Optimization;
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

namespace JamFactory.Optimization
{
    /// <summary>
    /// Interaction logic for Suppliers.xaml
    /// </summary>
    public partial class SuppliersUserControl : UserControl
    {
        OptimizationController oc;
        List<Tuple<string, string, double, decimal>> suppliers;

        public SuppliersUserControl()
        {
            oc = new OptimizationController();
            suppliers = new List<Tuple<string, string, double, decimal>>();
            InitializeComponent();
            updateGUI();
        }

        private void addSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            double result1;
            decimal result2;

            if (double.TryParse(hybenKgTextBox.Text, out result1) && decimal.TryParse(hybenPriceTextBox.Text, out result2))
            {
                Tuple<string, string, double, decimal> hybenTuple = new Tuple<string, string, double, decimal>
                    (supplierNameTextBox.Text, "Hyben", double.Parse(hybenKgTextBox.Text), decimal.Parse(hybenPriceTextBox.Text));
                suppliers.Add(hybenTuple);
                oc.AddSupplier(suppliers);
            }

            updateGUI();
        }

        private void updateGUI()
        {
            supplierDataGrid.ItemsSource = suppliers;
            supplierDataGrid.Items.Refresh();
            hybenKgTextBox.Text = "";
            hybenPriceTextBox.Text = "";
        }
    }
}
