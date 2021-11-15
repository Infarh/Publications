using Microsoft.AspNetCore.Components;

namespace Publications.BlazorUI.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static void GoToRoot(this NavigationManager Navigator) => Navigator.NavigateTo("/");
    }
}
