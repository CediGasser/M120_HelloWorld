﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hello_World.Core;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace Hello_World.LoadAndSaveGame
{
    class JsonFileManager
    {
        public void SaveGame(Game game)
        {
            string jsonString = JsonSerializer.Serialize(game);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };


            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, jsonString);
            }
        }

        public Game LoadGame()
        {
            Game game;
            string jsonString = "";

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };


            if (openFileDialog.ShowDialog() == true)
            {
                jsonString = File.ReadAllText(openFileDialog.FileName);
            }

            if (jsonString != "")
            {
                game = JsonSerializer.Deserialize<Game>(jsonString);
            }
            else
            {
                throw new NoPathSelectedException();
            }

            return game;
        }
    }
}
