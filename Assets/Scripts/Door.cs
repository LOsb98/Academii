using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /// <summary>
    /// Once this story level is reached, this door will open
    /// </summary>
    [SerializeField] private int _requiredStoryLevel;

    private void OnEnable()
    {
        GameManager.StoryLevelIncrease += CheckStoryLevel;
    }

    private void CheckStoryLevel(int storyLevel)
    {
        Debug.Log("Checking story level");
        if (storyLevel >= _requiredStoryLevel)
        {
            Debug.Log("Level met, disabling door");
            gameObject.SetActive(false);
        }
    }
}
