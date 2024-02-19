using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOcean : MonoBehaviour
{
    public GameObject OceanTile;
    [SerializeField] private Transform seaBoundary;
    
    private void Awake() 
    {
        int rows = (int)Mathf.Ceil(seaBoundary.localScale.x)/10;
        int cols = (int)Mathf.Ceil(seaBoundary.localScale.z)/10;
        for (int i = 1; i < rows; i++) {
            for (int j = 1; j < cols; j++) {
                Instantiate(OceanTile, new Vector3(i*10 - seaBoundary.localScale.x/2, 0, j*10-seaBoundary.localScale.z/2), Quaternion.Euler(Vector3.zero));
            }
        }
    }
}
