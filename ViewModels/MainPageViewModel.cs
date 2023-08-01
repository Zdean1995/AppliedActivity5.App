using AppliedActivity5.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AppliedActivity5.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Student> students;
        [ObservableProperty]
        ObservableCollection<Course> courses;

        [ObservableProperty]
        bool isLoading = true;
        [ObservableProperty]
        bool courseEmpty = false;
        [ObservableProperty]
        bool studentsEmpty = false;

        public MainPageViewModel()
        {
            students = new ObservableCollection<Student>();
            courses = new ObservableCollection<Course>();
        }

        public async void LoadData()
        {
            List<Student> studentList = await App.SchoolRepo.GetAllStudents();
            if (studentList.Count == 0)
            {
                StudentsEmpty = false;
            }
            else
            {
                foreach (Student student in studentList)
                {
                    Students.Add(student);
                }
            }
            List<Course> courseList = await App.SchoolRepo.GetAllCourses();
            if (courseList.Count == 0)
            {
                CourseEmpty = false;
            }
            else
            {
                foreach (Course course in courseList)
                {
                    Courses.Add(course);
                }
            }
            IsLoading = false;
        }
    }
}
