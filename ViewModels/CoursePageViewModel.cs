using AppliedActivity5.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedActivity5.ViewModels
{
    //This class is used as a viewmodel for the Course Page.  It takes in a course given to it by the main page
    [QueryProperty(nameof(Course), nameof(Course))]
    public partial class CoursePageViewModel : ObservableObject
    {
        //The course being added or edited
        [ObservableProperty]
        Course course;
        //the booleans are used to tell the UI if the course is being added or edited
        [ObservableProperty]
        bool edit = false;
        [ObservableProperty]
        bool notEdit = false;

        public CoursePageViewModel()
        {
            course = new Course();
        }

        //This command is used to set the mode of the page
        public void LoadData()
        {
            if (Course.Name == null)
            {
                NotEdit = true;
            }
            else
            {
                Edit = true;
            }
        }
        //The commands are used to save or add the course to the database
        [RelayCommand]
        public async Task SaveCourse()
        {
            await App.SchoolRepo.UpdateCourse(Course);
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        public async Task AddCourse()
        {
            await App.SchoolRepo.AddNewCourse(Course);
            await Shell.Current.GoToAsync("..");
        }
    }
}
