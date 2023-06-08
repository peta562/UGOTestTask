using System.Collections.Generic;
using UnityEngine;

namespace Game.UI {
    public class HangmanView : MonoBehaviour {
        [SerializeField] List<GameObject> HangmanStages;
        
        int _currentStage;

        public void StartGame() {
            foreach (var hangmanStage in HangmanStages) {
                hangmanStage.SetActive(false);
            }

            _currentStage = -1;
        }

        public void OpenNextStage() {
            _currentStage++;
            HangmanStages[_currentStage].SetActive(true);
        }
    }
}