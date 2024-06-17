using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DialogueSystem;
using PlayerInput;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private PlayerController _playerController;
    public static GameManager Instance;

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void StartDialogue(Conversation newConversation)
    {
        _playerController.enabled = false;
        _dialogueManager.BeginNewConversation(newConversation);
    }

    public void FinishDialogue()
    {
        _playerController.enabled = true;
    }

}
