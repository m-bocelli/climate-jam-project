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
    public AudioSource koriSpeaker;
    [SerializeField]
    public AudioClip[] koriVoiceLines;

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

    public void ShootCannonSound()
    {
        if (soundPlayed) return;

        if (Random.Range(0, 1) == 1) return;

        koriSpeaker.clip = koriVoiceLines[Random.Range(2, 4)];

        koriSpeaker.Play();
        soundPlayed = true;
    }
    public void CrewSound()
    {
        if (soundPlayed) return;

        if (Random.Range(0, 1) == 1) return;

        koriSpeaker.clip = koriVoiceLines[Random.Range(5, 7)];

        koriSpeaker.Play();
        soundPlayed = true;
    }

    public void EnemyApproachingSound()
    {
        if (soundPlayed) return;

        if (Random.Range(0, 1) == 1) return;

        koriSpeaker.clip = koriVoiceLines[Random.Range(8, 10)];

        koriSpeaker.Play();
        soundPlayed = true;
    }

    public void HurtSound()
    {
        if (soundPlayed) return;

        if (Random.Range(0, 1) == 1) return;

        koriSpeaker.clip = koriVoiceLines[Random.Range(14, 15)];

        koriSpeaker.Play();
        soundPlayed = true;
    }
    public void LoseSound()
    {
        if (soundPlayed) return;

        koriSpeaker.clip = koriVoiceLines[16];

        koriSpeaker.Play();
        soundPlayed = true;
    }
    public void OilRigSound()
    {
        if (soundPlayed) return;

        if (Random.Range(0, 1) == 1) return;

        koriSpeaker.clip = koriVoiceLines[Random.Range(17,18)];

        koriSpeaker.Play();
        soundPlayed = true;
    }
    public void OilSound()
    {
        if (soundPlayed) return;

        if (Random.Range(0, 1) == 1) return;

        koriSpeaker.clip = koriVoiceLines[19];

        koriSpeaker.Play();
        soundPlayed = true;
    }
    public void ShipSailSound(int sailSpeed)
    {
        if (soundPlayed) return;

        if (Random.Range(0, 1) == 1) return;

        if (sailSpeed == 0)
        {
            koriSpeaker.clip = koriVoiceLines[21];
        }
        else if(sailSpeed == 1)
        {
            koriSpeaker.clip = koriVoiceLines[22];
        }
        else
        {
            koriSpeaker.clip = koriVoiceLines[20];
        }

        koriSpeaker.Play();
        soundPlayed = true;
    }

    public void AllOilRigsDestryedSound()
    {
        if (soundPlayed) return;

        koriSpeaker.clip = koriVoiceLines[23];

        koriSpeaker.Play();
        soundPlayed = true;
    }
}
