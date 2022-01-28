using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace AuthenticationForm
{
    internal sealed partial class MainWindow : Window
    {
        private List<User> users;
        private User user;
        private string users_path = "Users.txt";

        public MainWindow()
        {
            InitializeComponent();
            users = new List<User>();
            users = Loading_users();
        }

        private List<User> Loading_users()
        {
            List<User> new_users = new List<User> { };
            using (StreamReader sr = new StreamReader(users_path, System.Text.Encoding.Default))
            {
                string line;
                string[] lines = new string[2];
                int i = 0;
                User new_user = null;
                while ((line = sr.ReadLine()) != null)
                {
                    lines[i] = line;
                    i++;
                    if (i == 2)
                    {
                        new_user = new User(lines[0], lines[1]);
                        new_users.Add(new_user);
                        i = 0;
                    }
                }
            }
            return new_users;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            bool name_coicidence = false;
            bool pass_coicidence = false;
            if (Username.Text != "" && Password.Text != "")
            {
                user = new User(Username.Text, Password.Text);
                foreach (User lists_user in users)
                    if (user.Name == lists_user.Name)
                    {
                        name_coicidence = true;
                        if (user.Password == lists_user.Password)
                        {
                            pass_coicidence = true;
                            MessageBox.Show($"Dear {user.Name} the password is correct. Welcome!", "Congratulation", MessageBoxButton.OK);
                            Username.Text = "";
                            Password.Text = "";
                            break;
                        }
                    }
                if (name_coicidence == false)
                {
                    Message("name");
                    return;
                }
                if (pass_coicidence == false)
                {
                    Message("password");
                    return;
                }
            }
            else
                Message();
        }

        private void Message(string text)
        {
            MessageBox.Show($"Dear user, Your {text} is incorrect!", "Warning message", MessageBoxButton.OK);
            Username.Text = "";
            Password.Text = "";
        }

        private void Message()
        {
            MessageBox.Show($"Dear user, You didn't filled name and/or password!", "Warning message", MessageBoxButton.OK);
            Username.Text = "";
            Password.Text = "";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}