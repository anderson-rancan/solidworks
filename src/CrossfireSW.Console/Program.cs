using CrossfireSW.Util;
using System;
using System.Linq;
using System.Reflection;

namespace CrossfireSW.Console
{
    class Program
    {
        public Program()
        {
            Composition.Compose(this);
        }

        public void Start(string[] args)
        {
            ShowAppInfo();

            var arguments = ParseArguments(args);

            if (arguments == Arguments.Config)
            {
                var app = new Wpf.App();
                var config = new Wpf.ConfigWindow();
                app.Run(config);
            }
        }

        public void ShowAppInfo()
        {
            var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes();

            var description = attributes
                .OfType<AssemblyDescriptionAttribute>()
                .FirstOrDefault()
                .Description;

            var copyright = attributes
                .OfType<AssemblyCopyrightAttribute>()
                .FirstOrDefault()
                .Copyright;

            System.Console.WriteLine(description);
            System.Console.WriteLine(copyright);
            System.Console.WriteLine();
        }

        public Arguments ParseArguments(string[] args)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;

            if (args.Contains("/c", comparer) || args.Contains("-c", comparer))
                return Arguments.Config;

            return Arguments.None;
        }

        [STAThread]
        public static void Main(string[] args)
        {
            var program = new Program();
            program.Start(args);
        }
    }
}
