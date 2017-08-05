using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace simpletest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var i = USBHIDDriver.CheckDevice();
            this.list1.Items.Add("发现设备:" + i);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var data = new byte[] { 0x01, 0x02 };
            var b = USBHIDDriver.Send(data);
            this.list1.Items.Add("send " + data.Length + " " + b);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            var data = new byte[64];
            r.NextBytes(data);
            var b = USBHIDDriver.Send(data);
            this.list1.Items.Add("send " + data.Length + " " + b);
        }
    }
}
