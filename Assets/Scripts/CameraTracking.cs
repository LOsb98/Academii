using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private float _maxDistanceDelta;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _maxCameraClampValue;

    private void FixedUpdate()
    {
        float yPos = _playerRigidbody.transform.position.y;
        float xPos = _playerRigidbody.transform.position.x;
        float targetXPos = Mathf.Clamp(xPos, xPos - _maxCameraClampValue, xPos + _maxCameraClampValue);
        Vector3 targetPos = new Vector3(targetXPos + (_playerRigidbody.velocity.x / 10f), yPos, -10f);
        _cameraTransform.position = Vector3.MoveTowards(transform.position, targetPos, _maxDistanceDelta);
    }
}
