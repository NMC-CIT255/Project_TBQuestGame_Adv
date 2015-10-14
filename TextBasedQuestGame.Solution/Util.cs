using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextBasedQuestGame.Solution
{
    public class Util
    {
        /// <summary>
        /// wraps text using a list of strings
        /// Original code from Mike Ward's website
        /// http://mike-ward.net/2009/07/19/word-wrap-in-a-console-app-c/
        /// Adapted to include a left margin for console window support
        /// </summary>
        /// <param name="text">text to wrap</param>
        /// <param name="rightMargin">length of each line</param>
        /// <param name="leftMargin">left margin</param>
        /// <returns>list of lines as strings</returns>
        public static List<string> Wrap(string text, int rightMargin, int leftMargin)
        {
            int start = 0, end;
            var lines = new List<string>();

            string leftMarginSpaces = "";
            for (int i = 0; i < leftMargin; i++)
            {
                leftMarginSpaces += " ";
            }

            text = Regex.Replace(text, @"\s", " ").Trim();

            while ((end = start + rightMargin) < text.Length)
            {
                while (text[end] != ' ' && end > start)
                    end -= 1;

                if (end == start)
                    end = start + rightMargin;

                lines.Add(leftMarginSpaces + text.Substring(start, end - start));
                start = end + 1;
            }

            if (start < text.Length)
                lines.Add(leftMarginSpaces + text.Substring(start));

            return lines;
        }
    }
}
