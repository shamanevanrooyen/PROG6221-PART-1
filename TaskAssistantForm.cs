using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CybersecurityAwarenessBot
{
    public class TaskAssistantForm : Form
    {
        TextBox txtTitle = new TextBox();
        TextBox txtDescription = new TextBox();
        DateTimePicker dtReminder = new DateTimePicker();
        CheckBox chkReminder = new CheckBox();
        DataGridView gridTasks = new DataGridView();

        public TaskAssistantForm()
        {
            Text = "Cybersecurity Task Assistant";
            Size = new Size(850, 600);
            StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label
            {
                Text = "Task Title:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtTitle.Location = new Point(130, 17);
            txtTitle.Width = 250;

            Label lblDescription = new Label
            {
                Text = "Description:",
                Location = new Point(20, 60),
                AutoSize = true
            };

            txtDescription.Location = new Point(130, 57);
            txtDescription.Width = 250;

            chkReminder.Text = "Set reminder";
            chkReminder.Location = new Point(130, 100);
            chkReminder.AutoSize = true;

            dtReminder.Location = new Point(250, 98);
            dtReminder.Width = 200;
            dtReminder.Format = DateTimePickerFormat.Custom;
            dtReminder.CustomFormat = "yyyy-MM-dd HH:mm";
            dtReminder.ShowUpDown = true;

            Button btnAdd = new Button
            {
                Text = "Add Task",
                Location = new Point(20, 145),
                Width = 100
            };

            Button btnRefresh = new Button
            {
                Text = "Refresh",
                Location = new Point(130, 145),
                Width = 100
            };

            Button btnComplete = new Button
            {
                Text = "Mark Completed",
                Location = new Point(240, 145),
                Width = 130
            };

            Button btnDelete = new Button
            {
                Text = "Delete Task",
                Location = new Point(380, 145),
                Width = 110
            };

            gridTasks.Location = new Point(20, 200);
            gridTasks.Size = new Size(790, 330);
            gridTasks.ReadOnly = true;
            gridTasks.AllowUserToAddRows = false;
            gridTasks.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            gridTasks.MultiSelect = false;
            gridTasks.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            Controls.AddRange(new Control[]
            {
                lblTitle, txtTitle,
                lblDescription, txtDescription,
                chkReminder, dtReminder,
                btnAdd, btnRefresh,
                btnComplete, btnDelete,
                gridTasks
            });

            btnAdd.Click += BtnAdd_Click;
            btnRefresh.Click += (s, e) => LoadTasks();
            btnComplete.Click += BtnComplete_Click;
            btnDelete.Click += BtnDelete_Click;

            LoadTasks();
        }

        private void LoadTasks()
        {
            try
            {
                using (MySqlConnection connection =
                    new DatabaseHelper().GetConnection())
                {
                    connection.Open();

                    string sql =
                        "SELECT task_id, title, description, " +
                        "reminder_date, status, created_at " +
                        "FROM tasks ORDER BY task_id DESC";

                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        gridTasks.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load tasks: " + ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Enter a task title and description.");
                return;
            }

            try
            {
                using (MySqlConnection connection =
                    new DatabaseHelper().GetConnection())
                {
                    connection.Open();

                    string sql =
                        "INSERT INTO tasks " +
                        "(title, description, reminder_date, status) " +
                        "VALUES (@title, @description, @reminder, 'Pending')";

                    using (MySqlCommand command =
                        new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@title", txtTitle.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@description", txtDescription.Text.Trim());

                        command.Parameters.AddWithValue(
                            "@reminder",
                            chkReminder.Checked
                                ? (object)dtReminder.Value
                                : DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
                ActivityLogger.Log("Added task: " + txtTitle.Text);
                MessageBox.Show("Task added successfully!");

                txtTitle.Clear();
                txtDescription.Clear();
                chkReminder.Checked = false;

                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add task: " + ex.Message);
            }
        }

        private int GetSelectedTaskId()
        {
            if (gridTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task first.");
                return -1;
            }

            return Convert.ToInt32(
                gridTasks.SelectedRows[0].Cells["task_id"].Value);
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedTaskId();
            if (id == -1) return;

            UpdateTaskStatus(id);
        }

        private void UpdateTaskStatus(int id)
        {
            try
            {
                using (MySqlConnection connection =
                    new DatabaseHelper().GetConnection())
                {
                    connection.Open();

                    string sql =
                        "UPDATE tasks SET status = 'Completed' " +
                        "WHERE task_id = @id";

                    using (MySqlCommand command =
                        new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                ActivityLogger.Log("Marked task " + id + " as completed.");
                MessageBox.Show("Task marked as completed!");
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update task: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedTaskId();
            if (id == -1) return;

            DialogResult answer = MessageBox.Show(
                "Are you sure you want to delete this task?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);

            if (answer != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection connection =
                    new DatabaseHelper().GetConnection())
                {
                    connection.Open();

                    string sql =
                        "DELETE FROM tasks WHERE task_id = @id";

                    using (MySqlCommand command =
                        new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                ActivityLogger.Log("Deleted task " + id + ".");
                MessageBox.Show("Task deleted!");
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete task: " + ex.Message);
            }
        }
    }
}