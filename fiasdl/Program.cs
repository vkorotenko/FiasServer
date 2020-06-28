using System;

namespace FiasDl
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 1) return Help();
            var dl = new DownloadHelper();
            try
            {
                for (var i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-dx":
                            dl.IsXml = true;
                            dl.IsFull = false;
                            break;
                        case "-dd":
                            dl.IsXml = false;
                            dl.IsFull = false;
                            break;
                        case "-dxf":
                            dl.IsXml = true;
                            dl.IsFull = true;
                            break;
                        case "-ddf":
                            dl.IsXml = false;
                            dl.IsFull = true;
                            break;
                        case "-nl":
                            dl.IsListVersions = true;
                            break;
                        case "-n":
                            dl.Version = int.Parse(args[i + 1]);
                            break;
                        case "-o":
                            dl.BaseDir = args[i + 1];
                            break;
                        case "-r":
                            throw new NotImplementedException("Not implemented");
                        case "-c":
                            dl.Config = args[i + 1];
                            dl.HasConfig = true;
                            break;
                    }
                }
                return dl.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -2;
            }
        }

        static int Help()
        {
            Console.WriteLine("Usage: downloader ");
            Console.WriteLine("\t-dx download latest xml delta if -n specific version");// --
            Console.WriteLine("\t-dd download latest dbf delta if -n specific version");//--
            Console.WriteLine("\t-dxf download latest xml if -n specific version");//--
            Console.WriteLine("\t-ddf download latest dbf if -n specific version");//--
            Console.WriteLine("\t-n integer version");//--
            Console.WriteLine("\t-nl list all version");//--
            Console.WriteLine("\t-o output base dir, create if not exist");// --
            Console.WriteLine("\t-r base remote server, eg https://vkorotenko.ru/fias");
            Console.WriteLine("\t-c config file to process data");
            return -1;
        }
    }
}
