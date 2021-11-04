using MathCore.Hosting;
using MathCore.WPF.ViewModels;
using Publications.TestWPF.Services.Interfaces;

namespace Publications.TestWPF.ViewModels
{
    [Service]
    public class MainwindowViewModel : TitledViewModel
    {
        public MainwindowViewModel() => Title = "Главное окно";

        [Inject]
        public IUserDialog UserDialog { get; init; }
    }
}
