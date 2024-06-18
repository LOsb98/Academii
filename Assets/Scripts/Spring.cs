using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float _springHeight;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
        {
            //This spring will only launch up
            //More maths is required if this spring is going to launch any direction
            //For consistency and simplicity, spring will reset horizontal momentum when used
            rigidbody.velocity = new Vector2(0f, _springHeight);
        }
    }
}
