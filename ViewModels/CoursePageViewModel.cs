using AppliedActivity5.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedActivity5.ViewModels
{

    [QueryProperty(nameof(Course), nameof(Course))]
    public partial class CoursePageViewModel : ObservableObject
    {
        [ObservableProperty]
        Course course;
        [ObservableProperty]
        bool edit = false;
        [ObservableProperty]
        bool notEdit = false;

        public CoursePageViewModel()
        {
            course = new Course();
        }

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
    }
}
