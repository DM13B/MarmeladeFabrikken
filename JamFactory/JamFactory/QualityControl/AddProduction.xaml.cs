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

namespace JamFactory.QualityControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AddProduction : UserControl
    {
        public AddProduction()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            //Fuck.. Fordi tabcontrollen med fanerne "Control" og "Create" ligger i QualityControl så giver det her et mindre problem
            //skal have lagt en tom tabcontrol ind i vores userControlQualityControl (der hvor vi nu loader QualityControl ind)
            //og istedet loade en instans af QualityControl og AddQualityControl ind i den tomme tabcontrol ved start 
            //og derved kunne sige this.Content = new QualityControl(); uden at hele designet bliver loadet ind på ny igen i et faneblad
            this.Content = new QualityControl();
        }
    }
}
