using AppliedActivity5.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AppliedActivity5.ViewModels;

[QueryProperty(nameof(Student), nameof(Student))]
public partial class StudentPageViewModel : ObservableObject
{
    [ObservableProperty]
    Student student;
    [ObservableProperty]
    bool edit = false;
    [ObservableProperty]
    bool notEdit = false;

    [ObservableProperty]
    ObservableCollection<Course> courses;

    [ObservableProperty]
    Course selectedCourse;
    [ObservableProperty]
    bool isLoading = true;
    [ObservableProperty]
    bool courseEmpty = false;

    public StudentPageViewModel()
    {
        courses = new ObservableCollection<Course>();
        selectedCourse = new Course();
    }

    public async void LoadData()
    {
        if(Student.Name == null)
        {
            NotEdit = true;
        }
        else
        {
            Edit = true;
        }
        Courses = new ObservableCollection<Course>();
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
}