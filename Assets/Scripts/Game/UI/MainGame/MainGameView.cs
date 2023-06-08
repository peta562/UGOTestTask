using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.UI {
    public class MainGameView : MonoBehaviour {
        [SerializeField] HangmanView HangmanView;
        [SerializeField] KeyboardView KeyboardView;
        [SerializeField] LetterListView LetterListView;
        
        public void Init(Action<char> keyboardButtonClicked, List<char> alphabet) {
            gameObject.SetActive(true);
            KeyboardView.Init(keyboardButtonClicked, alphabet);
        }

        public void DeInit() {
            gameObject.SetActive(false);
            KeyboardView.DeInit();
        }

        public void StartGame(int lettersCount) {
            KeyboardView.SetActive(true);
            HangmanView.StartGame();
            LetterListView.StartGame(lettersCount);
        }

        public void FinishGame() {
            KeyboardView.SetActive(false);
        }

        public void OpenNextHangmanStage() {
            HangmanView.OpenNextStage();
        }

        public void AddLetterToLetterList(int index, char letter) {
            LetterListView.AddLetter(index, letter);
        }
    }
}