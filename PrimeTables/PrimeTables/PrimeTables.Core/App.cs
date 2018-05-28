///-----------------------------------------------------------------
///   Description:   App file
///-----------------------------------------------------------------
namespace PrimeTables.Core
{
    using MvvmCross.Platform;
    using MvvmCross.Platform.IoC;
    using PrimeTables.Core.Model;

    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<IPrimeTablesModel,PrimeTablesModel>();

            RegisterAppStart<ViewModels.PrimeTablesViewModel>();
        }
    }
}
