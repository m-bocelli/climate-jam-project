using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float torque = 60f;
    [SerializeField] private Transform rudder;

    private Vector3 rotateDir;
    private Animator shipAnimator;

    public float ForwardSpeedMultiplier = 1f;
    public float RotationSpeedMultiplier = 1f;

    [SerializeField] bool bounceOff = false;
    [SerializeField] public BoatSounds boatSounds;

    public BoatSounds BoatSounds { get { return boatSounds; } set { boatSounds = value; } }
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        shipAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        if (SceneManager.GetActiveScene().name == "TitleScreen") return;

        if (RotationSpeedMultiplier >= 2.5f) RotationSpeedMultiplier = 2.5f;
        if (ForwardSpeedMultiplier >= 3) ForwardSpeedMultiplier = 3;

        Move();
        Turn();
        Anchored();
    }

    void Move()
    {
        Vector3 direction = transform.forward;
        if (bounceOff) direction = -transform.forward;
        rb.AddForceAtPosition(direction * moveSpeed * ForwardSpeedMultiplier, rudder.position);
    }

    void Anchored()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!boatSounds.koriSpeaker.isPlaying)
                boatSounds.koriSpeaker.PlayOneShot(boatSounds.koriVoiceLines[0]);
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (!boatSounds.koriSpeaker.isPlaying)
                boatSounds.koriSpeaker.PlayOneShot(boatSounds.koriVoiceLines[1]);
        }
        if (Input.GetButton("Jump"))
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Turn()
    {
        //Turn Ship
        rotateDir = new (0f, Input.GetAxis("Horizontal"), 0f);
        rb.AddTorque(rotateDir * torque * RotationSpeedMultiplier * Time.deltaTime);
        //transform.Rotate(rotateDir * torque * RotationSpeedMultiplier * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed) 
    {
        moveSpeed = newSpeed;
    }

    public void SetTorque(float newTorque)
    {
        torque = newTorque;
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }

    public void IncreaseSpeed(float increasedSpeed)
    {
        moveSpeed *= increasedSpeed;
    }

    public void DecreaseSpeed(float decreaseSpeed)
    {
        moveSpeed /= decreaseSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Landform") && !collision.gameObject.CompareTag("Plastic"))
        {
            bounceOff = true;
            StartCoroutine(EndBounceOff());
            boatSounds.HitWallSound.Play();
            CameraShake.instance.ShakeCamera(0.2f, 0.1f);
            rb.AddForceAtPosition(-transform.forward * moveSpeed * ForwardSpeedMultiplier, rudder.position);
        }
    }


    IEnumerator EndBounceOff()
    {
        yield return new WaitForSeconds(0.3f);
        bounceOff = false;
    }
}
