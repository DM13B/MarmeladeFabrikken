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
    /// Interaction logic for Calculate.xaml
    /// </summary>
    public partial class CalculateUserControl : UserControl
    {
        public CalculateUserControl()
        {
            InitializeComponent();
            calcListBox.ItemsSource = new string[] { @"Billigste produktion per produceret mængde",
                                                      "Produktion med største profit per kilo råvare",
                                                      "Produktion med største profit per glas",
                                                      "Produktion med største mulige produktion"};
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            calcResultTextBox.Text = "Hulubulu lotte lotte hvor er du?";
        }
    }
}
