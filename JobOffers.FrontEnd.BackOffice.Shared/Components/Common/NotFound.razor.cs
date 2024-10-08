﻿using Microsoft.AspNetCore.Components;

namespace JobOffers.FrontEnd.BackOffice.Shared.Components.Common
{
    public partial class NotFound : IComponent
    {
        [Inject]
        NavigationManager? NavigationManager { get; set; }
        private void GoHome()
        {
            NavigationManager?.NavigateTo("/");
        }
    }
}
