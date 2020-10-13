using System;
using System.Net.Sockets;
using System.Text;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("클라이언트콘솔창. \n\n\n");

            TcpClient client = new TcpClient();

            // 첫번째 매개변수는 접속할 IP
            // 서버가 내 PC에서 돌아가므로 127.0.0.1(자기자신을 나타내는 루프백IP)
            // 두번째 매개변수는 서버에서 설정한 포트번호를 입력해준다.
            client.Connect("127.0.0.1", 9999);

            // "클라이언트 : 접속합니다" 를 stream으로 보내기 위해 byte[]형으로 바꿔준다.
            byte[] buf = Encoding.Default.GetBytes("클라이언트 : 접속합니다");

            // 서버에서 Read하는 방식과 비슷한 형식으로 Write 시켜준다.
            client.GetStream().Write(buf, 0, buf.Length);

            client.Close();
        }
    }
}
