using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 50f;
    [SerializeField] float _throttleSpeed = 10f;
    void Awake()
    {
        
    }

    void Update()
    {
        Move();
        Turn();
        Rock();
    }

    void Move()
    {
        Vector3 movementDir = new(0f, 0f, Input.GetAxisRaw("Vertical"));
        transform.Translate(movementDir * _throttleSpeed * Time.deltaTime);
    }

    void Turn()
    {
        Vector3 rotateDir = new(0f, Input.GetAxisRaw("Horizontal"), 0f);
        transform.Rotate(rotateDir * _rotationSpeed * Time.deltaTime);
    }

    void Rock()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * Mathf.Sin(Time.time * 3f));
    }
}
