using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [Serializable]
    public class Dialogue
    {
        public Sprite CharacterSprite;
        public string CharacterName;
        [TextArea(1, 6)]
        public string TextBody;
    }
}
