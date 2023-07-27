using AppliedActivity5.Models;

namespace AppliedActivity5;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void GetData(object sender, EventArgs args)
	{
		List<Student> student = await App.SchoolRepo.GetAllStudents();
		studentList.ItemsSource = student;


        List<Course> courses = await App.SchoolRepo.GetAllCourses();
		CourseList.ItemsSource = courses;
	}
}

