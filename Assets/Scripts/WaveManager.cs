using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    //public float waveAmplitude = 1f;
    //public float waveLength = 2f;
    //public float waveSpeed = 1f;
    //public float waveOffset = 0f;
    [SerializeField] private Material mat;

    private int amplitudeID_1, lengthID_1, speedID_1;
    private int amplitudeID_2, lengthID_2, speedID_2;
    private float offset_1, offset_2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        amplitudeID_1 = Shader.PropertyToID("_Amplitude_1");
        lengthID_1 = Shader.PropertyToID("_Length_1");
        speedID_1 = Shader.PropertyToID("_Speed_1");

        amplitudeID_2 = Shader.PropertyToID("_Amplitude_2");
        lengthID_2 = Shader.PropertyToID("_Length_2");
        speedID_2 = Shader.PropertyToID("_Speed_2");
    }

    private void Update()
    {
        //waveOffset += Time.deltaTime * waveSpeed;
        CalculateOffsets();
    }

    // Gets the height of the wave at any given x coordinate
    public float GetWaveHeight(float _xPos)
    {
        float y = CalculateWaveY(_xPos, mat.GetFloat(lengthID_1), mat.GetFloat(amplitudeID_1), offset_1);
                // CalculateWaveY(_xPos, mat.GetFloat(lengthID_2), mat.GetFloat(amplitudeID_2), offset_2);
        return y;
        //return waveAmplitude * Mathf.Sin(_xPos / waveLength + waveOffset);
    }

    private float CalculateWaveY(float _x, float _length, float _amplitude, float _offset)
    {
        float frequency = 2 / _length;
        return _amplitude * Mathf.Sin((frequency * _x) + _offset);
    }

    private void CalculateOffsets() 
    {
        float frequency = 2 / mat.GetFloat(lengthID_1);
        offset_1 += Time.deltaTime * mat.GetFloat(speedID_1) * frequency;
        //offset_2 += Time.deltaTime * mat.GetFloat(speedID_2);
    }
}
