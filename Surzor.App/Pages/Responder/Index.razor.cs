using Microsoft.AspNetCore.Components;
using Surzor.App.Contracts;
using Surzor.App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Surzor.App.Pages.Responder
{
    public partial class Index
    {
        [Inject]
        public IResponderDataService Service { get; set; }

        public ICollection<ResponderListViewModel> Responders { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Responders = await Service.GetAllResponders();
        }

    }
}
