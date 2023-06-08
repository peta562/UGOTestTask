using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Logic {
    public class RandomWordsGenerator {
        readonly List<string> _words;
        
        List<string> _currentWords;

        public RandomWordsGenerator(List<string> words) {
            _words = words;
            
            _currentWords = _words.ToList();
        }

        public string GetRandomWord() {
            if ( _currentWords.Count == 0 ) {
                ResetWords();
            }
            
            var randomIndex = Random.Range(0, _currentWords.Count);
            return _currentWords[randomIndex];
        }

        public void RemoveWord(string word) {
            _currentWords.Remove(word);
        }

        void ResetWords() {
            _currentWords = _words.ToList();
        }
    }
}