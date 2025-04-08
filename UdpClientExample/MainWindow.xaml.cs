using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UdpClientExample
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private UdpClient udpClient;
        private bool isRunning = false;
        private const int receivePort = 9000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void DataReceive_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("이미 수신 중입니다.");
                return;
            }

            isRunning = true;
            udpClient = new UdpClient(receivePort);
            lstMessages.Items.Insert(0, $"[수신 시작] 포트 {receivePort}");

            await Task.Run(async () =>
            {
                while (isRunning)
                {
                    try
                    {
                        var result = await udpClient.ReceiveAsync();
                        string msg = Encoding.UTF8.GetString(result.Buffer);

                        Dispatcher.Invoke(() =>
                        {
                            lstMessages.Items.Insert(0, $"[수신] {msg}");
                        });
                    }
                    catch (Exception ex)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            lstMessages.Items.Insert(0, $"[에러] {ex.Message}");
                        });
                    }
                }
            });
        }

        protected override void OnClosed(EventArgs e)
        {
            isRunning = false;
            udpClient?.Close();
            base.OnClosed(e);
        }

    }
}