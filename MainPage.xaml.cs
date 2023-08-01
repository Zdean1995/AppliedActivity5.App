using AppliedActivity5.Models;
using AppliedActivity5.ViewModels;

namespace AppliedActivity5;

public partial class MainPage : ContentPage
{

    private MainPageViewModel _viewModel;
	public MainPage(MainPageViewModel vm)
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

