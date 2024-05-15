using DiscUtils.Complete;

using Isotonic.CLI.CLI.Commands;

using Spectre.Console.Cli;

namespace Isotonic.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SetupHelper.SetupComplete();

            var app = new CommandApp();

            app.Configure(cfg =>
            {
                cfg.AddCommand<ExtractCommand>("extract");
            });

            app.Run(args);
        }
    }
}
