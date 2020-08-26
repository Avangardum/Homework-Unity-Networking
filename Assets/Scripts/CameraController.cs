using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const int LEFT_MOUSE_BUTTON = 0;

    [SerializeField] private GameObject _player;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minVerticalRotation;
    [SerializeField] private float _maxVerticalRotation;
    [SerializeField] private float _horizontalSensitivity;
    [SerializeField] private float _verticalSensivity;
    [SerializeField] private float _distanceSensivity;
    [SerializeField] private float _initialHorizontalRotation;
    [SerializeField] private float _initialVerticalRotation;
    [SerializeField] private float _initialDistance;

    private Vector3 _previousMousePosition = -Vector3.one;

    private float _distance;
    private float _horizontalRotation;
    private float _verticalRotation;

    private void Awake()
    {
        _distance = _initialDistance;
        _horizontalRotation = _initialHorizontalRotation;
        _verticalRotation = _initialVerticalRotation;
    }

    private void LateUpdate()
    {
        if(Input.GetMouseButton(LEFT_MOUSE_BUTTON) && _previousMousePosition != -Vector3.one)
        {
            Vector3 mouseDelta = Input.mousePosition - _previousMousePosition;
            _horizontalRotation -= mouseDelta.x * _horizontalSensitivity;
            _verticalRotation -= mouseDelta.y * _verticalSensivity;
            _verticalRotation = Mathf.Clamp(_verticalRotation, _minVerticalRotation, _maxVerticalRotation);
        }
        _distance -= Input.mouseScrollDelta.y * _distanceSensivity;
        _distance = Mathf.Clamp(_distance, _minDistance, _maxDistance);

        float x, y, z, m;//m - дистанция между игроком и проекцией камеры на горизонтальную плоскость проходящую через игрока
        y = _distance * Mathf.Sin(_verticalRotation * Mathf.Deg2Rad);
        m = _distance * Mathf.Cos(_verticalRotation * Mathf.Deg2Rad);
        z = m * Mathf.Sin(_horizontalRotation * Mathf.Deg2Rad);
        x = m * Mathf.Cos(_horizontalRotation * Mathf.Deg2Rad);
        transform.position = new Vector3(x, y, z) + _player.transform.position;
        transform.LookAt(_player.transform);

        _previousMousePosition = Input.mousePosition;
    }
}
