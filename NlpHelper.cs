using System;

namespace CybersecurityAwarenessBot
{
    public static class NlpHelper
    {
        public static string RecognizeCommand(string input)
        {
            string message = input.ToLower().Trim();

            if (message.Contains("activity") ||
                message.Contains("what have you done"))
                return "activity";

            if (message.Contains("quiz") ||
                message.Contains("game") ||
                message.Contains("test my knowledge"))
                return "quiz";

            if (message.Contains("reminder") ||
                message.Contains("remind me"))
                return "reminder";

            if (message.Contains("task") ||
                message.Contains("to do") ||
                message.Contains("to-do"))
                return "task";

            if (message.Contains("password"))
                return "password";

            if (message.Contains("phishing") ||
                message.Contains("suspicious email"))
                return "phishing";

            if (message.Contains("help") ||
                message.Contains("what can you do"))
                return "help";

            return "general";
        }
    }
}