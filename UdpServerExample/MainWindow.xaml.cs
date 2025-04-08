using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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

namespace UdpServerExample
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string targetIp = "127.0.0.1";
        private readonly int targetPort = 9000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                Log("[오류] 메시지를 입력하세요.");
                return;
            }

            try
            {
                using (UdpClient udp = new UdpClient())
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    udp.Send(data, data.Length, targetIp, targetPort);
                }

                Log($"[보냄] \"{message}\" → {targetIp}:{targetPort}");
                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                Log($"[에러] {ex.Message}");
            }
        }

        private void Log(string msg)
        {
            lstLogs.Items.Insert(0, $"{DateTime.Now:HH:mm:ss} {msg}");
        }
    }
}