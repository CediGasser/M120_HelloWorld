namespace Hello_World.LoadAndSaveGame
{
    using Microsoft.Win32;

    public interface IFileDialog
    {
        public string FileName { get; }
        public bool ShowDialog();
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

        public IFileDialog CreateOpenFileDialog(string filter, string initialDirectory)
        {
            return new OpenFileDialogWrapper(filter, initialDirectory);
        }

        private class SaveFileDialogWrapper : IFileDialog
        {
            private readonly SaveFileDialog saveFileDialog;

            public SaveFileDialogWrapper(string filter, string initialDirectory)
            {
                this.saveFileDialog = new SaveFileDialog {Filter = filter, InitialDirectory = initialDirectory};
            }

            public bool ShowDialog()
            {
                return this.saveFileDialog.ShowDialog() ?? false;
            }

            public string FileName => this.saveFileDialog.FileName;
        }

        private class OpenFileDialogWrapper : IFileDialog
        {
            private readonly OpenFileDialog openFileDialog;

            public OpenFileDialogWrapper(string filter, string initialDirectory)
            {
                this.openFileDialog = new OpenFileDialog {Filter = filter, InitialDirectory = initialDirectory};
            }

            public bool ShowDialog()
            {
                return this.openFileDialog.ShowDialog() ?? false;
            }

            public string FileName => this.openFileDialog.FileName;
        }
    }
}