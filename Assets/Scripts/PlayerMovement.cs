using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float turnSpeed = 5;
    [SerializeField] float _velocityIncreaseRate = 1.25f;
    [SerializeField] float _velocityDecreaseRate = .3f;

    [SerializeField] Rigidbody rb;

    private bool anchor;
    private float currentDirection;

    [SerializeField] float forwardSpeedMultiplier = 1f;
    [SerializeField] float rotationSpeedMultiplier = 1f;

    public float ForwardSpeedMultiplier { get { return forwardSpeedMultiplier; } set { forwardSpeedMultiplier = value; } }
    public float RotationSpeedMultiplier { get { return rotationSpeedMultiplier; } set { rotationSpeedMultiplier = value; } }

    void Awake()
    {
        currentDirection = 1f;
        anchor = true;
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anchor = !anchor;
            if (anchor) rb.velocity = Vector3.zero;
           // if (anchor) moveSpeed = _minThrottleSpeed;
        }

        if (!anchor)
        {
            Move();
        }
        */

        Move();
        Turn();
        Rock();

        //Make sure player doesn't go anywhere on the y Axis.
       // transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    void Move()
    {
        //Move Ship If Not Anchored
        //Vector3 movementDir = new(0f, 0f, Input.GetAxisRaw("Vertical"));
        //rb.velocity = new Vector3(0f, 0f, currentDirection) * moveSpeed * forwardSpeedMultiplier * Time.deltaTime;
        float vert = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * vert * moveSpeed * forwardSpeedMultiplier * Time.deltaTime);
        //rb.velocity = Vector3.forward * moveSpeed * forwardSpeedMultiplier * Time.deltaTime;
        Debug.Log("rb vel: " + rb.velocity);

        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(localVelocity);
    }

    void Turn()
    {
        //Turn Ship
        Vector3 rotateDir = new Vector3(0f, Input.GetAxisRaw("Horizontal"), 0f);
        rb.AddRelativeTorque(rotateDir * turnSpeed * rotationSpeedMultiplier * Time.deltaTime, ForceMode.VelocityChange);

        
        //transform.Rotate(rotateDir * rotateSpeed * rotationSpeedMultiplier * Time.deltaTime);
    }

    void Rock()
    {
        //float rockSpeed = 3f * (moveSpeed / 10);

        transform.Rotate(Vector3.forward * Time.deltaTime * Mathf.Sin(Time.time * 3f) /** rockSpeed*/);
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public bool GetAnchorDown()
    {
        return anchor;
    }

    public void IncreaseSpeed(float increasedSpeed)
    {
        moveSpeed *= increasedSpeed;
    }

    public void DecreaseSpeed(float decreaseSpeed)
    {
        moveSpeed /= decreaseSpeed;
    }
}
