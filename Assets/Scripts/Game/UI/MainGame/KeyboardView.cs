using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI {
    public class KeyboardView : MonoBehaviour {
        [SerializeField] Transform KeyboardButtonsContainer;
        [SerializeField] KeyboardButton KeyboardButtonPrefab;

        readonly List<KeyboardButton> _keyboardButtons = new();
        
        public void Init(Action<char> keyboardButtonClicked, List<char> alphabet) {
            foreach (var letter in alphabet) {
                var keyboardButton = Instantiate(KeyboardButtonPrefab, KeyboardButtonsContainer);
                keyboardButton.Init(keyboardButtonClicked, letter);
                _keyboardButtons.Add(keyboardButton);
            }
        }

        public void DeInit() {
            foreach (var letterButton in _keyboardButtons) {
                letterButton.DeInit();
                Destroy(letterButton.gameObject);
            }
            
            _keyboardButtons.Clear();
        }

        public void SetActive(bool isActive) {
            gameObject.SetActive(isActive);
        }
    }
}