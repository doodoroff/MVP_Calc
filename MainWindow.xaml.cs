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

namespace MVP_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);
        }

        public event EventHandler one_clicked;
        public event EventHandler two_clicked;
        public event EventHandler three_clicked;
        public event EventHandler four_clicked;
        public event EventHandler five_clicked;
        public event EventHandler six_clicked;
        public event EventHandler seven_clicked;
        public event EventHandler eight_clicked;
        public event EventHandler nine_clicked;
        public event EventHandler zero_clicked;
        public event EventHandler plus_clicked;
        public event EventHandler minus_clicked;
        public event EventHandler mult_clicked;
        public event EventHandler div_clicked;
        public event EventHandler eql_clicked;
        public event EventHandler reset_clicked;
        public event EventHandler decimalSeparator_clicked;
        public event EventHandler sign_clicked;

        private void one_Click(object sender, RoutedEventArgs e)
        {
            one_clicked.Invoke(sender, e);
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            two_clicked.Invoke(sender, e);
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            three_clicked.Invoke(sender, e);
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            four_clicked.Invoke(sender, e);
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            five_clicked.Invoke(sender, e);
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            six_clicked.Invoke(sender, e);
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            seven_clicked.Invoke(sender, e);
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            eight_clicked.Invoke(sender, e);
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            nine_clicked.Invoke(sender, e);
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            zero_clicked.Invoke(sender, e);
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            plus_clicked.Invoke(sender, e);
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            minus_clicked.Invoke(sender, e);
        }

        private void mult_Click(object sender, RoutedEventArgs e)
        {
            mult_clicked.Invoke(sender, e);
        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            div_clicked.Invoke(sender, e);
        }

        private void eql_Click(object sender, RoutedEventArgs e)
        {
            eql_clicked.Invoke(sender, e);
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            reset_clicked.Invoke(sender, e);
        }

        private void decimalSeparator_Click(object sender, RoutedEventArgs e)
        {
            decimalSeparator_clicked.Invoke(sender, e);
        }

        private void sign_Click(object sender, RoutedEventArgs e)
        {
            sign_clicked.Invoke(sender, e);
        }
    }
}
