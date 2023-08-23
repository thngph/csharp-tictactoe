using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
namespace pong
{
    public class AppControler
    {
        private static string time;
        public static string TIME
        {
            get
            {
                return time = LayThoiGian();
            }

        }
        public static string LayThoiGian()
        {
            string time="";
            time = DateTime.Now.ToString();
            return time;
        }
    }
}
