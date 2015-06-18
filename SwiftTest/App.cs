using System;
using System.Collections;
using System.Collections.Generic;

namespace SwiftTest
{
    public class App
    {
        public void RunClient()
        {
            Client.Execute();
            Console.ReadLine();
        }

    }

    public class Starter
    {
        public static App app;

        private static void Main(string[] args)
        {
            app = new App();
            app.RunClient();

            Console.ReadLine();
        }
    }


}