using AppliedActivity5.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
            Students = new ObservableCollection<Student>();
            Courses = new ObservableCollection<Course>();
            List<Student> studentList = await App.SchoolRepo.GetAllStudents();
            if (studentList.Count == 0)
            {
                StudentsEmpty = true;
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
                CourseEmpty = true;
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

        [RelayCommand]
        async Task EditStudent(Student student)
        {
            await Shell.Current.GoToAsync($"{nameof(StudentPage)}",
                new Dictionary<string, object>
                {
                    {nameof(Student), student}
                } );
        }
        [RelayCommand]
        async Task AddStudent()
        {
            await Shell.Current.GoToAsync($"{nameof(StudentPage)}",
                new Dictionary<string, object>
                {
                    {nameof(Student), new Student()}
                });
        }

        [RelayCommand]
        async Task DeleteStudent(Student student)
        {
            await App.SchoolRepo.DeleteStudent(student);
            Students.Remove(student);
        }

        [RelayCommand]
        async Task EditCourse(Course course)
        {
            await Shell.Current.GoToAsync($"{nameof(CoursePage)}",
                new Dictionary<string, object>
                {
                    {nameof(Course), course}
                });
        }
        [RelayCommand]
        async Task AddCourse()
        {
            await Shell.Current.GoToAsync($"{nameof(CoursePage)}",
                new Dictionary<string, object>
                {
                    {nameof(Course), new Course()}
                });
        }

        [RelayCommand]
        async Task DeleteCourse(Course course)
        {
            await App.SchoolRepo.DeleteCourse(course);
            Courses.Remove(course);
        }

    }
}
