using Common.Interfaces;
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
        List<IReceivedGoods> possibleReceivedGoods;

        public SuppliersUserControl()
        {
            oc = new OptimizationController();
            InitializeComponent();
            updateGUI();
        }

        private void addSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            if (supplierNameTextBox.Text != "" && receivedDatePicker.SelectedDate != null)
            {
                double amount;
                decimal price;

                if (double.TryParse(rosehipKgTextBox.Text, out amount) && decimal.TryParse(hybenPriceTextBox.Text, out price))
                {
                    oc.AddPossibleReceivedGoods(supplierNameTextBox.Text, "Hyben", amount, price, receivedDatePicker.SelectedDate.Value);
                }
                if (double.TryParse(appleKgTextBox.Text, out amount) && decimal.TryParse(æblePriceTextBox.Text, out price))
                {
                    oc.AddPossibleReceivedGoods(supplierNameTextBox.Text, "Æble", amount, price, receivedDatePicker.SelectedDate.Value);
                }
                if (double.TryParse(boysenberryKgTextBox.Text, out amount) && decimal.TryParse(boysenbærPriceTextBox.Text, out price))
                {
                    oc.AddPossibleReceivedGoods(supplierNameTextBox.Text, "Boysenbær", amount, price, receivedDatePicker.SelectedDate.Value);
                }
                if (double.TryParse(strawberryKgTextBox.Text, out amount) && decimal.TryParse(jordbærPriceTextBox.Text, out price))
                {
                    oc.AddPossibleReceivedGoods(supplierNameTextBox.Text, "Jordbær", amount, price, receivedDatePicker.SelectedDate.Value);
                }
                if (double.TryParse(blackcurrantKgTextBox.Text, out amount) && decimal.TryParse(solbærPriceTextBox.Text, out price))
                {
                    oc.AddPossibleReceivedGoods(supplierNameTextBox.Text, "Solbær", amount, price, receivedDatePicker.SelectedDate.Value);
                }

                updateGUI();
            }

            
        }

        private void updateGUI()
        {
            possibleReceivedGoods = oc.LoadPossibleReceviedGoods();
            possibleGoodsDataGrid.ItemsSource = possibleReceivedGoods;
            possibleGoodsDataGrid.Items.Refresh();
            supplierNameTextBox.Text = "";
            receivedDatePicker.SelectedDate = null;
            rosehipKgTextBox.Text = "";
            hybenPriceTextBox.Text = "";
            appleKgTextBox.Text = "";
            æblePriceTextBox.Text = "";
            boysenberryKgTextBox.Text = "";
            boysenbærPriceTextBox.Text = "";
            strawberryKgTextBox.Text = "";
            jordbærPriceTextBox.Text = "";
            blackcurrantKgTextBox.Text = "";
            solbærPriceTextBox.Text = "";
        }

        private void deleteRowButton_Click(object sender, RoutedEventArgs e)
        {
            oc.DeletePossibleReceivedGoods((IReceivedGoods)possibleGoodsDataGrid.SelectedItem);
            updateGUI();
        }

        private void deleteAllButton_Click(object sender, RoutedEventArgs e)
        {
            oc.DeleteAllPossibleReceivedGoods();
            updateGUI();
        }
    }
}
