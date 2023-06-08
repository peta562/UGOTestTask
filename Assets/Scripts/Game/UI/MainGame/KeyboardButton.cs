using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
    public class KeyboardButton : MonoBehaviour {
        [SerializeField] Button Button;
        [SerializeField] Text LetterText;

        Action<char> _keyboardButtonClicked;
        char _letter;
        
        public void Init(Action<char> keyboardButtonClicked, char letter) {
            _keyboardButtonClicked = keyboardButtonClicked;
            _letter = letter;
            LetterText.text = letter.ToString();
            
            Button.onClick.AddListener(OnButtonClicked);
        }

        public void DeInit() {
            _keyboardButtonClicked = null;
            Button.onClick.RemoveListener(OnButtonClicked);
        }

        void OnButtonClicked() {
            _keyboardButtonClicked?.Invoke(_letter);
        }
    }
}