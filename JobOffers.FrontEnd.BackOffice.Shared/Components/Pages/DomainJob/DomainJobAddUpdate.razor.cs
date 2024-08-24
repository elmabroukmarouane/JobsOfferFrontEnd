using JobOffers.Frontend.Busines.Services.Interface;
using JobOffers.Frontend.Domain.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JobOffers.FrontEnd.BackOffice.Shared.Components.Pages.DomainJob
{
    public partial class DomainJobAddUpdate : ComponentBase
    {
        private bool Success { get; set; } = true;
        private string[] Errors { get; set; } = [];
        private MudForm? Form { get; set; }
        [CascadingParameter]
        private MudDialogInstance? MudDialog { get; set; }
        [Parameter]
        public DomainJobViewModel? DomainJobViewModel { get; set; }
        [Parameter]
        public string? TitleOkButton { get; set; }
        [Parameter]
        public bool IsUpdate { get; set; }
        [Parameter]
        public string? Uri { get; set; }
        [Parameter]
        public string? Token { get; set; }
        [Inject]
        protected IGenericService<DomainJobViewModel>? GenericService { get; set; }
        private void Cancel() => MudDialog?.Cancel();
        private async Task Ok()
        {
            var domainJobViewModelResponse = new DomainJobViewModel();
            if (IsUpdate)
            {
                domainJobViewModelResponse = await GenericService!.UpdateAsync(Uri!, Token, DomainJobViewModel!);
            }
            else
            {
                domainJobViewModelResponse = await GenericService!.CreateAsync(Uri!, Token, DomainJobViewModel!);
            }
            if (Success || Errors.Count() <= 0) MudDialog?.Close(DialogResult.Ok(new EntityDbResponse<DomainJobViewModel>()
            {
                IsSuccess = true,
                MessageStatus = domainJobViewModelResponse?.StatusCode == System.Net.HttpStatusCode.OK ? 
                new MessageStatus()
                {
                    StatusCode = domainJobViewModelResponse?.StatusCode,
                    Message = "Entity " + (IsUpdate ? "updated" : "added") + " successfully"
                } :
                new MessageStatus()
                {
                    StatusCode = domainJobViewModelResponse?.StatusCode,
                    Message = (IsUpdate ? "Updated" : "Added") + " Failed !"
                },
                Entity = domainJobViewModelResponse
            }));
        }

    }
}
