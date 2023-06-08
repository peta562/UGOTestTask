using Configs;

namespace Core.Services.ConfigProvider {
    public interface IConfigProvider : IService {
        MainConfig MainConfig { get; }

        void LoadConfigs();
    }
}