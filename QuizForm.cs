using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CybersecurityAwarenessBot
{
    public class QuizForm : Form
    {
        private class Question
        {
            public string Text { get; set; }
            public string[] Options { get; set; }
            public int CorrectAnswer { get; set; }
            public string Explanation { get; set; }

            public Question(string text, string[] options,
                int correctAnswer, string explanation)
            {
                Text = text;
                Options = options;
                CorrectAnswer = correctAnswer;
                Explanation = explanation;
            }
        }

        private List<Question> questions;
        private int currentQuestion = 0;
        private int score = 0;
        private bool answered = false;

        private Label lblQuestion;
        private Label lblProgress;
        private Label lblFeedback;
        private RadioButton[] answerButtons;
        private Button btnNext;

        public QuizForm()
        {
            Text = "Cybersecurity Awareness Quiz";
            Size = new Size(700, 480);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;

            LoadQuestions();
            ActivityLogger.Log("Started cybersecurity quiz.");

            lblProgress = new Label
            {
                Location = new Point(30, 20),
                Size = new Size(600, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            lblQuestion = new Label
            {
                Location = new Point(30, 65),
                Size = new Size(620, 65),
                Font = new Font("Segoe UI", 13, FontStyle.Bold)
            };

            answerButtons = new RadioButton[4];

            for (int i = 0; i < 4; i++)
            {
                answerButtons[i] = new RadioButton
                {
                    Location = new Point(40, 145 + (i * 40)),
                    Size = new Size(600, 35),
                    Font = new Font("Segoe UI", 11),
                    AutoSize = false
                };

                answerButtons[i].CheckedChanged +=
                    AnswerButton_CheckedChanged;

                Controls.Add(answerButtons[i]);
            }

            lblFeedback = new Label
            {
                Location = new Point(30, 315),
                Size = new Size(620, 55),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.DarkBlue
            };

            btnNext = new Button
            {
                Text = "Next Question",
                Location = new Point(500, 380),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(25, 100, 160),
                ForeColor = Color.White
            };

            btnNext.Click += BtnNext_Click;

            Controls.Add(lblProgress);
            Controls.Add(lblQuestion);
            Controls.Add(lblFeedback);
            Controls.Add(btnNext);

            DisplayQuestion();
        }

        private void LoadQuestions()
        {
            questions = new List<Question>
            {
                new Question(
                    "1. What is phishing?",
                    new[] {
                        "A type of computer",
                        "A fraudulent attempt to steal information",
                        "A safe website",
                        "An antivirus program"
                    }, 1,
                    "Phishing tricks people into sharing private information."),

                new Question(
                    "2. Should you share your password with strangers?",
                    new[] { "True", "False" }, 1,
                    "Passwords should always remain private."),

                new Question(
                    "3. Which password is strongest?",
                    new[] {
                        "123456",
                        "password",
                        "John123",
                        "T!ger#92Blue"
                    }, 3,
                    "A strong password uses a mixture of characters."),

                new Question(
                    "4. What should you do with a suspicious email link?",
                    new[] {
                        "Click immediately",
                        "Forward it to everyone",
                        "Avoid clicking and verify the sender",
                        "Enter your password"
                    }, 2,
                    "Always verify suspicious messages before clicking links."),

                new Question(
                    "5. Is it safe to use the same password everywhere?",
                    new[] { "True", "False" }, 1,
                    "Different passwords protect your other accounts if one is compromised."),

                new Question(
                    "6. What does antivirus software do?",
                    new[] {
                        "Creates passwords",
                        "Detects and helps remove malicious software",
                        "Increases internet speed",
                        "Sends emails"
                    }, 1,
                    "Antivirus software helps detect and remove malware."),

                new Question(
                    "7. What is two-factor authentication?",
                    new[] {
                        "Using two computers",
                        "Having two email accounts",
                        "An extra identity verification step",
                        "Sharing your password twice"
                    }, 2,
                    "Two-factor authentication adds another layer of security."),

                new Question(
                    "8. Should you install updates for security?",
                    new[] { "True", "False" }, 0,
                    "Updates often fix security weaknesses."),

                new Question(
                    "9. What is malware?",
                    new[] {
                        "A computer game",
                        "Malicious software designed to cause harm",
                        "A search engine",
                        "A safe application"
                    }, 1,
                    "Malware includes viruses, spyware and ransomware."),

                new Question(
                    "10. What should you do on public Wi-Fi?",
                    new[] {
                        "Access all banking sites without protection",
                        "Share personal information",
                        "Be cautious and avoid sensitive activities",
                        "Disable all security"
                    }, 2,
                    "Public Wi-Fi may expose your information to attackers."),

                new Question(
                    "11. Is it safe to open unknown email attachments?",
                    new[] { "True", "False" }, 1,
                    "Unknown attachments may contain harmful software."),

                new Question(
                    "12. What is social engineering?",
                    new[] {
                        "Building computer networks",
                        "Manipulating people into revealing information",
                        "Installing software",
                        "Creating websites"
                    }, 1,
                    "Social engineering uses deception to manipulate people.")
            };
        }

        private void DisplayQuestion()
        {
            answered = false;

            Question q = questions[currentQuestion];

            lblProgress.Text =
                "Question " + (currentQuestion + 1) +
                " of " + questions.Count +
                "     Score: " + score;

            lblQuestion.Text = q.Text;
            lblFeedback.Text = "";

            for (int i = 0; i < 4; i++)
            {
                answerButtons[i].Checked = false;
                answerButtons[i].Enabled = true;

                if (i < q.Options.Length)
                {
                    answerButtons[i].Text = q.Options[i];
                    answerButtons[i].Visible = true;
                }
                else
                {
                    answerButtons[i].Visible = false;
                }
            }

            btnNext.Enabled = false;
            btnNext.Text = "Next Question";
        }

        private void AnswerButton_CheckedChanged(
            object sender, EventArgs e)
        {
            if (answered) return;

            RadioButton selected = sender as RadioButton;

            if (selected == null || !selected.Checked)
                return;

            answered = true;

            int selectedAnswer =
                Array.IndexOf(answerButtons, selected);

            Question q = questions[currentQuestion];

            if (selectedAnswer == q.CorrectAnswer)
            {
                score++;

                lblFeedback.Text =
                    "CORRECT! " + q.Explanation;

                lblFeedback.ForeColor = Color.Green;
            }
            else
            {
                lblFeedback.Text =
                    "INCORRECT. Correct answer: " +
                    q.Options[q.CorrectAnswer] +
                    ". " + q.Explanation;

                lblFeedback.ForeColor = Color.Red;
            }

            foreach (RadioButton button in answerButtons)
                button.Enabled = false;

            btnNext.Enabled = true;

            if (currentQuestion == questions.Count - 1)
                btnNext.Text = "See Final Score";
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (!answered) return;

            if (currentQuestion < questions.Count - 1)
            {
                currentQuestion++;
                DisplayQuestion();
            }
            else
            {
                lblProgress.Text = "QUIZ COMPLETED";
                ActivityLogger.Log(
    "Completed cybersecurity quiz. Score: " +
    score + " out of " + questions.Count);

                lblQuestion.Text =
                    "Your final score is " + score +
                    " out of " + questions.Count + ".";

                lblFeedback.Text =
                    score >= 9
                    ? "Excellent work! You understand cybersecurity well."
                    : "Good effort! Keep learning about online safety.";

                foreach (RadioButton button in answerButtons)
                    button.Visible = false;

                btnNext.Text = "Close";
                btnNext.Click -= BtnNext_Click;
                btnNext.Click += (s, args) => Close();
            }
        }
    }
}