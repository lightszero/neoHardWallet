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

        NeoDun.Signer signer = new NeoDun.Signer();
        private void Window_Activated(object sender, EventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer(TimeSpan.FromSeconds(1.0), System.Windows.Threading.DispatcherPriority.Normal, (s, e1) =>
              {
                  this.CheckDevice();
              }, this.Dispatcher);

            CheckDevice();
            signer.Start(onRecvMsg,onSendMsg);

        }

        void onRecvMsg(NeoDun.Message recv,NeoDun.Message src)
        {
            Action call = () =>
            {

                this.list1.Items.Add("recv msg:" + DateTime.Now.ToString());


            };
            this.Dispatcher.Invoke(call);
        }

        void onSendMsg(NeoDun.Message send,bool needBack)
        {
            Action call = () =>
            {

                string tag = "send msg: " + send.tag1.ToString("X02") + send.tag2.ToString("X02");
                if (needBack)
                    tag += " 需要回复";
                tag+="  "+ DateTime.Now.ToString();
                this.list1.Items.Add(tag);
            };
            this.Dispatcher.Invoke(call);
        }
        void CheckDevice()
        {
            var signerCount= signer.CheckDevice();
            this.info1.Content = signerCount.ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            signer.Stop();//.StopRead();//不停止读取，有个线程一直卡着的
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//随机发送数据包
            byte[] data = new byte[NeoDun.SignTool.RandomShort()];
            NeoDun.SignTool.RandomData(data);

            this.signer.SendPackage(data);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//clear
            this.list1.Items.Clear();
        }
    }


}
