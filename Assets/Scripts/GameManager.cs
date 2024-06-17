using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DialogueSystem;
using PlayerInput;
using MainUI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private MainUIManager _mainUIManager;
    [SerializeField] private PlayerController _playerController;

    public static event Action<int> StoryLevelIncrease;
    
    [SerializeField] private int _currentStoryLevel;

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

    private void OnEnable()
    {
        DialogueManager.FinishedDialogue += FinishDialogue;
    }

    public void StartDialogue(Conversation newConversation)
    {
        _playerController.enabled = false;
        _dialogueManager.BeginNewConversation(newConversation);
    }

    public void FinishDialogue(bool advanceStory)
    {
        _playerController.enabled = true;
        if (advanceStory) IncreaseStoryLevel();
    }

    public int GetStoryLevel()
    {
        return _currentStoryLevel;
    }

    public void IncreaseStoryLevel()
    {
        _currentStoryLevel++;
        StoryLevelIncrease(_currentStoryLevel);
    }

}
