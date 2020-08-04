using System;
using System.IO;
using System.Text.Json;
using Hello_World.Core;

namespace Hello_World.LoadAndSaveGame
{
    public class JsonFileManager
    {
        private readonly IFileDialogFactory fileDialogFactory;

        public JsonFileManager(IFileDialogFactory fileDialogFactory)
        {
            this.fileDialogFactory = fileDialogFactory;
        }

        public void SaveGame(Game game)
        {
            string jsonString = JsonSerializer.Serialize(game);

            IFileDialog saveFileDialog = this.fileDialogFactory.CreateSaveFileDialog(
                "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            if (saveFileDialog.ShowDialog()) File.WriteAllText(saveFileDialog.FileName, jsonString);
        }

        public Game LoadGame()
        {
            Game game;
            string jsonString = "";

            //OpenFileDialog openFileDialog = new OpenFileDialog
            //{
            //    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
            //    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            //};
            IFileDialog openFileDialog = this.fileDialogFactory.CreateOpenFileDialog(
                "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));


            if (openFileDialog.ShowDialog()) jsonString = File.ReadAllText(openFileDialog.FileName);

            if (jsonString != "")
                game = JsonSerializer.Deserialize<Game>(jsonString);
            else
                throw new NoPathSelectedException();

            return game;
        }
    }
}