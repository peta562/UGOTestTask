using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
    public class WinsLosesView : MonoBehaviour {
        [SerializeField] Text WinsLosesText;

        public void UpdateWinsLosesText(int wins, int loses) {
            WinsLosesText.text = $"Выиграно: {wins}, Проиграно: {loses}";
        }
    }
}