using Grade.Models.Config;
using Grade.Models.Metier;
using Grade.Services;
using Microsoft.Extensions.Configuration;

namespace Grade;

public partial class MainPage : ContentPage
{
	private readonly IConfiguration _configuration;
	private readonly INavigationService _navigationService;

    public MainPage(IConfiguration configuration, IServiceProvider serviceProvider, INavigationService navigationService)
    {
        InitializeComponent();
        _configuration = configuration;
        _navigationService = navigationService;
    }

    private void OnNouvellePartieClick(object sender, EventArgs e)
	{
		IEnumerable<GradeNomImage> gradeNomImages = _configuration.GetRequiredSection("GradeNomImage").Get<IEnumerable<GradeNomImage>>();
		//var page = _serviceProvider.GetService<PartiePage>();
		_navigationService.NavigateToPage<PartiePage>();
		
	}
}

