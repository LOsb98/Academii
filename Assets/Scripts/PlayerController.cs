using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterMovement
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        private Vector2 _movementInput;

        private void Update()
        {
            //GetKeyDown is not the best input method, input manager package is better and more flexible
            //But keeping it simple for this project due to short timeframe

            //GetKeyDown means if two keys are held down at the same time, the last pressed one will be used
            //Being pressed at the same frame is unlikely and we don't care so much what happens in this case, as long as an input registers
            if (Input.GetKey(KeyCode.A))
            {
                _movementInput.x = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _movementInput.x = 1f;
            }
            else
            {
                _movementInput.x = 0f;
            }

            _movement.Move(_movementInput);

            if (Input.GetKeyDown(KeyCode.W))
            {
                _movement.Jump();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Dialogue start
            }
        }
    }
}
