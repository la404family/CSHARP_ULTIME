using System;
using System.IO;
using System.Text.Json;
using Roguelike.Models;

namespace Roguelike.Data
{
    public static class LevelLoader
    {
        public static LevelData LoadLevel(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Le fichier de niveau '{filePath}' est introuvable.");
            }

            string jsonContent = File.ReadAllText(filePath);
            
            var options = new JsonSerializerOptions 
            { 
                PropertyNameCaseInsensitive = true 
            };

            LevelData? level = JsonSerializer.Deserialize<LevelData>(jsonContent, options);
            return level ?? new LevelData();
        }
    }
}
