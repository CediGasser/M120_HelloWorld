using Hello_World.LoadAndSaveGame;
using Ninject.Modules;

namespace Hello_World
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFileDialogFactory>().To<FileDialogFactory>().InSingletonScope();
        }
    }
}