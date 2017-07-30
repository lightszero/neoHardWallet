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

namespace driver_win
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

        private void Window_Activated(object sender, EventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer(TimeSpan.FromSeconds(1.0), System.Windows.Threading.DispatcherPriority.Normal, (s, e1) =>
              {
                  this.CheckDevice();
              }, this.Dispatcher);

            CheckDevice();
            USBHIDDriver.StartRead((bs) =>
            {
                Action call = () =>
                 {
                     if(bs[1]==0x31)
                     {
                         this.list1.Items.Insert(0, "同意交易" + DateTime.Now.ToString());

                     }
                     else
                     {
                         this.list1.Items.Insert(0, "拒绝交易" + DateTime.Now.ToString());
                     }

                 };
                this.Dispatcher.Invoke(call);
            });
        }
        void CheckDevice()
        {
            var signerCount= USBHIDDriver.CheckDevice();
            this.info1.Content = signerCount.ToString();
            if (USBHIDDriver.IsActive())
                USBHIDDriver.Send("abc");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            USBHIDDriver.StopRead();//不停止读取，有个线程一直卡着的
        }
    }


}
