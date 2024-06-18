using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MainUI
{
    public class MainUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _objectiveText;
        [SerializeField] private GameObject _finishedWindow;

        public void UpdateObjective(string newObjective)
        {
            _objectiveText.text = $"OBJECTIVE: {newObjective}";
        }

        public void ShowFinishedWindow()
        {
            _finishedWindow.SetActive(true);
        }
    }
}
