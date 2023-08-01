using AppliedActivity5.ViewModels;

namespace AppliedActivity5;

public partial class StudentPage : ContentPage
{
	public StudentPage(StudentPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}