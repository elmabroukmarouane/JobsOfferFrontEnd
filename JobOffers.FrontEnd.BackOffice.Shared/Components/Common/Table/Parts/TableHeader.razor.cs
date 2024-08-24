using Microsoft.AspNetCore.Components;

namespace JobOffers.FrontEnd.BackOffice.Shared.Components.Common.Table.Parts
{
    public partial class TableHeader
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
