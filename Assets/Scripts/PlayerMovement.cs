using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _maxRotationSpeed = 50f;
    [SerializeField] float _minRotationSpeed = 15f;
    [SerializeField] float _minThrottleSpeed = 5f;
    [SerializeField] float _maxThrottleSpeed = 30f;
    [SerializeField] float _velocityIncreaseRate = 1.25f;
    [SerializeField] float _velocityDecreaseRate = .3f;

    [SerializeField] Rigidbody rb;

    private bool anchor;
    private float moveSpeed;
    private float rotateSpeed;
    private float currentDirection;

    void Awake()
    {
        moveSpeed = _minThrottleSpeed;
        rotateSpeed = _maxRotationSpeed;
        currentDirection = 1f;
        anchor = true;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && moveSpeed == _minThrottleSpeed)
        {
            currentDirection = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anchor = !anchor;
            if (anchor) rb.velocity = Vector3.zero;
            if (anchor) moveSpeed = _minThrottleSpeed;
        }

        if (!anchor)
        {
            Move();
        }

        Turn();
        Rock();

        //Make sure player doesn't go anywhere on the y Axis.
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    void Move()
    {
        //Move Ship If Not Anchored
        //Vector3 movementDir = new(0f, 0f, Input.GetAxisRaw("Vertical"));
        transform.Translate(new Vector3(0f, 0f, currentDirection) * moveSpeed * Time.deltaTime);

        //Increase Velocity The Longer We Hold Down Input
        if(Input.GetAxisRaw("Vertical") > 0f)
        {
            moveSpeed *= _velocityIncreaseRate;
            if(moveSpeed > _maxThrottleSpeed)
            {
                moveSpeed = _maxThrottleSpeed;
            }
        }
        else
        {
            moveSpeed *= _velocityDecreaseRate;
            if (moveSpeed < _minThrottleSpeed)
            {
                moveSpeed = _minThrottleSpeed;
            }
        }
    }

    void Turn()
    {
        //Turn Ship
        Vector3 rotateDir = new(0f, Input.GetAxisRaw("Horizontal"), 0f);
        transform.Rotate(rotateDir * rotateSpeed * Time.deltaTime);

        //Decrease Turn Speed The Faster We Go
        if(moveSpeed != _minThrottleSpeed)
        {
            rotateSpeed *= _velocityDecreaseRate;
            if(rotateSpeed < _minRotationSpeed)
            {
                rotateSpeed = _minRotationSpeed;
            }
        }
        else
        {
            rotateSpeed *= _velocityIncreaseRate;
            if(rotateSpeed > _maxRotationSpeed)
            {
                rotateSpeed = _maxRotationSpeed;
            }
        }
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
}
