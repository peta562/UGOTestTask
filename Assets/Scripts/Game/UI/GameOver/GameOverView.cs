using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
    public class GameOverView : MonoBehaviour {
        public event Action RestartButtonClicked;
        
        [SerializeField] Text StatusText;
        [SerializeField] Button RestartButton;

        public void Init(string status) {
            StatusText.text = status;
            RestartButton.onClick.AddListener(OnRestartButtonClicked);
            
            gameObject.SetActive(true);
        }

        public void DeInit() {
            RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            gameObject.SetActive(false);
        }

        void OnRestartButtonClicked() {
            RestartButtonClicked?.Invoke();
        }
    }
}