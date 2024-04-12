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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ImageRangeInputDialog.xaml
    /// </summary>
    public partial class ImageRangeInputDialog : Window
    {
        public int StartNumber { get; set; }
        public int EndNumber { get; set; }

        public ImageRangeInputDialog()
        {
            InitializeComponent();
        }
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtStartNumber.Text, out int startNumber) || !int.TryParse(txtEndNumber.Text, out int endNumber))
            {
                MessageBox.Show("Please enter valid numbers for the range.");
                return;
            }
            StartNumber = startNumber;
            EndNumber = endNumber;
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
