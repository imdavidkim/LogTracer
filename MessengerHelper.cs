using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Configuration;
using log4net;
using log4net.Config;

namespace Tracer
{
    /// <summary>
    /// DW메신저에 메세지를 발송하는 기능을 구현한 클래스입니다.
    /// </summary>
    /// <remarks>
    /// <br>작성자 : 미니소프트 이정석 </br>
    /// <br>최초작성일 : 2015년 07월 13일 </br>
    /// <br>주요변경 로그</br>
    /// </remarks>
	public class MessengerHelper : IDisposable
    {
        #region "Private 변수 정의 부분"

        // Socket 서버
        private const string MESSENGER_SERVER = "MessengerServer";
        private static string ServerAddress = "";
        Socket _socket;
        string _securityKey;
        public ILog logger;
        #endregion

        #region "생성자 정의 부분"

        /// <summary>
        /// MessengerHelper의 인스턴스를 생성하는 생성자입니다.
        /// </summary>
        public MessengerHelper(string url)
        {
            ServerAddress = url;
            logger = LogManager.GetLogger("MessengerLogger");
        }

        #endregion

        #region "Private 메소드 정의 부분"

        /// <summary>
        /// 소켓 초기화 및 메신저 서버와의 컨넥션 유지 기능
        /// </summary>
        private void InitializeSocket()
        {
            //  바뀐 서버 IP 10.100.55.251 : socket port 12581
            //TODO : 메신져 사용 허가 시 서버의 런처에 Config 정의되있는것 찾아서 암호화된 주로로 바꾸기

            //  메신저 연동 소켓 서버 IP 정의
            string remoteIp = ServerAddress;// ConfigurationManager.AppSettings[MESSENGER_SERVER];

            //  문자열 파싱하여, IPEndPoint 객체 생성
            string[] ipEndPorint = remoteIp.Split(new char[] { ':' });
            IPAddress ip = IPAddress.Parse(ipEndPorint[0]);
            IPEndPoint _endpoint = new IPEndPoint(ip, int.Parse(ipEndPorint[1]));

            //  소켓 생성
            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //컨넥션 맺기
                this._socket.Connect(_endpoint);
            }
            catch (SocketException se)
            {
                throw new Exception("메신저 서버로부터 응답이 없습니다.", se);
            }


            //  Security Key 정의
            //  컨넥션은 맺으면, 서버에서 Security Key Send
            byte[] receive = new byte[1024];
            int byteRec = this._socket.Receive(receive, SocketFlags.None);

            if (byteRec > 0)
            {
                this._securityKey = Encoding.GetEncoding("euc-kr").GetString(receive, 0, byteRec - 1);
                this._securityKey = this._securityKey.Split(Convert.ToChar(12))[0];
            }
            else
            {
                throw new Exception("Not receive security key");
            }
        }

        #endregion

        #region "Public 메소드 정의 부분"


        /// <summary>
        /// 메신저 사용자에게 단체로 메세지 전달을 합니다.
        /// </summary>
        /// <param name="userIdList">사용자 ID List</param>
        /// <param name="title">메세지 제목</param>
        /// <param name="content">메세지 내용</param>
        /// <param name="url">URL</param>
        public void SendMessage(List<string> userIdList, string title, string content, string url = "")
        {
            StringBuilder sb = new StringBuilder();

            foreach (string userId in userIdList)
            {
                sb.Append(userId);
                sb.Append(",");
            }

            sb.Remove(sb.Length - 1, 1);

            this.SendMessage(sb.ToString(), title, content, url);
        }

        /// <summary>
        /// 지정한 사용자에게 메세지를 전달합니다.
        /// </summary>
        /// <param name="userStr">사용자 ID</param>
        /// <param name="title">메세지 제목</param>
        /// <param name="content">메세지 내용</param>
        /// <param name="url">URL</param>
        public void SendMessage(string userStr, string title, string content, string url = "")
        {
            string remoteIp = ServerAddress;
            try
            {
                using (WebClient client = new WebClient())
                {
                    NameValueCollection vals = new NameValueCollection();
                    vals.Add("CMD", "ALERT");
                    vals.Add("Action", "ALERT");
                    vals.Add("SystemName", "Tango");
                    vals.Add("SendId", "Tango");
                    vals.Add("SendName", "Tango");
                    vals.Add("RecvId", userStr);
                    vals.Add("Subject", title);
                    vals.Add("Contents", content);

                    byte[] result = client.UploadValues(remoteIp, vals);
                    string rStr = Encoding.ASCII.GetString(result);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                //throw new Exception(ex.Message);
                //Console.WriteLine(ex.ToString());
            }
            logger.Info(string.Format("Send Messenger Message Successfully.(Receiver : {0})", userStr));
        }

        #endregion

        #region "인터페이스 구현 부분"

        /// <summary>
        /// IDispose 인터페이스 구현 메소드
        /// 이 클래스가 소멸될 때 호출되는 메소드입니다.
        /// </summary>
        public void Dispose()
        {
            if (this._socket != null)
            {
                this._socket.Close();
                this._socket.Dispose();
            }
        }

        #endregion
    }
}
