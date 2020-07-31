using Hello_World.Core;
using Hello_World.GamePage;
using Hello_World.Infrastructure;
using Hello_World.LoadAndSaveGame;
using Hello_World.MainWindow;
using Ninject.Modules;

namespace Hello_World
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFileDialogFactory>().To<FileDialogFactory>().InSingletonScope();
            this.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            this.Bind<Game>().ToSelf().InSingletonScope();
            this.Bind<WindowDisplayer>().ToSelf().InSingletonScope();
            this.Bind<GameViewModelFactory>().ToSelf();
        }
    }
}