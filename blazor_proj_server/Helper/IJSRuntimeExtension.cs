using System;
using Microsoft.JSInterop;

namespace blazor_proj_server.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsruntime, string message)
        {
            await jsruntime.InvokeVoidAsync("showToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jsruntime, string message)
        {
            await jsruntime.InvokeVoidAsync("showToastr", "error", message);
        }
    }
}

