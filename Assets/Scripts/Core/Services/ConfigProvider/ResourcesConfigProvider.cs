using Configs;
using UnityEngine;

namespace Core.Services.ConfigProvider {
    public class ResourcesConfigProvider : IConfigProvider {
        public MainConfig MainConfig { get; private set; }
        
        public void LoadConfigs() {
            MainConfig = Resources.Load<MainConfig>(ConfigPaths.MainConfigPath);
        }
    }
}