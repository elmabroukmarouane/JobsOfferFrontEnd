using JobOffers.Frontend.Busines.Services.Interface;
using Microsoft.JSInterop;

namespace JobOffers.Frontend.Busines.Services.Class
{
	public class TitleService : ITitleService
	{
		private readonly IJSRuntime? JSRuntime;
        public TitleService(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime ?? throw new ArgumentException(null, nameof(JSRuntime));
        }
        public async Task SetTitlePage(string title)
		{
			await JSRuntime!.InvokeVoidAsync("setTitle", title);
		}
	}
}
