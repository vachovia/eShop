using Microsoft.JSInterop;

namespace eShop.Web.Common.JsInterOp
{
    public class JsNavigator
    {
        private IJSRuntime _jSRuntime;

        public JsNavigator(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task NavigateToAsync(string url)
        {
            await _jSRuntime.InvokeVoidAsync("navigateTo", url);
        }
    }
}
