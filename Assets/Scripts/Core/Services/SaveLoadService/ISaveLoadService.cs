using Data;

namespace Core.Services.SaveLoadService {
    public interface ISaveLoadService : IService {
        ProgressData ProgressData { get; }
        void SaveData();
        void LoadData();
    }
}