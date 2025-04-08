using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
        private Thread receiveThread;
        private bool isRunning = false;
        private const int receivePort = 9000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataReceive_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("이미 수신 중입니다.");
                return;
            }

            isRunning = true;
            isRunning = true;
            lstMessages.Items.Insert(0, $"[수신 시작] 포트 {receivePort}");

            receiveThread = new Thread(RecvCallBack);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }
        private void RecvCallBack()
        {
            try
            {
                udpClient = new UdpClient(receivePort);

                while (isRunning)
                {
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                    byte[] buffer = udpClient.Receive(ref remoteEP); // blocking call

                    string message = Encoding.UTF8.GetString(buffer);
                    Dispatcher.Invoke(() =>
                    {
                        lstMessages.Items.Insert(0, $"[수신] {message}");
                    });
                }
            }
            catch (SocketException se)
            {
                Dispatcher.Invoke(() =>
                {
                    lstMessages.Items.Insert(0, $"[소켓 예외] {se.Message}");
                });
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() =>
                {
                    lstMessages.Items.Insert(0, $"[예외] {ex.Message}");
                });
            }
            finally
            {
                udpClient?.Close();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            isRunning = false;

            if (udpClient != null)
            {
                udpClient.Close(); // force unblocking
            }

            if (receiveThread != null && receiveThread.IsAlive)
            {
                receiveThread.Join(1000); // wait 1 sec for clean exit
            }
        }

    }
}