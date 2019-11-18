using System;

namespace ChatSend_UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            //データを送信するリモートホストとポート番号
            string remoteHost = "192.168.0.7";

            // Browsing datagram responses of NetBIOS over TCP/IP
            int remotePort = 138;

            // Browsing requests of NetBIOS over TCP/IP
            //int remotePort = 137;

            //UdpClientオブジェクトを作成する
            var udp = new System.Net.Sockets.UdpClient();

            for (; ; )
            {
                //送信するデータを作成する
                Console.WriteLine("送信する文字列を入力してください。");
                string sendMsg = Console.ReadLine();
                byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes(sendMsg);

                //リモートホストを指定してデータを送信する
                udp.Send(sendBytes, sendBytes.Length, remoteHost, remotePort);

                //"exit"と入力されたら終了
                if (sendMsg.Equals("exit"))
                {
                    break;
                }
            }

            //UdpClientを閉じる
            udp.Close();

            Console.WriteLine("終了しました。");
            Console.ReadLine();
        }
    }
}