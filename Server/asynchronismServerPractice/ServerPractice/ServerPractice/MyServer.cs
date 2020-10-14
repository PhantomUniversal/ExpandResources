using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerPractice
{
    /* 비동기 구문
     * BeginInvoke, BeginRead, BeginWrite  Begin이 붙은 메소드들은 비동기
     * AsyncCallback : 클라이언트가 메시지를 보내서 서버가 해당 메시지를 읽게 됐을 때 클백메서드가 실행.(쓰레드플의 쓰레드가 실행)
     *                 = 서버는 블락되지않고 Read과정을 할수 있게 된다.
     */

    class MyServer
    {
        public MyServer()
        {
            // 서버 시작
            AsyncServerStart();
        }

        private void AsyncServerStart()
        {
            // 서버 포트설정 및 시작
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 7777));
            listener.Start();
            Console.WriteLine("서버를 시작합니다. 클라이언트의 접속을 기다립니다.");

            // 연결을 요청함 client의 객체를 acceptClient에 저장
            TcpClient acceptClient = listener.AcceptTcpClient();
            Console.WriteLine("클라이언트 접속 성공");

            // ClientData의 객체를 생성해주고 연결된 클라이언트를 ClientData의 멤버로 설정해준다.
            ClientData clientData = new ClientData(acceptClient);

            // BeginRead를 통해 비동기로 읽는다.(읽을데이터가 올때까지 대기하지않고 바로 아랫줄의 while문으로 이동한다)
            clientData.client.GetStream().BeginRead(clientData.readByteData, 0, clientData.readByteData.Length, new AsyncCallback(DataReceived), clientData);

            // 데이터를 읽든 못읽든 일단 바로 해당로직이 실행된다(비동기서버)
            while (true)
            {
                Console.WriteLine("서버 구동중");
                Thread.Sleep(1000);
            }
        }
        /* callbackClient.client.GetStream().BeginRead(callbackClient.readByteData, 0, callbackClient.readByteData.Length, 
         * new AsyncCallback(DataReceived), callbackClient)
         * Begin Read를 다시 넣어주므로써 메시지가 오면 콜백메서드가 호출
         * 비동기서버는 While루프를 돌리지 않고 클라이언트의 메시지를 계속 받을 수 있다.
         */

        private void DataReceived(IAsyncResult ar) // 피호출자(클라이언트)가 실행해 준 메서드(콜백 메서드)
        {
            // 콜백메서드입니다. (피 호출자가 호출자의 해당 메서드를 실행시켜줍니다)
            // 즉 데이터를 읽었을때 실행됩니다.

            // 콜백으로 받아온 Data를 ClienetData로 형변환 해줍니다.
            ClientData callbackClient = ar.AsyncState as ClientData;

            // 실제로 넘어온 크기를 받아옵니다
            int bytesRead = callbackClient.client.GetStream().EndRead(ar);

            // 문자열로 넘어온 데이터를 파싱해서 출력해줍니다.
            string readString = Encoding.Default.GetString(callbackClient.readByteData, 0, bytesRead);

            Console.WriteLine(readString);

            // 비동기서버에서 가장중요한 핵심입니다.
            // 비동기서버는 while문을 돌리지않고 콜백메서드에서 다시 읽으라고 비동기명령을 내립니다.
            callbackClient.client.GetStream().BeginRead(callbackClient.readByteData, 0, callbackClient.readByteData.Length, new AsyncCallback(DataReceived), callbackClient);
        }
    }

    class ClientData
    {
        // 연결이 확인된 클라이언트를 넣어줄 클래스입니다.
        // readByteData는 stream데이터를 읽어올 객체입니다.
        public TcpClient client { get; set; }
        public byte[] readByteData { get; set; }

        public ClientData(TcpClient client)
        {
            this.client = client;
            this.readByteData = new byte[1024];
        }
    }
}
