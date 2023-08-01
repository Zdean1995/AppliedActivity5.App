using AppliedActivity5.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AppliedActivity5.ViewModels;

//This class is used as a view model for the student page.  It takes in a student passed to is by the main page
[QueryProperty(nameof(Student), nameof(Student))]
public partial class StudentPageViewModel : ObservableObject
{
    //The student being edited or added
    [ObservableProperty]
    Student student;
    //These booleans tell the ui which mode the page is in
    [ObservableProperty]
    bool edit = false;
    [ObservableProperty]
    bool notEdit = false;

    //Since courses and students have a one to many relationship, the list of courses needs to be gotten inorded to assign a student to a course
    //that is what this list is used for
    [ObservableProperty]
    ObservableCollection<Course> courses;

    //The course selected for the picker
    [ObservableProperty]
    Course selectedCourse;
    //this boolean is used to tell the ui that there are no courses in the database
    [ObservableProperty]
    bool courseEmpty = false;

    public StudentPageViewModel()
    {
        courses = new ObservableCollection<Course>();
        selectedCourse = new Course();
    }

    public async void LoadData()
    {
        //The check for what mode the page is in
        if(Student.Name == null)
        {
            NotEdit = true;
        }
        else
        {
            Edit = true;
        }
        //getting the list of courses from the database
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
        //setting the course in the picker to the one that the student is assigned to if the page is in edit mode
        if (Edit)
        {
            SelectedCourse = courseList.Find(x => x.Id == Student.CourseId);
        }
    }

    //these commands are used to save and add the student to the database.
    [RelayCommand]
    public async Task SaveStudent()
    {
        Student.CourseId = SelectedCourse.Id;
        await App.SchoolRepo.UpdateStudent(Student);
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    public async Task AddStudent()
    {
        Student.CourseId = SelectedCourse.Id;
        await App.SchoolRepo.AddNewStudent(Student);
        await Shell.Current.GoToAsync("..");
    }
}