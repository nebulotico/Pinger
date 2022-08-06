using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace Pinger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Atomo -> Pinger";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
██████╗ ██╗███╗   ██╗ ██████╗ ███████╗██████╗ 
██╔══██╗██║████╗  ██║██╔════╝ ██╔════╝██╔══██╗
██████╔╝██║██╔██╗ ██║██║  ███╗█████╗  ██████╔╝
██╔═══╝ ██║██║╚██╗██║██║   ██║██╔══╝  ██╔══██╗
██║     ██║██║ ╚████║╚██████╔╝███████╗██║  ██║
╚═╝     ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝
Telegram: @Mahitozin
Github: https://github.com/Mahitozin
");
            Console.ResetColor();
            string ip = input("Ip -> ");
            int timeout = int.Parse(input("Timeout(s) -> ")) * 1000;
            int delay = int.Parse(input("Delay(ms) -> "));

            new Task(() =>
            {
                while (true)
                {
                    Ping p = new Ping();
                    var r = p.Send(ip, timeout);
                    if(r.Status == IPStatus.Success)
                    {
                        log($"[Ip -> {ip}] [Ms -> {r.RoundtripTime}] [Status -> {r.Status}] [ttl -> {r.Options.Ttl}]", ConsoleColor.DarkGreen);
                    }
                    else
                    {
                        log($"[Ip -> {ip}] z[Status -> {r.Status}]", ConsoleColor.DarkRed);
                    }
                    Thread.Sleep(delay);
                }
            }).Start();
            Console.ReadLine();
        }

        static string input(string msg)
        {
            ConsoleColor cb = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[{DateTime.Now.ToString("hh:mm:ss")}] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(msg);
            Console.ForegroundColor = cb;

            return Console.ReadLine();
        }

        static void log(string msg, ConsoleColor cor)
        {
            ConsoleColor cb = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[{DateTime.Now.ToString("hh:mm:ss")}] ");
            Console.ForegroundColor = cor;
            Console.WriteLine(msg);
            Console.ForegroundColor = cb;
        }
    }
}