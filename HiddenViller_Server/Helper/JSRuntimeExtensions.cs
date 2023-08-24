using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace HiddenViller_Server.Helper
{
    public static class JSRuntimeExtensions
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime Runtime, string message, string title)
        {
            await Runtime.InvokeVoidAsync("toastr.success", message, title);
        }
        public static async ValueTask ToastrError(this IJSRuntime Runtime, string message, string title)
        {
            await Runtime.InvokeVoidAsync("toastr.error", message, title);
        }
        public static async ValueTask ToastrWarning(this IJSRuntime Runtime, string message, string title)
        {
            await Runtime.InvokeVoidAsync("toastr.warning", message, title);
        }

        public static async ValueTask SweetAlertSuccess(this IJSRuntime Runtime,string heading, string message)
        {
            await Runtime.InvokeVoidAsync("Swal.fire", heading, message, "success");
        }
        public static async ValueTask SweetAlertError(this IJSRuntime Runtime, string heading, string message)
        {
            await Runtime.InvokeVoidAsync("Swal.fire", heading, message, "error");
        }
    }
}
