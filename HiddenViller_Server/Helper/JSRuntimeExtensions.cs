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
        public static async ValueTask SweetAlertSuccess(this IJSRuntime Runtime,string heading, string message)
        {
            await Runtime.InvokeVoidAsync("Swal.fire", heading, message, "success");
        }
    }
}
