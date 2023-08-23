using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace pong
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GiaoDienChuaDangKi()); ;
            
        }
    }
}