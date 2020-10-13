using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestServer
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("서버콘솔창 \n\n\n");

    //        // TcpListener 생성자에 붙는 매개변수
    //        // 첫번째는 IP를 두번째는 port 번호
    //        TcpListener server = new TcpListener(IPAddress.Any, 9999);

    //        // 서버를 시작합니다.
    //        server.Start();

    //        // 클라이언트 객체를 만들어 9999에 연결한 client를 받아옵니다.
    //        // 클라이언트가 접속할때까지 서버는 해당구문에서 블락된다.
    //        TcpClient client = server.AcceptTcpClient();

    //        // NetworkStream 객체를 만들어 client에서 보낸 데이터를 받을 객체를 생성합니다.
    //        NetworkStream ns = client.GetStream();

    //        // Socket은 byte[] 형식으로 데이터를 주고받으므로 byte[]형 변수를 선언합니다.
    //        byte[] byteData = new byte[1024];

    //        // 클라이언트가 write한 데이터를 읽어온다.
    //        // 아래의 작업 이후에 byteData에는 읽어온 데이터가 들어간다.
    //        // 동기서버의 경우 해당코드에서 읽을데이터가 올때까지 대기한다.
    //        ns.Read(byteData, 0, byteData.Length);

    //        // 출력을 위해 byteData를 string형으로 바꿔준다.
    //        string stringData = Encoding.Default.GetString(byteData);

    //        Console.WriteLine(stringData);

    //        server.Stop();
    //        ns.Close();
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("서버콘솔창. \n\n\n");

            // TcpListener 생성자에 붙는 매개변수
            // 첫번째는 IP를 두번째는 port 번호
            TcpListener server = new TcpListener(IPAddress.Any, 9999);

            // 서버를 시작합니다.
            server.Start();

            // 클라이언트 객체를 만들어 9999에 연결한 client를 받아온다.
            // 클라이언트가 접속할때까지 서버는 해당구문에서 블락된다.
            TcpClient client = server.AcceptTcpClient();

            // socket은 byte[] 형식으로 데이터를 주고받으므로 byte[]형 변수를 선언한다.
            byte[] byteData = new byte[1024];

            // client가 write한 정보를 읽어온다.
            // 아래의 작업 이후 byteData에는 읽어온 데이터가 들어간다.
            // 동기서버의 경우 해당코드에서 읽을데이터가 올때까지 대기한다.
            client.GetStream().Read(byteData, 0, byteData.Length);

            // 출력을 위한 string형으로 바꿔준다.
            Console.WriteLine(Encoding.Default.GetString(byteData));

            server.Stop();
        }
    }
}
