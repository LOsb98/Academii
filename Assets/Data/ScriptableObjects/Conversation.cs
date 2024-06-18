using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "Data/Conversation")]
    public class Conversation : ScriptableObject
    {
        public List<Dialogue> Dialogues;
        public bool AdvanceStoryLevel;
        //This objective only needs to be used if the story level advances
        //In future, a custom inspector could be coded to hide this value if AdvanceStoryLevel is false
        public string NewObjective;
    }
}

