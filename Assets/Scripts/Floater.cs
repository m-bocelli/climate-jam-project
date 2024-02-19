using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Floater : MonoBehaviour
{
    [SerializeField] private float floaterDepth;
    private float displacementMultiplier;
    private Vector3 buoyancyForce;
    private float waveHeight;

    private FloatManager fm;

    public Floater Init(FloatManager _fm)
    {
        fm = _fm;
        return this;
    }

    private void Start()
    {
        floaterDepth = transform.localScale.y;
    }

    private void FixedUpdate()
    {
        waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        
        ForceFloaterDown();
        // Apply buoyancy once object has been submerged
        if (transform.position.y < waveHeight)
        {
            ApplyBuoyancy();
            ApplyDrag();
        }
    }

    private float GetDisplacementMultiplier() 
    {
        return Mathf.Clamp01((waveHeight - transform.position.y) / floaterDepth) * fm.displacementAmount;
    }

    private void ApplyBuoyancy()
    {
        displacementMultiplier = GetDisplacementMultiplier();
        buoyancyForce = new Vector3(0f, -Physics.gravity.y, 0f) * displacementMultiplier;
        fm.rb.AddForceAtPosition(buoyancyForce, transform.position, ForceMode.Acceleration);
    }

    private void ApplyDrag()
    {
        fm.rb.AddForce(-fm.rb.velocity * fm.waterDrag * displacementMultiplier * Time.deltaTime, ForceMode.VelocityChange);
        fm.rb.AddTorque(-fm.rb.angularVelocity * fm.waterAngularDrag * displacementMultiplier * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void ForceFloaterDown()
    {
        fm.rb.AddForceAtPosition(Physics.gravity / fm.floaterCount, transform.position, ForceMode.Acceleration);
    }
    
}
