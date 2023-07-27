namespace AppliedActivity5;

public partial class App : Application
{
	public static SchoolRepository SchoolRepo { get; private set; }
	public App(SchoolRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		SchoolRepo = repo;
	}
}
