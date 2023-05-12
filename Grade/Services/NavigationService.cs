using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        protected INavigation Navigation { get => Application.Current?.MainPage?.Navigation; }

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task NavigateToPage<T>() where T : Page
        {
            var page = ResolvePage<T>();
            if (page != null)
            {
                return Navigation.PushAsync(page, true);
            }
            throw new InvalidOperationException("Le type n'a pas pu être résolu");
        }

        private T? ResolvePage<T>() where T : Page
            => _serviceProvider.GetService<T>();
    }
}
