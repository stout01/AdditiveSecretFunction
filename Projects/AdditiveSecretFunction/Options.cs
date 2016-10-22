using System;
using System.Linq;
using CommandLine;
using CommandLine.Text;

namespace AdditiveSecretFunction
{
    public class Options
    {
        [Option('l', "limit", DefaultValue = 1000, HelpText = "Integer to determine the maximum prime number")]
        public int Limit { get; set; }

        [ParserState]
        public IParserState ParserState { get; set; }

        [HelpOption('h', "help")]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = HeadingInfo.Default,
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            if (ParserState?.Errors.Any() == true)
            {
                var errors = help.RenderParsingErrorsText(this, 2);

                if (!string.IsNullOrEmpty(errors))
                {
                    help.AddPreOptionsLine($"{Environment.NewLine}ERROR(S):");
                    help.AddPreOptionsLine(errors);
                }
            }

            help.AddOptions(this);
            return help;
        }
    }
}