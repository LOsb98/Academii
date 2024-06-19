using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DialogueSystem;
using PlayerInput;
using MainUI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private MainUIManager _mainUIManager;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private string[] secretNames;

    public static event Action<int> StoryLevelIncrease;
    
    private int _currentStoryLevel;

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
        _playerController.DisableController();
        _dialogueManager.BeginNewConversation(newConversation);
    }

    public void FinishDialogue(bool advanceStory)
    {
        _playerController.enabled = true;
        if (advanceStory)
        {
            IncreaseStoryLevel();
        } 
    }

    public int GetStoryLevel()
    {
        return _currentStoryLevel;
    }

    public void IncreaseStoryLevel()
    {
        _currentStoryLevel++;
        //This broadcasts out the current story level
        //Mainly so doors can check if they need to open
        StoryLevelIncrease(_currentStoryLevel);
        if (_currentStoryLevel >= 5) FinishGame();
    }

    public void SetNewObjective(string newObjective)
    {
        _mainUIManager.UpdateObjective(newObjective);
    }

    public void FinishGame()
    {
        _playerController.enabled = false;
        _mainUIManager.ShowFinishedWindow(CountSecrets());
        //Display victory UI
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RegisterSecret(string secretName)
    {
        PlayerPrefs.SetInt(secretName, 1);
    }

    public int CountSecrets()
    {
        int secretCount = 0;

        foreach (string secret in secretNames)
        {
            if (PlayerPrefs.GetInt(secret, 0) == 1) secretCount++;
        }

        return secretCount;
    }

}
