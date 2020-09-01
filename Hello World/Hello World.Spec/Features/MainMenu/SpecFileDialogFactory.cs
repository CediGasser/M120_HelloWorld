using Hello_World.LoadAndSaveGame;

namespace Hello_World.Spec.Features.MainMenu
{
    internal class SpecFileDialogFactory : IFileDialogFactory
    {
        public string FileNameToSave { get; set; }

        public string FileNameToLoad { get; set; }

        public IFileDialog CreateSaveFileDialog(string filter, string initialDirectory)
        {
            return new SpecFileDialog {FileName = this.FileNameToSave};
        }

        public IFileDialog CreateOpenFileDialog(string filter, string initialDirectory)
        {
            return new SpecFileDialog {FileName = this.FileNameToLoad};
        }

        private class SpecFileDialog : IFileDialog
        {
            public string FileName { get; set; }

            public bool ShowDialog()
            {
                return true;
            }
        }
    }
}