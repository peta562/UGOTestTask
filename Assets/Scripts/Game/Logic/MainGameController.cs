using System;
using System.Collections.Generic;
using Configs;
using Game.UI;

namespace Game.Logic {
    public class MainGameController {
        public event Action<bool> GameOver;
        
        readonly MainGameView _mainGameView;
        readonly MainConfig _mainConfig;
        readonly RandomWordsGenerator _randomWordsGenerator;

        List<char> _collectedLetters;
        string _guessingWord;
        int _currentAttempts;

        public MainGameController(MainGameView mainGameView, MainConfig mainConfig,
            RandomWordsGenerator randomWordsGenerator) {
            _mainGameView = mainGameView;
            _mainConfig = mainConfig;
            _randomWordsGenerator = randomWordsGenerator;
        }

        public void Init() {
            _mainGameView.Init(OnKeyboardButtonClicked, _mainConfig.Alphabet);
        }

        public void DeInit() {
            _mainGameView.DeInit();
        }

        public void StartGame() {
            _currentAttempts = _mainConfig.AttemptsCount;
            
            _guessingWord = _randomWordsGenerator.GetRandomWord();
            _collectedLetters = new List<char>(new char[_guessingWord.Length]);
            
            _mainGameView.StartGame(_guessingWord.Length);
        }

        public void FinishGame() {
            _mainGameView.FinishGame();
        }

        void OnKeyboardButtonClicked(char letter) {
            CheckLetter(letter);
        }

        void CheckLetter(char letter) {
            if ( _collectedLetters.Contains(letter) ) {
                return;
            }

            if ( !_guessingWord.Contains(letter) ) {
                _currentAttempts -= 1;
                _mainGameView.OpenNextHangmanStage();
                CheckForLose();
                return;
            }

            for (var i = 0; i < _guessingWord.Length; i++) {
                if ( _guessingWord[i] == letter ) {
                    _mainGameView.AddLetterToLetterList(i, letter);
                    _collectedLetters[i] = letter;
                }
            }
            
            CheckForWin();
        }

        void CheckForWin() {
            var word = string.Concat(_collectedLetters);

            if ( word == _guessingWord ) {
                _randomWordsGenerator.RemoveWord(_guessingWord);
                GameOver?.Invoke(true);
            }
        }

        void CheckForLose() {
            if ( _currentAttempts <= 0 ) {
                GameOver?.Invoke(false);
            }
        }
    }
}