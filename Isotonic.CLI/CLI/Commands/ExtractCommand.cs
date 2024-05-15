using Isotonic.CLI.Core.Images;

using Spectre.Console.Cli;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isotonic.CLI.CLI.Commands
{
    public class ExtractCommandSettings : CommandSettings
    {
        [CommandArgument(0, "<FILEPATH>")]
        public string FilePath { get; set; }
    }

    public class ExtractCommand : Command<ExtractCommandSettings>
    {
        public override int Execute(CommandContext context, ExtractCommandSettings settings)
        {
            IsoImageManager manager = new IsoImageManager(settings.FilePath);

            manager.Test();

            return 0;
        }
    }
}
