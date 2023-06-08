using System;
using System.Collections.Generic;
using Core.Services;
using Core.Services.ConfigProvider;
using Core.Services.SaveLoadService;
using Core.Services.UIFactory;

namespace Core.StateMachine {
    public sealed class GameStateMachine {
        readonly Dictionary<Type, IExitableState> _states;
        
        IExitableState _activeState;

        public GameStateMachine(ServiceLocator services) {
            _states = new Dictionary<Type, IExitableState> {
                [typeof(LoadConfigsState)] =
                    new LoadConfigsState(this, 
                        services.Single<IConfigProvider>()),
                [typeof(LoadProgressState)] =
                    new LoadProgressState(this, 
                        services.Single<ISaveLoadService>()),
                [typeof(StartMenuState)] =
                    new StartMenuState(this, 
                        services.Single<IUIFactory>()),
                [typeof(InitGameState)] =
                    new InitGameState(this, 
                        services.Single<IUIFactory>(), 
                        services.Single<IConfigProvider>()),
                [typeof(MainGameState)] =
                    new MainGameState(this, 
                        services.Single<IUIFactory>(),
                        services.Single<ISaveLoadService>()),
                [typeof(GameOverState)] = 
                    new GameOverState(this,
                        services.Single<IUIFactory>()),
            };
        }

        public void Enter<T>() where T : class, IState {
            var state = ChangeState<T>();
            state.Enter();
        }
        
        public void Enter<T, TP>(TP payload) where T : class, IPayloadedState<TP> {
            var state = ChangeState<T>();
            state.Enter(payload);
        }

        T ChangeState<T>() where T : class, IExitableState {
            _activeState?.Exit();

            var state = GetState<T>();
            _activeState = state;

            return state;
        }

        T GetState<T>() where T : class, IExitableState => _states[typeof(T)] as T;
    }
}