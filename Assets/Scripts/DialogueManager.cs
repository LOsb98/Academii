using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private Conversation _testConversation;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _bodyText;
        [SerializeField] private Image _characterImage;


        private Conversation _currentConversation;
        private int _currentConversationIndex;

        private void Start()
        {
            //BeginNewConversation(_testConversation);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AdvanceConversation();
            }
        }

        public void BeginNewConversation(Conversation newConversation)
        {
            gameObject.SetActive(true);
            _currentConversationIndex = -1;
            _currentConversation = newConversation;

            AdvanceConversation();
        }

        public void AdvanceConversation()
        {
            _currentConversationIndex++;

            if (_currentConversationIndex >= _currentConversation.Dialogues.Count)
            {
                FinishConversation();
            }
            else
            {
                LoadDialogue(_currentConversation.Dialogues[_currentConversationIndex]);
            }
        }

        private void FinishConversation(Action onFinishAction = null)
        {
            onFinishAction?.Invoke();
            GameManager.Instance.FinishDialogue();
            gameObject.SetActive(false);
        }

        public void LoadDialogue(Dialogue newDialogue)
        {
            _nameText.text = newDialogue.CharacterName;
            _bodyText.text = newDialogue.TextBody;
            _characterImage.sprite = newDialogue.CharacterSprite;
        }
    }
}
