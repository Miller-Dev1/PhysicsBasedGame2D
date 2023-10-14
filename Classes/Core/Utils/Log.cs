using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhsyxLite.Classes.Core
{
    public class Log
    {

        public static void Print(object message)
        {
            Console.WriteLine(ColorizeText(message));
        }

        static string ColorizeText(object input)
        {
            string coloredText = input.ToString();

            string[] colorTags = { "<red>", "<green>", "<yellow>", "<blue>", "<magenta>", "<cyan>", "<white>" };
            string[] colorCodes = {
                "\x1b[31m", // Red
                "\x1b[32m", // Green
                "\x1b[33m", // Yellow
                "\x1b[34m", // Blue
                "\x1b[35m", // Magenta
                "\x1b[36m", // Cyan
                "\x1b[37m"  // White
            };

            for (int i = 0; i < colorTags.Length; i++)
            {
                coloredText = coloredText.Replace(colorTags[i], colorCodes[i]);
            }

            coloredText += "\x1b[0m"; // Reset color

            return coloredText;
        }
    }
}
