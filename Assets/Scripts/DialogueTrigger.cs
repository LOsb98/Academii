using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField, Tooltip("There will be a different conversation available for each story level, 5 in total")] private Conversation[] _conversations;
        [SerializeField] private SpriteRenderer _indicatorSpriteRenderer;
        [SerializeField, Tooltip("If there is a string here, attempt to set this secret as found in player prefs")] private string _secretToTrigger;

        public void Interact()
        {
            int currentStoryLevel = GameManager.Instance.GetStoryLevel();
            GameManager.Instance.StartDialogue(_conversations[currentStoryLevel]);
             if (!string.IsNullOrEmpty(_secretToTrigger)) GameManager.Instance.RegisterSecret(_secretToTrigger);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _indicatorSpriteRenderer.enabled = true;
            Debug.Log("Entered trigger");
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _indicatorSpriteRenderer.enabled = false;
            Debug.Log("Left trigger");
        }
    }
}
