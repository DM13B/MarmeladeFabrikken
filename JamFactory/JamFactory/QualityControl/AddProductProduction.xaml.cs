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
using JamFactory.QualityControl.Control_Types;

namespace JamFactory.QualityControl
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : UserControl
    {

        QualityController QController = new QualityController();
        static List<IProductionQualityCheck> QualityCheckList = new List<IProductionQualityCheck>();

        static bool eResultBool;

        ControlTypeBool Bool = new ControlTypeBool();
        ControlTypeOneInteger oneInt = new ControlTypeOneInteger();
        ControlTypeTwoInteger twoInt = new ControlTypeTwoInteger();


        public AddProductWindow()
        {
            InitializeComponent();
            InitMenus();                                   
        }

        /// <summary>
        /// Initializes the Result Type Menu
        /// </summary>
        private void InitMenus() 
        {
            //Populates the 
            ResultTypeCombo.ItemsSource = "123";
            ResultTypeCombo.SelectedIndex = 0;

            // Populates the Product Menu
            List<IProductionProduct> AllProducts = QController.loadAllProductionItems();
            foreach (IProductionProduct product in AllProducts)
            {
                ProductionProductComboMenu.Items.Add(product.ProductName);
            }

            //Populates the Listview
            controlListView.ItemsSource = QualityCheckList;
        }

        /// <summary>
        /// Shows the ResultType User control, depending on selected index in the Result Dropdown
        /// </summary>
        /// <param name="SelectedType"></param>
        private void DetermineControlResultType(int SelectedType) 
        {
            switch (SelectedType)
            {
                case 0 :
                    
                    ResultPanel.Children.Clear();
                    ResultPanel.Children.Add(Bool);
                    ResultPanel.Visibility = Visibility.Visible;
                    break;

                case 1:
                    ResultPanel.Children.Clear();
                    ResultPanel.Children.Add(oneInt);
                    ResultPanel.Visibility = Visibility.Visible;
                    break;

                case 2: 
                    ResultPanel.Children.Clear();
                    ResultPanel.Children.Add(twoInt);
                    ResultPanel.Visibility = Visibility.Visible;
                    break;
                    
                default:

                    break;
            }
        }

        /// <summary>
        /// Saves the Quality control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductionAcceptButton_Click(object sender, RoutedEventArgs e)
        {            
            QController.saveNewProductProduction(ProductionNameTextbox.Text);                              
        }

        /// <summary>
        /// Called when user selects a result type in the dropdown menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductionTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DetermineControlResultType(ResultTypeCombo.SelectedIndex);
        }


        private void AddQualityCheck_Click(object sender, RoutedEventArgs e)
        {
            //Refactoreres 
            switch (ResultTypeCombo.SelectedIndex)
            {
                    // Index 0 : Boolean result
                case 0:
                    if(Bool.radioTrue.IsChecked == true)
                    {
                        eResultBool = true;
                    }
                    else
                    {
                        eResultBool = false;
                    }

                    QualityCheckList = QController.addQualityCheckBool(ProductionNameTextbox.Text, controlDescriptionTextbox.Text, ResultTypeCombo.SelectedIndex, eResultBool);
                    controlListView.ItemsSource = QualityCheckList;
                    controlListView.Items.Refresh();
                
                break;
                    //Index 1 : Single Result
                case 1:
                    break;
                    //Index 2 : Double Result
                case 2:
                    //Two Results
                    QualityCheckList = QController.addQualityCheckDoubleResult(ProductionNameTextbox.Text, controlDescriptionTextbox.Text, ResultTypeCombo.SelectedIndex, twoInt.ResultOneText.Text, twoInt.ResultTwoText.Text);
                    controlListView.ItemsSource = QualityCheckList;
                    controlListView.Items.Refresh();
                    break;                
            }
            
            //Lav 3 methods i controlleren der hver saver hver sin type af kontrol (Boolean resultat, 1 integer resultat og 2 integer resultat)

            



        }
    }
}
