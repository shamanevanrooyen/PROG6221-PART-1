using System;
using System.Windows.Forms;

namespace CybersecurityAwarenessBot
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Open the Cybersecurity Awareness Chatbot window
            Application.Run(new ChatbotForm());
        }
    }
}