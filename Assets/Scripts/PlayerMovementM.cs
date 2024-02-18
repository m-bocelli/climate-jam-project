using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float torque = 60f;
    [SerializeField] private Transform rudder;

    private Vector3 rotateDir;
    private Animator shipAnimator;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        shipAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        rb.AddForceAtPosition(transform.forward * moveSpeed, rudder.position);
    }

    void Turn()
    {
        //Turn Ship
        rotateDir = new (0f, Input.GetAxis("Horizontal"), 0f);
        transform.Rotate(rotateDir * torque * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed) 
    {
        moveSpeed = newSpeed;
    }
}
