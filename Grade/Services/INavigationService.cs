using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade.Services
{
    public interface INavigationService
    {
        public Task NavigateToPage<T>() where T : Page;
    }
}
