using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterMovement
{
    ///<summary>
    ///Generic movement methods which can be applied to any entity with a rigidbody
    ///Logic for detecting entity states goes here, controllers shouldn't be doing any logic regarding movement i.e. ground check, movement speed e.c.t.
    ///</summary>
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _groundedCheckPosition;
        [SerializeField] private Vector2 _groundCheckDimensions;
        [SerializeField] private LayerMask _groundLayer;
        private bool _grounded;

        //OnValidate will automatically run and populate the rigidbody field
        //This method has no major performance impact as it is editor-only
        private void OnValidate()
        {
            if (!_rigidbody)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }
        }

        //This will come from keyboard for this game, so values for WASD will be -1 to 1, used to determine more direction
        public void Move(Vector2 movementInput)
        {
            _rigidbody.velocity = new Vector2(movementInput.x * _moveSpeed, _rigidbody.velocity.y);
        }

        public void Jump()
        {
            if (_grounded)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
            }
        }

        private void FixedUpdate()
        {
            if (Physics2D.OverlapBox(_groundedCheckPosition.position, _groundCheckDimensions, 0f, _groundLayer))
            {
                _grounded = true;
            }
            else
            {
                _grounded = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(_groundedCheckPosition.position, _groundCheckDimensions);
        }
    }
}
