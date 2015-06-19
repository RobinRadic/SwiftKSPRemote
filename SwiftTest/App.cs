using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace SwiftTest
{
    public class App
    {
        public void RunClient()
        {
            Console.ReadLine();
        }

    }

    public static class Extensions
    {
        public static string RDump(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }

    public class Starter
    {
        public static App app;


        [STAThread]
        private static void Main(string[] args)
        {
            app = new App();
            //app.RunClient();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OutputForm());

            //Console.ReadLine();
        }
    }


}