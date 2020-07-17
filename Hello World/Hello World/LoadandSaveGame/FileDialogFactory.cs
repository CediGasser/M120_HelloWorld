using Microsoft.Win32;

namespace Hello_World.LoadAndSaveGame
{
    public interface IFileDialog
    {
        public bool ShowDialog();

        public string FileName { get; }
    }

    public interface IFileDialogFactory
    {
        IFileDialog CreateSaveFileDialog(string filter, string initialDirectory);

        IFileDialog CreateOpenFileDialog(string filter, string initialDirectory);
    }

    public class FileDialogFactory : IFileDialogFactory
    {
        public IFileDialog CreateSaveFileDialog(string filter, string initialDirectory)
        {
            return new SaveFileDialogWrapper(filter, initialDirectory);
        }

        private class SaveFileDialogWrapper : IFileDialog
        {
            private readonly SaveFileDialog saveFileDialog;
            
            public bool ShowDialog() => this.saveFileDialog.ShowDialog() ?? false;

            public string FileName => this.saveFileDialog.FileName;

            public SaveFileDialogWrapper(string filter, string initialDirectory)
            {
                this.saveFileDialog = new SaveFileDialog() {Filter = filter, InitialDirectory = initialDirectory};
            }
        }

        public IFileDialog CreateOpenFileDialog(string filter, string initialDirectory)
        {
            return new OpenFileDialogWrapper(filter, initialDirectory);
        }

        private class OpenFileDialogWrapper : IFileDialog
        {
            private readonly OpenFileDialog openFileDialog;

            public bool ShowDialog() => this.openFileDialog.ShowDialog() ?? false;

            public string FileName => this.openFileDialog.FileName;

            public OpenFileDialogWrapper(string filter, string initialDirectory)
            {
                this.openFileDialog = new OpenFileDialog() { Filter = filter, InitialDirectory = initialDirectory };
            }
        }
    }
}