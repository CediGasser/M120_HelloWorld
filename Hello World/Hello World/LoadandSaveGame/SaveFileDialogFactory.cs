using Microsoft.Win32;

namespace Hello_World.LoadAndSaveGame
{
    public class SaveFileDialogFactory
    {
        internal ISaveFileDialog Create(string filter, string initialDirectory)
        {
            return new SaveFileDialogWrapper(filter, initialDirectory);
        }

        private class SaveFileDialogWrapper : ISaveFileDialog
        {
            private readonly SaveFileDialog saveFileDialog;
            
            public bool ShowDialog() => this.saveFileDialog.ShowDialog() ?? false;

            public string FileName => this.saveFileDialog.FileName;

            public SaveFileDialogWrapper(string filter, string initialDirectory)
            {
                this.saveFileDialog = new SaveFileDialog() {Filter = filter, InitialDirectory = initialDirectory};
            }
        }
    }
}