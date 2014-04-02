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

using Common.Interfaces;
using Controller.QualityControl;
using JamFactory.QualityControl;
using JamFactory;

namespace JamFactory.QualityControl
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : UserControl
    {

        QualityController QController = new QualityController();

        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void ProductionAcceptButton_Click(object sender, RoutedEventArgs e)
        {            
            QController.saveNewProductProduction(ProductionNameTextbox.Text);                              
        }
    }
}
