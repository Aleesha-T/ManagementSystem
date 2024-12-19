using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ManagementSystem.Commands;
using ManagementSystem.Model;

namespace ManagementSystem.ViewModel
{
    public class AdminViewModel:BaseViewModel
    {
        public ObservableCollection<Teacher> Teachers { get; set; }
        public ObservableCollection<Student> Students { get; set; }
        public string NewTeacherName {  get; set; }
        public string NewTeacherID {  get; set; }
        public ICommand AddTeacherCommand { get;}
        public AdminViewModel() 
        {
            Teachers = new ObservableCollection<Teacher>(Data.Teachers);
            Students = new ObservableCollection<Student>(Data.Students);
            AddTeacherCommand = new RelayCommand(AddTeacher);
        }
        private void AddTeacher()
        {
            var newTeacher = new Teacher
            {
                TeacherId = NewTeacherID,
                Name = NewTeacherName
            };
            Data.Teachers.Add(newTeacher);
            Teachers.Add(newTeacher);
            NewTeacherID = string.Empty;
            NewTeacherName = string.Empty;
            OnPropertyChanged(nameof(NewTeacherID));
            OnPropertyChanged(nameof(NewTeacherName));
        }
    }
}
