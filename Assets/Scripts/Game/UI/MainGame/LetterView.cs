using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
    public class LetterView : MonoBehaviour {
        [SerializeField] Text LetterText;
        
        public void Setup(char letter) {
            LetterText.text = letter.ToString();
        }
    }
}