using System.Collections.Generic;
using UnityEngine;

namespace Game.UI {
    public class LetterListView : MonoBehaviour {
        [SerializeField] Transform LetterListContainer;
        [SerializeField] LetterView LetterViewPrefab;

        readonly List<LetterView> _letterViews = new();
        
        public void StartGame(int lettersCount) {
            foreach (var letterView in _letterViews) {
                Destroy(letterView.gameObject);
            }
            _letterViews.Clear();
            
            for (var i = 0; i < lettersCount; i++) {
                var letterView = Instantiate(LetterViewPrefab, LetterListContainer);
                _letterViews.Add(letterView);
            }
        }

        public void AddLetter(int index, char letter) {
            _letterViews[index].Setup(letter);
        }
    }
}