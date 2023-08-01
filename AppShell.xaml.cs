namespace AppliedActivity5;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(StudentPage), typeof(StudentPage));

        Routing.RegisterRoute(nameof(CoursePage), typeof(CoursePage));
    }
}
