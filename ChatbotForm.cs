using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace CybersecurityAwarenessBot
{
    public class ChatbotForm : Form
    {
        private readonly TextBox txtChatHistory;
        private readonly TextBox txtUserInput;
        private readonly Button btnSend;
        private readonly Button btnClear;

        private SoundPlayer? greetingPlayer;
        private string userName = "friend";

        public ChatbotForm()
        {
            Text = "Cybersecurity Awareness Chatbot";
            Size = new Size(850, 650);
            MinimumSize = new Size(650, 500);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(240, 245, 250);
            Font = new Font("Segoe UI", 10);

            Label lblTitle = new Label
            {
                Text = "CYBERSECURITY AWARENESS CHATBOT",
                Dock = DockStyle.Top,
                Height = 45,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(25, 55, 90)
            };

            TextBox txtAsciiArt = new TextBox
            {
                Dock = DockStyle.Top,
                Height = 90,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.None,
                TextAlign = HorizontalAlignment.Center,
                BackColor = Color.FromArgb(230, 238, 247),
                ForeColor = Color.FromArgb(25, 55, 90),
                Font = new Font("Consolas", 9)
            };

            // Load ASCII art from the output folder if available.
            string artPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ascii-art.txt");

            if (File.Exists(artPath))
            {
                try
                {
                    txtAsciiArt.Text = File.ReadAllText(artPath);
                }
                catch (IOException)
                {
                    txtAsciiArt.Text = "Stay alert. Stay safe online.";
                }
            }
            else
            {
                txtAsciiArt.Text = "Stay alert. Stay safe online.";
            }

            txtChatHistory = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                WordWrap = true,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(35, 35, 35),
                Font = new Font("Segoe UI", 10),
                Margin = new Padding(10)
            };

            txtUserInput = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11),
                PlaceholderText = "Type your message here..."
            };

            btnSend = new Button
            {
                Text = "Send",
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(25, 100, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnClear = new Button
            {
                Text = "Clear Chat",
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(220, 228, 236),
                ForeColor = Color.FromArgb(25, 55, 90),
                FlatStyle = FlatStyle.Flat
            };

            btnSend.Click += BtnSend_Click;
            btnClear.Click += BtnClear_Click;

            txtUserInput.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    SendMessage();
                }
            };

            TableLayoutPanel inputPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 55,
                Padding = new Padding(8),
                ColumnCount = 3,
                RowCount = 1,
                BackColor = Color.FromArgb(240, 245, 250)
            };

            inputPanel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));
            inputPanel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 90));
            inputPanel.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 110));

            inputPanel.Controls.Add(txtUserInput, 0, 0);
            inputPanel.Controls.Add(btnSend, 1, 0);
            inputPanel.Controls.Add(btnClear, 2, 0);

            Controls.Add(txtChatHistory);
            Controls.Add(inputPanel);
            Controls.Add(txtAsciiArt);
            Controls.Add(lblTitle);

            ShowWelcomeMessage();
            PlayVoiceGreeting();
        }

        private void ShowWelcomeMessage()
        {
            txtChatHistory.AppendText(
                "Bot: Welcome to the Cybersecurity Awareness Chatbot!" +
                Environment.NewLine +
                "I can help you learn about passwords, phishing, scams, " +
                "privacy and safe browsing." +
                Environment.NewLine +
                "You can also ask for a tip or tell me how you feel." +
                Environment.NewLine +
                "Type 'help' to see what you can ask." +
                Environment.NewLine + Environment.NewLine);
        }

        private void PlayVoiceGreeting()
        {
            string audioPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "welcome.wav");

            if (!File.Exists(audioPath))
            {
                return;
            }

            try
            {
                greetingPlayer = new SoundPlayer(audioPath);
                greetingPlayer.Play();
            }
            catch (Exception)
            {
                // The chatbot should still work if audio cannot play.
            }
        }

        private void BtnSend_Click(object? sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            string input = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show(
                    "Please type a message before clicking Send.",
                    "Empty Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtUserInput.Focus();
                return;
            }

            txtChatHistory.AppendText(
                "You: " + input + Environment.NewLine);

            try
            {
                string response =
                    CybersecurityResponses.GetResponse(input, userName);

                txtChatHistory.AppendText(
                    "Bot: " + response +
                    Environment.NewLine + Environment.NewLine);

                // Keep the displayed conversation at the latest message.
                txtChatHistory.SelectionStart =
                    txtChatHistory.TextLength;
                txtChatHistory.ScrollToCaret();
            }
            catch (Exception)
            {
                txtChatHistory.AppendText(
                    "Bot: Sorry, something went wrong while processing " +
                    "your message. Please try again." +
                    Environment.NewLine + Environment.NewLine);
            }

            txtUserInput.Clear();
            txtUserInput.Focus();
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            txtChatHistory.Clear();
            ShowWelcomeMessage();
            txtUserInput.Clear();
            txtUserInput.Focus();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            greetingPlayer?.Stop();
            greetingPlayer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}