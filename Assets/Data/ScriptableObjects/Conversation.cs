using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "Data/Conversation")]
    public class Conversation : ScriptableObject
    {
        public List<Dialogue> Dialogues;
    }

    public enum OnFinishedAction
    {
        COMPLETE_LEVEL,
        ADVANCE_STATE,
        SHOW_OBJECTIVES,
        NONE
    }
}

