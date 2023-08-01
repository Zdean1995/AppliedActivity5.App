using AppliedActivity5.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AppliedActivity5.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        //The list of students from the database
        [ObservableProperty]
        ObservableCollection<Student> students;
        //The list of courses from the database
        [ObservableProperty]
        ObservableCollection<Course> courses;

        //A boolean used for telling the ui that the data is still loading
        [ObservableProperty]
        bool isLoading = true;
        //A boolean used for telling the ui that no courses are in the database
        [ObservableProperty]
        bool courseEmpty = false;
        //A boolean used for telling the ui that no students are in the database
        [ObservableProperty]
        bool studentsEmpty = false;

        public MainPageViewModel()
        {
            //Initializing the lists.
            students = new ObservableCollection<Student>();
            courses = new ObservableCollection<Course>();
        }

        public async void LoadData()
        {
            //clearing the lists before retrieveing data
            Students = new ObservableCollection<Student>();
            Courses = new ObservableCollection<Course>();

            //The following gets the list of students from the database, then it checks if the list is empty
            //if it is it sets the value of studentsempty to true, otherwise it sets it to false and adds each
            //of the students to the list that will be displayed.  The same is done with courses.
            List<Student> studentList = await App.SchoolRepo.GetAllStudents();
            if (studentList.Count == 0)
            {
                StudentsEmpty = true;
            }
            else
            {
                StudentsEmpty = false;
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
                CourseEmpty = false;
                foreach (Course course in courseList)
                {
                    Courses.Add(course);
                }
            }
            //sets loading to false to tell the ui the data is loaded
            IsLoading = false;
        }
        //This command navigates to the student page with a student that will be edited
        [RelayCommand]
        async Task EditStudent(Student student)
        {
            await Shell.Current.GoToAsync($"{nameof(StudentPage)}",
                new Dictionary<string, object>
                {
                    {nameof(Student), student}
                } );
        }
        //This command navigates to the student page with a new student object that will be added to the databae
        [RelayCommand]
        async Task AddStudent()
        {
            await Shell.Current.GoToAsync($"{nameof(StudentPage)}",
                new Dictionary<string, object>
                {
                    {nameof(Student), new Student()}
                });
        }

        //this command tells the repo to delete the selected student
        [RelayCommand]
        async Task DeleteStudent(Student student)
        {
            await App.SchoolRepo.DeleteStudent(student);
            LoadData();
        }
        //the following commands are the same as above but for courses.
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
            LoadData();
        }

    }
}
