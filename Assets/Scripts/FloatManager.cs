using Unity.VisualScripting;
using UnityEngine;

public class FloatManager : MonoBehaviour
{
    
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public int floaterCount;
    [SerializeField] private GameObject[] floaterPoints;
    private Floater[] floaters;

    [Header("Buoyancy Values")]
    public float displacementAmount = 3f;
    public float waterDrag = 1f;
    public float waterAngularDrag = 1f;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        floaterCount = floaterPoints.Length;
        floaters = new Floater[floaterCount];

        for (int i  = 0; i < floaterCount; i++)
        {
            floaters[i] = floaterPoints[i].AddComponent<Floater>().Init(this);
        }
    }
}
