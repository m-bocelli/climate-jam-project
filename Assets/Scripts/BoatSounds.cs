using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BoatSounds : MonoBehaviour
{
    [Header("Sound Stats")]
    [SerializeField]
    private float maxSoundCooldown;
    private float soundCooldown;
    private bool soundPlayed;

    [Header("Sound References")]
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private AudioSource oceanSound;
    [SerializeField] AudioSource cannonSound;
    [SerializeField] AudioSource boatCrashSound;
    [SerializeField] AudioSource hitWallSound;
    [SerializeField] AudioSource plasticSound;

    public AudioSource CannonSound { get { return cannonSound; } set { cannonSound = value; } }

    public AudioSource CrashSound { get { return boatCrashSound; }}

    public AudioSource HitWallSound { get { return hitWallSound; } }

    public AudioSource PlasticSound { get { return plasticSound; } }

    // Start is called before the first frame update
    void Start()
    {
        soundCooldown = 0;
        soundPlayed = false;

        oceanSound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(soundPlayed)
        {
            soundCooldown += Time.deltaTime;
            if (soundCooldown >= maxSoundCooldown) soundPlayed = false;
        }
    }
}
