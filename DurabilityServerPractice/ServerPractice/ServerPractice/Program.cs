using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("서버콘솔창. \n");

            // TcpListener 생성자에 붙는 매개변수는
            // 첫번째는 IP를 두번째는 port 번호입니다.
            TcpListener server = new TcpListener(IPAddress.Any, 7777); // IPAddress.Any = 서버자체에 존재하는 IP를 사용하겠다.

            // 서버를 시작합니다.
            server.Start();

            // 클라이언트 객체를 만들어 9999에 연결한 client를 받아옵니다.
            // 받아 올때까지 서버는 대기합니다.
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("클라이언트가 접속하였습니다.");

            // 한번 읽고 콘솔창 출력이 완료된 후 다시 While루프를 읽을 데이터를 기다립니다.
            while(true)
            {
                // Socket은 byte[] 형식으로 데이터를 주고받으므로 byte[]형 변수를 선업합니다.
                byte[] byteData = new byte[1024];
                // client가 write한 정보를 읽어옵니다.
                // 아래의 작업 이후에 byteData에는 읽어온 데이터가 들어갑니다.
                client.GetStream().Read(byteData, 0, byteData.Length);

                // 출력을 위해 string형으로 바꿔줍니다.
                string strData = Encoding.Default.GetString(byteData);

                // byteData의 크기는 1024인데 스트림에서 읽어온 데이터가 1024보다 작은경우
                // 공백이 출력되니 비어있는 문자열을 제거합니다.
                int endPoint = strData.IndexOf('\0');
                string parsedMessage = strData.Substring(0, endPoint + 1);

                // 파싱된 데이터를 출력해주고 while루프를 돕니다.
                Console.WriteLine(parsedMessage);
            }
        }
    }
}
