﻿using JobOffers.Frontend.Busines.Services.Interface;
using JobOffers.Frontend.Domain.Settings;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace JobOffers.FrontEnd.BackOffice.Shared.Components.Layout
{
	public partial class MainLayout : IComponent
    {
        [Inject]
        private IJSRuntime? JSRuntime { get; set; }
        [Inject]
        private ITitleService? TitleService { get; set; }
        [Inject]
        private BaseSettingsApp? BaseSettingApp { get; set; }
        protected override async Task OnInitializedAsync() => await TitleService!.SetTitlePage(BaseSettingApp!.BaseTitleApp);

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime!.InvokeVoidAsync("initAdminTemplate");
            }
        }
    }
}
