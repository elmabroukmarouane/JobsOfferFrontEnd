using Microsoft.AspNetCore.Components;

namespace JobOffers.FrontEnd.BackOffice.Shared.Components.Common
{
    public partial class DescriptionCardContent
    {
        [Parameter] 
        public RenderFragment? ChildContent { get; set; }
    }
}
