using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ManagementSystem.Model
{
    public class User
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
    public class Teacher
    {
        public string TeacherId { get; set; }
        public string Name { get; set; }
    }
    public class Student:INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private List<Mark> _marks;
        public string StudentId
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }      

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string TeacherId { get; set; }
        public List<Mark> Marks
        {
            get => _marks;
            set
            {
                _marks = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Mark
    {
        public string Subject { get; set; }
        public int Score { get; set; }
    }
    public static class Data
    {
        public static List<User> Users = new List<User>()
        {
            new User{UserId="T1", Role="Teacher"},
            new User{UserId="S1", Role="Student"},
            new User{UserId="S2", Role="Student"},
            new User{UserId="A1", Role="Admin"}
        };
        public static List<Teacher> Teachers = new List<Teacher>
        {
            new Teacher { TeacherId = "T1", Name = "Mr. Smith" }
        };
        public static List<Student> Students = new List<Student>
        {
            new Student
            {
                StudentId = "S1",
                Name = "Mary Jane",
                TeacherId = "T1",
                Marks = new List<Mark>
                {
                    new Mark { Subject = "Science", Score = 80 },
                    new Mark { Subject = "English", Score = 95 }
                }
            },
            new Student
            {
                StudentId = "S2",
                Name = "Peter Parker",
                TeacherId = "T1",
                Marks = new List<Mark>
                {
                    new Mark { Subject = "Science", Score = 100 },
                    new Mark { Subject = "English", Score = 90 }
                }
            }
        };
    }
}
