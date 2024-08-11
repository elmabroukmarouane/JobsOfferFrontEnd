using Microsoft.AspNetCore.Components;

namespace JobOffers.FrontEnd.BackOffice.Shared.Components.Pages.Authentication
{
    public partial class LoginRedirect : IComponent
    {
        [Inject]
        NavigationManager? NavigationManager { get; set; }
        protected override void OnInitialized()
        {
            NavigationManager!.NavigateTo("/login");
        }
    }
}
