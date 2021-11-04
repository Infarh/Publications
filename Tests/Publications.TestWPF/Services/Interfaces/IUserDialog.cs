using MathCore.Hosting;
using MathCore.WPF.Services;

namespace Publications.TestWPF.Services.Interfaces
{
    [Service(Implementation = typeof(UserDialogService))]
    public interface IUserDialog : IUserDialogBase
    {
        
    }
}
