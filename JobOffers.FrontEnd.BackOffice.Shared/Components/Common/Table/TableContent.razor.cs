using Microsoft.AspNetCore.Components;

namespace JobOffers.FrontEnd.BackOffice.Shared.Components.Common.Table
{
    public partial class TableContent
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
