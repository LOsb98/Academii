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
        [SerializeField] private TextMeshProUGUI _secretCountText;

        public void UpdateObjective(string newObjective)
        {
            _objectiveText.text = $"OBJECTIVE: {newObjective}";
        }

        public void ShowFinishedWindow(int secretCount)
        {
            _secretCountText.text = $"You've found {secretCount}/3 secrets!";
            _finishedWindow.SetActive(true);
        }
    }
}
