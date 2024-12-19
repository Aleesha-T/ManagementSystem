using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ManagementSystem.Commands;
using ManagementSystem.Model;

namespace ManagementSystem.ViewModel
{
    public class TeacherViewModel:BaseViewModel
    {
        public ObservableCollection<Student>Students { get; set; }
        public Student selectedStudent { get; set; }
        public string NewStudentId { get; set; }
        public string NewStudentName {  get; set; }
        public string TeacherId { get; set; }
        public int NewStudentScMarks {  get; set; }
        public int NewStudentEngMarks {  get; set; }
        public ICommand AddStudentCommand { get; }
        public ICommand DeleteStudentCommand { get; }
        public ICommand UpdateStudentCommand { get; }
        public TeacherViewModel(string teacherId) 
        {
            AddStudentCommand = new RelayCommand(AddStudent);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
            UpdateStudentCommand = new RelayCommand(UpdateStudent);
            TeacherId = teacherId;
            Students = new ObservableCollection<Student>(
                Data.Students.FindAll(s => s.TeacherId == teacherId));
        }

        private void UpdateStudent()
        {
            if (selectedStudent != null)
            {
                selectedStudent.Name = NewStudentName;
                selectedStudent.StudentId = NewStudentId;
                selectedStudent.Marks = new List<Mark> {new Mark{Subject="Science", Score=NewStudentScMarks},
                new Mark{Subject="English", Score=NewStudentEngMarks} };
                var index = Students.IndexOf(selectedStudent);
                Students[index] = selectedStudent;
                NewStudentId = string.Empty;
                NewStudentName = string.Empty;
                NewStudentScMarks = 0;
                NewStudentEngMarks = 0;
                OnPropertyChanged(nameof(NewStudentId));
                OnPropertyChanged(nameof(NewStudentName));
                OnPropertyChanged(nameof(NewStudentScMarks));
                OnPropertyChanged(nameof(NewStudentEngMarks));
            }
            else
            {
                MessageBox.Show("Select a student");
            }
        }

        private void DeleteStudent()
        {
            Students.Remove(selectedStudent);
        }

        private void AddStudent()
        {
            var newStudent = new Student
            {
                StudentId = NewStudentId,
                Name = NewStudentName,
                TeacherId = TeacherId,
                Marks = new List<Mark>{new Mark { Subject="Science", Score=NewStudentScMarks},
                         new Mark{Subject="English", Score= NewStudentEngMarks }}
            };
            Data.Students.Add(newStudent);
            Students.Add(newStudent);
            NewStudentId=string.Empty;
            NewStudentName=string.Empty;
            NewStudentScMarks = 0;
            NewStudentEngMarks = 0;
            OnPropertyChanged(nameof(NewStudentId));
            OnPropertyChanged(nameof(NewStudentName));
            OnPropertyChanged(nameof(NewStudentScMarks));
            OnPropertyChanged(nameof(NewStudentEngMarks));

        }
    }
}
