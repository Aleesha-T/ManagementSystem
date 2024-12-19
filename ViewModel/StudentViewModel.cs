using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Model;

namespace ManagementSystem.ViewModel
{
    public class StudentViewModel:BaseViewModel
    {
        public ObservableCollection<Mark> Marks { get;}
        public string StudentName {  get; set; }
        public StudentViewModel(string studentId)
        {
            var student = Data.Students.Find(s=>s.StudentId == studentId);
            StudentName= $"Welcome, {student.Name}";
            Marks = new ObservableCollection<Mark>(student?.Marks ?? new List<Mark>());
        }
    }
}
