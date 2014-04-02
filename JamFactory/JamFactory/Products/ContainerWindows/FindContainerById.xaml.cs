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

namespace JamFactory.Products.ContainerWindows
{
    public delegate void GetId(int id);
    /// <summary>
    /// Interaction logic for FindContainerById.xaml
    /// </summary>
    public partial class FindContainerById : Window
    {
        public event GetId TypedId;
        public FindContainerById()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TypedId(  int.Parse( IDTEXTBOX.Text ) );
            }
            catch (Exception)
            {
                TypedId(0);         
            }
            finally
            {
                this.Close();
            }
            
            
        }
    }
}
