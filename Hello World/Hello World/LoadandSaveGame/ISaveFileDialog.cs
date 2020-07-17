namespace Hello_World.LoadAndSaveGame
{
    internal interface ISaveFileDialog
    {
        public bool ShowDialog();

        public string FileName { get; }
    }
}