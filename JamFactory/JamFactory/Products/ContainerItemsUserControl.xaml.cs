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
using Common.Interfaces;
using JamFactory.Products.ContainerWindows;

namespace JamFactory.Products
{
    /// <summary>
    /// Interaction logic for productItemsUserControl.xaml
    /// </summary>
    public partial class ContainerItemsUserControl : UserControl
    {
        ContainerController CC;
        public ContainerItemsUserControl()
        {
            InitializeComponent();
            CC = new ContainerController();
            DGrid.ItemsSource = CC.GetAllContainers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FindContainerById windows = new FindContainerById();
            windows.TypedId += typedId;
            windows.Show();
        }

        private void typedId(int id)
        {
            IContainer ic = CC.GetContainerById(id);
            if (ic != null)
            {
                List<IContainer> lic = new List<IContainer>
                {
                    ic
                };
                setDataSource(lic);
            }
            else
            {
                DGrid.ItemsSource = null;
            }
                  
        }

        private void setDataSource(List<IContainer> o){
            DGrid.ItemsSource = null;
            DGrid.ItemsSource = o;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            setDataSource(CC.GetAllContainers());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
