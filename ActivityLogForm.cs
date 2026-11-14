using System;
using System.Drawing;
using System.Windows.Forms;

namespace CybersecurityAwarenessBot
{
    public class ActivityLogForm : Form
    {
        private ListBox lstActivities;
        private bool showAll = false;

        public ActivityLogForm()
        {
            Text = "Chatbot Activity Log";
            Size = new Size(700, 450);
            StartPosition = FormStartPosition.CenterScreen;

            Label heading = new Label
            {
                Text = "YOUR CHATBOT ACTIVITY",
                Location = new Point(20, 15),
                Size = new Size(600, 35),
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };

            lstActivities = new ListBox
            {
                Location = new Point(20, 60),
                Size = new Size(640, 280),
                Font = new Font("Segoe UI", 10)
            };

            Button btnMore = new Button
            {
                Text = "Show All Activities",
                Location = new Point(20, 355),
                Size = new Size(170, 35)
            };

            btnMore.Click += (sender, e) =>
            {
                showAll = !showAll;
                btnMore.Text = showAll
                    ? "Show Last 10"
                    : "Show All Activities";

                LoadActivities();
            };

            Controls.Add(heading);
            Controls.Add(lstActivities);
            Controls.Add(btnMore);

            LoadActivities();
        }

        private void LoadActivities()
        {
            lstActivities.Items.Clear();

            var activities = showAll
                ? ActivityLogger.GetAllActivities()
                : ActivityLogger.GetRecentActivities(10);

            foreach (string activity in activities)
            {
                lstActivities.Items.Add(activity);
            }

            if (lstActivities.Items.Count == 0)
                lstActivities.Items.Add("No activities recorded yet.");
        }
    }
}