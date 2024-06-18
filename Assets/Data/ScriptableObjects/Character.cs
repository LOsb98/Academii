using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "Data/Character")]
    public class Character : ScriptableObject
    {
        public Sprite Icon;
        public Color ColourTheme;
    }
}
