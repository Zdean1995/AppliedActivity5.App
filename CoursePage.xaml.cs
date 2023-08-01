using AppliedActivity5.ViewModels;

namespace AppliedActivity5;

public partial class CoursePage : ContentPage
{
    private CoursePageViewModel _viewModel;
    public CoursePage(CoursePageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadData();
    }
}