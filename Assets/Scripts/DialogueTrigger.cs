using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayer;
        /// <summary>
        /// There will be a different conversation available for each story level, 5 in total
        /// </summary>
        [SerializeField] private Conversation[] _conversations;
        [SerializeField] private SpriteRenderer _indicatorSpriteRenderer;

        public void Interact()
        {
            int currentStoryLevel = GameManager.Instance.GetStoryLevel();
            GameManager.Instance.StartDialogue(_conversations[currentStoryLevel]);

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
