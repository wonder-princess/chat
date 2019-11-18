using System;

namespace ChatReceive_UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            //バインドするローカルIPとポート番号
            string localIpString = "192.168.0.7";
            var localAddress = System.Net.IPAddress.Parse(localIpString);
            
            // Browsing datagram responses of NetBIOS over TCP/IP
            int localPort = 138;
            
            // Browsing requests of NetBIOS over TCP/IP
            //int localPort = 137;

            //指定したアドレスとポート番号を使用して、IPEndPointクラスの新しいインスタンスを初期化
            var localEP = new System.Net.IPEndPoint(localAddress, localPort);

            //インスタンスを初期化し、指定したローカルエンドポイントにバインド
            var udp = new System.Net.Sockets.UdpClient(localEP);

            for (; ; )
            {
                //データを受信
                System.Net.IPEndPoint remoteEP = null;

                //リモートホストが送信したUDPデータグラムを返す
                byte[] rcvBytes = udp.Receive(ref remoteEP);

                //データを文字列に変換
                string rcvMsg = System.Text.Encoding.UTF8.GetString(rcvBytes);

                //受信したデータと送信者の情報を表示
                Console.WriteLine("受信したデータ:{0}", rcvMsg);
                Console.WriteLine("送信元アドレス:{0}/ポート番号:{1}", remoteEP.Address, remoteEP.Port);

                //"exit"を受信したら終了
                if (rcvMsg.Equals("exit"))
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
