using APIAVOS.API.DateTime;
using AVOS;
using AVOS.BootCore;
using AVOS.KernelLibs.native;
using AVOS.System64.Colors;
using AVOS.System64.Managment;
using Cosmos.HAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funn = Cosmos.System;

namespace AVOSAPI.API.Plugins.Authors.AndreyPepper.AVDiagnostics
{
    public static class AVDiagnostics
    {
        public static string avpldiagnosticsver = "1.0[A]";
        public static bool PluginWork = true;

        public static void Diagnostics()
        {
            Console.Clear();
            //DrawConsole.DiagnosticsText();
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to the diagnostic menu!");
            Console.WriteLine("What can be checked: Audio (1), Keys (2)");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("================================================================================");
            TextColors.TextColorWhite();
            Console.WriteLine("                              Control keys:                                     ");
            Console.WriteLine("Press ESC to exit");
            Console.WriteLine("Press F1 to start diagnostics");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("================================================================================");
            TextColors.TextColorWhite();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        System.Threading.Thread.Sleep(1000);
                        Diagnostics();
                        return;
                    }

                    else if (key == ConsoleKey.F1)
                    {
                        Start();
                        return;
                    }
                }
            }
        }
        public static void Start()
        {
            string inp = ISteram.In("Write a number for diagnosis: ");
            if (inp == "1")
            {
                Console.Clear();
                testaudio.TestAudio();
            }

            else if (inp == "2")
            {
                if (Funn.KeyboardManager.TryReadKey(out var keyEvent))
                {
                    Console.WriteLine($"Key pressed: {keyEvent.Key}, Char: {keyEvent.KeyChar}");


                    // Проверка на ESC для выхода
                    if (keyEvent.Key == Funn.ConsoleKeyEx.Escape)
                    {
                        Console.WriteLine("Exit...");
                        Console.Clear();
                        Diagnostics();
                    }
                }
            }
        }
    }
}
