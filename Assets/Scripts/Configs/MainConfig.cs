using System.Collections.Generic;
using UnityEngine;

namespace Configs {
    [CreateAssetMenu(fileName = nameof(MainConfig), menuName = "Configs/" + nameof(MainConfig), order = 0)]
    public class MainConfig : ScriptableObject {
        public List<string> GuessingWords;
        public List<char> Alphabet;
        public int AttemptsCount;
    }
}