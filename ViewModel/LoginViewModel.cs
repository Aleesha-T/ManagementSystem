using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ManagementSystem.Commands;
using ManagementSystem.Model;
using ManagementSystem.View;

namespace ManagementSystem.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        public ObservableCollection<string> Roles { get; set; } = new ObservableCollection<string> { "Teacher", "Student", "Admin" };
        public string UserId { get; set; }
        public string Role {  get; set; }
        public RelayCommand LoginCommand { get; }
        public LoginViewModel() 
        {
            LoginCommand = new RelayCommand(Login);
        }
        private void Login()
        {
            var user = Data.Users.Find(x => x.UserId == UserId && x.Role.Equals(Role));
            if (user != null)
            {
                if (user.Role == "Teacher")
                {
                    var teacherView = new TeacherView { DataContext = new TeacherViewModel(UserId) };
                    teacherView.Show();
                }
                else if (user.Role == "Student")
                {
                    var studentView = new StudentView { DataContext = new StudentViewModel(UserId) };
                    studentView.Show();
                }
                else if(user.Role =="Admin")
                {
                    var adminView = new AdminView();
                    adminView.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid ID or Role. Please try again.");
            }
        }

    }
}
