using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MainUI
{
    public class MainUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _objectiveText;

        public void UpdateObjective(string newObjective)
        {
            _objectiveText.text = $"OBJECTIVE: {newObjective}";
        }
    }
}
