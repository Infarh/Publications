using MathCore.Hosting.WPF;
using Publications.TestWPF.ViewModels;

namespace Publications.TestWPF
{
    public class ServiceLocator : ServiceLocatorHosted
    {
        public MainwindowViewModel MainModel => GetRequiredService<MainwindowViewModel>();
    }
}
