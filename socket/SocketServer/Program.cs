using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.WebSocket;

namespace SocketServer
{
    class Program
    {
        private static WebSocketServer wsServer;
        static void Main(string[] args)
        {
            wsServer = new WebSocketServer();
            int port = 8080;
            wsServer.Setup(port);
            wsServer.NewSessionConnected += WsServer_NewSessionConnected;
            wsServer.NewDataReceived += WsServer_NewDataReceived;
            wsServer.NewMessageReceived += WsServer_NewMessageReceived;
            wsServer.SessionClosed += WsServer_SessionClosed;
            wsServer.Start();
            Console.WriteLine("Socket Server port - " + port + ". Press any key to exit...");
            Console.ReadKey();
            wsServer.Stop();
        }

        private static void WsServer_SessionClosed(WebSocketSession session, CloseReason value)
        {
            Console.WriteLine("SessionClosed");
        }

        private static void WsServer_NewMessageReceived(WebSocketSession session, string value)
        {
            Console.WriteLine("NewMessageReceived: " + value);
            if (value != null)
            {
                session.Send("Hello from the other side...");
            }
        }

        private static void WsServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            Console.WriteLine("NewDataReceived");
        }

        private static void WsServer_NewSessionConnected(WebSocketSession session)
        {
            Console.WriteLine("NewSessionConnected");
        }
    }
}
