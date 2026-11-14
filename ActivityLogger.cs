using System;
using System.Collections.Generic;

namespace CybersecurityAwarenessBot
{
    public static class ActivityLogger
    {
        private static List<string> activities =
            new List<string>();

        public static void Log(string description)
        {
            string entry =
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                + " - " + description;

            activities.Add(entry);
        }

        public static List<string> GetRecentActivities(int count = 10)
        {
            int start = Math.Max(0, activities.Count - count);

            return activities.GetRange(
                start, activities.Count - start);
        }

        public static List<string> GetAllActivities()
        {
            return new List<string>(activities);
        }
    }
}