using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SwiftTest
{
    public class App
    {
        public App()
        {

            Client.Execute();
            Console.ReadLine();
        }

    }
    public class Starter
    {
        public static App app;

        static void Main(string[] args)
        {
            app = new App();
        }
    }
}
