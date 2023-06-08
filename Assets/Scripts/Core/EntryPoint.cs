using Core.Services;
using Core.Services.ConfigProvider;
using Core.Services.SaveLoadService;
using Core.Services.UIFactory;
using Core.StateMachine;
using Game;
using UnityEngine;

namespace Core {
    public class EntryPoint : MonoBehaviour {
        [SerializeField] GameUIHolder GameUIHolder;
        
        ServiceLocator _serviceLocator;

        void Awake() {
            CreateServices();
            CreateGameStateMachine();
        }

        void CreateServices() {
            _serviceLocator = new ServiceLocator();

            _serviceLocator.RegisterSingle<IConfigProvider>(new ResourcesConfigProvider());
            _serviceLocator.RegisterSingle<IUIFactory>(new UIFactory(GameUIHolder));
            _serviceLocator.RegisterSingle<ISaveLoadService>(new PlayerPrefsSaveLoadService());
        }

        void CreateGameStateMachine() {
            var gameStateMachine = new GameStateMachine(_serviceLocator);
            gameStateMachine.Enter<LoadConfigsState>();
        }
    }
}