﻿using System;
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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class OptimizationUserControl : UserControl
    {
        public OptimizationUserControl()
        {
            InitializeComponent();
            suppliersUserControl.Content = new SuppliersUserControl();
            calculateUserControl.Content = new CalculateUserControl();
            stockUserControl.Content = new StockUserControl();
        }
    }
}
