using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField, Range(1f,20f)] private float _distanceFromPlayer = 10f;
    [SerializeField] private float _focusRadius = 1f;
    [SerializeField, Range(0f, 1f)] float _focusCentering = 0.5f;
    private Vector3 _focusPos;

    public float smoothing;
    public float rotSmoothing;


    private void Awake() 
    {
        _focusPos = _playerTransform.position;
    }

    private void FixedUpdate() 
    {
        _focusPos = new Vector3(_playerTransform.position.x, 6f,_playerTransform.position.z);
        Vector3 lookDir = transform.forward;
        Vector3 targetPos = _focusPos - lookDir * _distanceFromPlayer;

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, _playerTransform.rotation, rotSmoothing);
        transform.rotation = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f));
        //Debug.Log("Setting camera pos to : " + transform.position + " : playerPos:" + _playerTransform.position);
       // UpdateFocusPos();
       // MoveToFocus();
    }

    /*
    private void UpdateFocusPos()
    {
        Vector3 targetPos = _playerTransform.position;
        float distance = Vector3.Distance(_focusPos, targetPos);
        float t = 1f;
        if (distance > 0.01f && _focusCentering > 0f) t = Mathf.Pow(1f - _focusCentering, Time.unscaledDeltaTime);

        if (distance > _focusRadius) t = Mathf.Min(t, _focusRadius / distance);

        _focusPos = Vector3.Lerp(targetPos, _focusPos, t);
    }

    private void MoveToFocus() 
    {
        Vector3 lookDir = transform.forward;
        transform.position = _focusPos - lookDir * _distanceFromPlayer;
    }
    */
}
