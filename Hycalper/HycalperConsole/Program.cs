using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading; 

namespace HycalperConsole {
    public class Hycalper {
        private static bool cancel = false; 
        private static int m_linesGlobalCount = 0; 

        static void Main(string[] args) {
            bool batchMode = true; 
            Console.CancelKeyPress +=new ConsoleCancelEventHandler(Console_CancelKeyPress);
            try {
                // get file list 
                string targetDir = AppDomain.CurrentDomain.BaseDirectory;
                FileList filenames; 
                if (args.Length < 2) {
                    batchMode = true; 
                } else {
                    batchMode = false; 
                }
                string aboluteTarget;
                if (args.Length < 1)
                    aboluteTarget = targetDir;
                else
                    aboluteTarget = Path.IsPathRooted(args[0]) ? aboluteTarget = args[0]: Path.Combine(targetDir,args[0]);
                aboluteTarget = Path.GetFullPath(aboluteTarget);
                filenames = new FileList(aboluteTarget);
                while (!cancel) {
                    // run hycalper in (endless) loop ... 
                    if (filenames.Count == 0) {
                        Info("Nothing to do for target dir: " + aboluteTarget);
                    } else {
                        string msg = "Processing: " + aboluteTarget + "(" + filenames.Count + " Files)"; 
                        Message(msg);
                        Message(new string('=', msg.Length));
                        int minLenMessage = 0; 
                        m_linesGlobalCount = 0; 
                        foreach (FileList.TemplateLocation curfile in filenames.Collection) {
                            if (cancel) break; 
                            string curMessage = "Processing: " + Path.GetFileName ( curfile.Path );
                            if (curMessage.Length > minLenMessage)
                                minLenMessage = curMessage.Length; 
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Out.Write ( curMessage.PadRight ( minLenMessage, ' ' ) );
                            if (curfile.Uptodate != 1) {
                                // proccess file 
                                HycalperConsole hcc = new HycalperConsole(curfile.Path, aboluteTarget);
                                m_linesGlobalCount += hcc.LinesGlobal; 
                                switch (hcc.Error) {
                                    case 0:
                                        Message ( Environment.NewLine + " ok: " + hcc.Loops + " Loops, " 
                                                + hcc.Enums + " Enums -> " + Path.GetFileName(hcc.SaveFilename)
                                                ,minLenMessage);
                                        filenames.Setuptodate(hcc.SaveFilename); 
                                        break; 
                                    case 2:
                                        Info ( Environment.NewLine + hcc.Message, minLenMessage );
                                        break; 
                                    case 3:
                                        // nothing to do -> rewind
                                        Console.Out.Write ( '\r' );
                                        break; 
                                    default:
                                        Error ( Environment.NewLine + "Error: " + hcc.Message, minLenMessage );
                                    break; 
                                } 
                                Thread.Sleep ( 20 );
                            } else {
                                Info ( Environment.NewLine + " Uptodate -> skipped.", minLenMessage );
                            }
                        }
                        Message ( filenames.Count + " Files hycalped successfully! " + m_linesGlobalCount + " lines found.", minLenMessage );
                    }
                    if (!batchMode) {
                        Message (Environment.NewLine + "Any key: Re-run, CTRL+C: Quit"); 
                        Console.ReadKey(); 
                        filenames.Refresh();
                    } else {
                        cancel = true; 
                    }
                } 
            } catch (Exception e) {
                Error("Error while proccessing Hycalper: " + e.Message); 
            }
            if (batchMode == false) {
                Console.In.Read(); 
            }
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) {
            cancel = true; 
        }
        private static void Info(string msg) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ( msg );
            return;
        }
        private static void Error(string msg) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine ( msg );
            return;
        }
        private static void Message(string msg) {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine ( msg );
            return;
        }
        private static void Info(string msg, int minLen) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ( msg.PadRight ( minLen, ' ' ) );
            return;
        }
        private static void Error(string msg, int minLen) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine ( msg.PadRight ( minLen, ' ' ) );
            return;
        }
        private static void Message(string msg, int minLen) {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine ( msg.PadRight ( minLen, ' ' ) );
            return;
        }
    }
}
