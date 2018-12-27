using System;
using System.Collections.Generic;
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
    /// 문자메세지를 발송하는 클래스를 구현합니다.
    /// </summary>
    /// <remarks>
    /// <br>작성자 : 미니소프트 이정석 </br>
    /// <br>최초작성일 : 2015년 07월 13일 </br>
    /// <br>주요변경 로그</br>
    /// </remarks>
    public class SMSHelper : IDisposable
    {
        #region "Private 변수 정의 부분"

        // Socket 서버
        private const string SMS_SERVER = "SMSServer";
        private static string ServerAddress = "";
        public ILog logger;
        #endregion

        #region "생성자 정의 부분"

        /// <summary>
        /// 생성자입니다.
        /// </summary>
        public SMSHelper(string address)
        {
            ServerAddress = address;
            logger = LogManager.GetLogger("SMSLogger");
        }

        #endregion

        #region "Private 메소드 정의 부분"

        /// <summary>
        /// 소켓 초기화 및 메신저 서버와의 컨넥션 유지 기능
        /// </summary>
        /// <returns>메신저 연동 소켓 서버와 Connection 맺은 Socket 인스턴스</returns>
        private Socket InitializeSocket()
        {
            //  메신저 연동 소켓 서버 IP 정의
            string remoteIp = ServerAddress;
            //remoteIp = "";// System.Text.Encoding.UTF8.GetString(TheOne.Security.FoxCryptoHelper.Decrypt(remoteIp));

            //  문자열 파싱하여, IPEndPoint 객체 생성
            string[] ipEndPorint = remoteIp.Split(new char[] { ':' });
            IPAddress ip = IPAddress.Parse(ipEndPorint[0]);
            IPEndPoint _endpoint = new IPEndPoint(ip, int.Parse(ipEndPorint[1]));

            //  소켓 생성
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //  컨넥션 맺기
                socket.Connect(_endpoint);
            }
            catch (SocketException se)
            {
                logger.Error(se.StackTrace, se);
                //throw new Exception("SMS 서버로부터 응답이 없습니다.", se);
            }

            return socket;
        }

        #endregion

        #region "Public 메소드 정의 부분"

        /// <summary>
        /// 다수의 번호를 한개의 문자로 전송합니다.
        /// </summary>
        /// <param name="telNos">전화번호</param>
        /// <param name="message">메세지</param>
        public void SendMessage(List<string> telNos, string message)
        {
            telNos.ForEach(s => SendMessage(s, message));
        }

        /// <summary>
        /// 지정된 핸드폰 번호로 문자 메세지를 전송합니다.
        /// </summary>
        /// <param name="telNo">핸드폰번호</param>
        /// <param name="msg">문자메세지</param>
        public void SendMessage(string telNo, string msg, string sendNo = "0237747236")
        {
            try
            {
                var socket = this.InitializeSocket();
                // 문자를 발송할 경우 첫 글자는 구문으로 제거되므로 두바이트의 공백을 설정합니다.
                string message = string.Concat("  ", msg);

                string content = "0176".PadRight(4, ' ') +
                          "17".PadRight(2, ' ') +
                          "06".PadRight(2, ' ') +
                          sendNo.PadRight(16, ' ') +
                          "TANGO".PadRight(20, ' ') +
                          telNo.PadRight(16, ' ') +
                          "3139411".PadRight(8, ' ') +
                          "00".PadRight(2, ' ') +
                          "0000000000".PadRight(10, ' ') +
                          "00".PadRight(2, ' ') +
                          message.PadRight(80, ' ') +
                          "              ".PadRight(14, ' ');

                socket.Send(Encoding.GetEncoding("euc-kr").GetBytes(content));
                socket.Close();
                socket.Dispose();

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
            }
            
            logger.Info(string.Format("Send SMS Successfully.(Receiver : {0})", telNo));
        }

        #endregion

        #region "인터페이스 구현 부분"

        /// <summary>
        /// IDispose 인터페이스 구현 메소드
        /// 이 클래스가 소멸될 때 호출되는 메소드입니다.
        /// </summary>
        public void Dispose()
        {

        }

        #endregion
    }
}
