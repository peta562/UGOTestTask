using Data;
using UnityEngine;

namespace Core.Services.SaveLoadService {
    public sealed class PlayerPrefsSaveLoadService : ISaveLoadService {
        public ProgressData ProgressData { get; private set; }

        public void SaveData() {
            var json = JsonUtility.ToJson(ProgressData);

            PlayerPrefs.SetString("save_data", json);
        }
        
        public void LoadData() {
            var json = PlayerPrefs.GetString("save_data");
            var saveData = JsonUtility.FromJson<ProgressData>(json) ?? new ProgressData();

            ProgressData = saveData;
        }
    }
}