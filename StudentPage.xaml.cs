using AppliedActivity5.ViewModels;

namespace AppliedActivity5;

public partial class StudentPage : ContentPage
{
	private StudentPageViewModel _viewModel;
	public StudentPage(StudentPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		_viewModel = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadData();
		if(_viewModel.CourseEmpty)
		{
			coursePicker.Title = "No courses found";
		}
    }
}