using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
    public class StartMenuView : MonoBehaviour {
        public event Action StartButtonClicked;
        
        [SerializeField] Button StartButton;

        public void Init() {
            StartButton.onClick.AddListener(OnStartButtonClicked);
            gameObject.SetActive(true);
        }

        public void DeInit() {
            StartButton.onClick.RemoveListener(OnStartButtonClicked);
            gameObject.SetActive(false);
        }

        void OnStartButtonClicked() {
            StartButtonClicked?.Invoke();
        }
    }
}