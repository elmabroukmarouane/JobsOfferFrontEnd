using Blazored.LocalStorage;
using JobOffers.Frontend.Busines.Services.Interface;
using JobOffers.Frontend.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using JobOffers.FrontEnd.BackOffice.Shared.Components.Extensions.LocalStorage;
using JobOffers.Frontend.Domain.Settings;
using Radzen;
using Radzen.Blazor;
using MudBlazor;
using static MudBlazor.CategoryTypes;
using CurrieTechnologies.Razor.SweetAlert2;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JobOffers.FrontEnd.BackOffice.Shared.Components.Pages.DomainJob
{
    [Authorize]
    public partial class DomainJobIndex : IComponent, IDisposable
    {
        //[Inject]
        //ILocalStorageService? LocalStorageService { get; set; }
        //[Inject]
        //protected IGenericService<DomainJobViewModel>? GenericService { get; set; }
        [Inject]
        private IJSRuntime? JSRuntime { get; set; }
        //public static IList<DomainJobViewModel>? InitialDomainJobs { get; set; }
        //public static IList<DomainJobViewModel>? DomainJobs { get; set; }
        [Inject]
        private BaseSettingsApp? BaseSettingsApp { get; set; }
        private string? TitleContent { get; set; }
        [Inject]
        ILocalStorageService? LocalStorageService { get; set; }
        [Inject]
        protected IGenericService<DomainJobViewModel>? GenericService { get; set; }
        [Inject]
        TooltipService? TooltipService { get; set; }
        [Inject]
        private SweetAlertService? Swal { get; set; }
        private string TitleSwalTitle { get; set; } = string.Empty;
        private string MessageSwalTitle { get; set; } = string.Empty;
        //private SweetAlertIcon? SweetAlertIcon { get; set; }
        //public static IList<DomainJobViewModel>? InitialItems { get; set; }
        public static IList<DomainJobViewModel>? Items { get; set; }
        //public RadzenDataGrid<DomainJobViewModel>? DomainJobGrid { get; set; }
        public bool IsLoading { get; set; } = false;
        public int Count = 0;
        //private IEnumerable<int> PageSizeOptions = new int[] { 10, 25, 50, 100 };
        //private string PagingSummaryFormat = "Displaying page {0} of {1} (total {2} records)";
        //private Modal? ModalAddUpdate { get; set; }
        private RadzenFieldset? RadzenFieldsetUpload { get; set; }
        private RadzenFieldset? RadzenFieldsetDataGrid { get; set; }
        private DomainJobViewModel SelectedItem { get; set; } = new();
        private HashSet<DomainJobViewModel>? SelectedItems { get; set; }
        //private bool IsBusy { get; set; } = false;
        //private string TitleModal { get; set; } = string.Empty;
        //private string SubmitButtonModal { get; set; } = string.Empty;
        private bool IsUpdate { get; set; } = false;
        //private DomainJobViewModel? DomainJobToInsert { get; set; } = new();
        //private DomainJobViewModel? DomainJobToUpdate { get; set; } = new();
        public string? TableSearchString { get; set; } = string.Empty;
        public string? Token { get; set; }
        [Inject]
        IDialogService? DialogService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            TitleContent = BaseSettingsApp?.BaseTitleApp + " - Domain Jobs";
            Token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoie1wiUHJvZmlsSWRcIjoxMzYsXCJFbWFpbFwiOlwidXNlcjFAdGVzdC5jb21cIixcIlBhc3N3b3JkXCI6XCJcIixcIklzT25MaW5lXCI6dHJ1ZSxcIlByb2ZpbFwiOntcIkZpcnN0TmFtZVwiOm51bGwsXCJMYXN0TmFtZVwiOm51bGwsXCJKb2JUaXRsZVwiOm51bGwsXCJEZWdyZWVcIjpudWxsLFwiVXNlcnNcIjpudWxsLFwiUHJvZmlsRG9tYWluSm9ic1wiOm51bGwsXCJJZFwiOjAsXCJDcmVhdGVEYXRlXCI6bnVsbCxcIlVwZGF0ZURhdGVcIjpudWxsLFwiQ3JlYXRlZEJ5XCI6bnVsbCxcIlVwZGF0ZWRCeVwiOm51bGx9LFwiRmF2b3Jpc1wiOltdLFwiSWRcIjoxLFwiQ3JlYXRlRGF0ZVwiOlwiMjAyNC0wNC0wM1QxMzoxMTo1Ny4yMDUzMTQxXCIsXCJVcGRhdGVEYXRlXCI6XCIyMDIzLTExLTE2VDE2OjQ1OjM4LjQwODEzNjVcIixcIkNyZWF0ZWRCeVwiOlwiQWRlbHRydWRlIERhIHNpbHZhXCIsXCJVcGRhdGVkQnlcIjpcIkFkZWx0cnVkZSBEYSBzaWx2YVwifSIsImV4cCI6MTcyNDE1MTU5MCwiaXNzIjoiSm9iT2ZmZXJBcHBBcGkiLCJhdWQiOiJwdWJsaWMifQ.zWRU0g8zCp8XDzt-EeTJPUeOB6VMHKuvxWye6icZf0CPLYcgmvAZrqvc2OVtX7w-ayYhR2meXLT-WrRngjh-4Q";
            //Token = await LocalStorageService!.GetItemAsStringAsync("token");
            await LoadData();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime!.InvokeVoidAsync("initAdminTemplate");
            }
        }

        private async Task LoadData()
        {
            try
            {
                IsLoading = true;
                Items = await GenericService!.GetEntitiesAsync(BaseSettingsApp?.BaseUrlApiWebHttp + "DomainJob", Token);
                Items = Items?.OrderByDescending(x => x.Id).ToList();
                //InitialItems = Items;
                Count = Items != null ? Items.Count : 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally { IsLoading = false; }
        }

        private bool FilterFunc1(DomainJobViewModel item) => FilterFunc(item, TableSearchString);

        private bool FilterFunc(DomainJobViewModel item, string? tableSearchString)
        {
            if (string.IsNullOrWhiteSpace(tableSearchString))
                return true;
            if (item!.Domain!.Contains(tableSearchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (item!.CreatedBy!.Contains(tableSearchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (item!.CreateDate!.ToString()!.Contains(tableSearchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (item!.UpdatedBy!.Contains(tableSearchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (item!.UpdateDate!.ToString()!.Contains(tableSearchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task ShowDialogAsync(
            string TitileDialog = "Add",
            DomainJobViewModel? domainJobViewModel = null,
            bool isUpdate = false,
            string titleOkButton = "Add")
        {
            try
            {
                var parameters = new DialogParameters<DomainJobAddUpdate>()
                {
                    {
                        x => x.DomainJobViewModel, domainJobViewModel ?? new DomainJobViewModel()
                    },
                    {
                        x => x.TitleOkButton, titleOkButton
                    },
                    {
                        x => x.IsUpdate, isUpdate
                    },
                    {
                        x => x.Uri, BaseSettingsApp?.BaseUrlApiWebHttp + "DomainJob"
                    },
                    {
                        x => x.Token, Token
                    }
                };
                IsUpdate = isUpdate;
                var options = new MudBlazor.DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true };
                var dialog = await DialogService!.ShowAsync<DomainJobAddUpdate>(TitileDialog, parameters, options);
                var result = await dialog.Result;

                if (!result!.Canceled)
                {
                    var data = (EntityDbResponse<DomainJobViewModel>)result.Data!;
                    if (data != null)
                    {
                        await LoadData();
                        await Swal!.FireAsync(new SweetAlertOptions()
                        {
                            Title = titleOkButton,
                            Text = data.MessageStatus?.Message,
                            Icon = data.MessageStatus?.StatusCode == System.Net.HttpStatusCode.OK ? SweetAlertIcon.Success : SweetAlertIcon.Error
                        });
                    }
                }
                else
                {
                    await Swal!.FireAsync(new SweetAlertOptions()
                    {
                        Title = titleOkButton,
                        Text = "Operation Canceled !",
                        Icon = SweetAlertIcon.Warning
                    });
                }
                if (isUpdate) IsUpdate = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        void ShowTooltip(ElementReference elementReference, TooltipOptions? options = null, string? message = default)
        {
            TooltipService?.Open(elementReference, message ?? string.Empty, options);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(TooltipService!);
        }
    }
}
