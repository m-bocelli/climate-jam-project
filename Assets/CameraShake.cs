using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ShakeCamera(float duration, float magnitude)
    {
        StartCoroutine(ShakeCameraCoroutine(duration, magnitude));
    }

    public IEnumerator ShakeCameraCoroutine(float duration, float magnitude)
    {
        //Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float rngX = Random.Range(-1f, 1f) * magnitude;
            float rngY = Random.Range(-1f, 1f) * magnitude;
            float rngZ = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition += new Vector3(rngX, rngY, rngZ);
            elapsed += Time.deltaTime;

            //wait until next frame until next iteration.
            yield return null;
        }

        //transform.localPosition = originalPos;
    }
}
