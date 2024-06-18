using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [Serializable]
    public class Dialogue
    {
        public Character Character;
        [TextArea(1, 6)]
        public string TextBody;
    }
}
