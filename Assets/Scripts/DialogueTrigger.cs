using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private Conversation _conversation;
        [SerializeField] private SpriteRenderer _indicatorSpriteRenderer;

        public void Interact()
        {
            GameManager.Instance.StartDialogue(_conversation);
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
