// VoiceGreeting.cs
// This class plays the recorded WAV greeting when the application starts.

using System;
using System.IO;
using System.Media;

namespace CybersecurityAwarenessBot
{
    public static class VoiceGreeting
    {
        // Name of the voice file.
        private static readonly string VoiceFile =
            Path.Combine(AppContext.BaseDirectory, "welcome.wav");

        // Plays the recorded voice greeting.
        public static void Play()
        {
            try
            {
                // Check if the WAV file exists.
                if (File.Exists(VoiceFile))
                {
                    using SoundPlayer player = new SoundPlayer(VoiceFile);

                    // Load and play the WAV file.
                    player.Load();
                    player.PlaySync();
                }
                else
                {
                    // If the WAV file is missing, the program still continues.
                    Console.WriteLine("Voice greeting file was not found.");
                }
            }
            catch (Exception)
            {
                // Prevent the application from crashing if there is an audio problem.
                Console.WriteLine("The voice greeting could not be played.");
            }
        }
    }
}