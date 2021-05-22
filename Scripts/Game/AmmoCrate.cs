using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    // Start is called before the first frame update\
    [Header("Visuals")]
    public GameObject container;
    public float rotationSpeed= 180f;

    [Header("GamePlay")]
   public int ammo=12;
    
    // Update is called once per frame
    void Update()
    {
        container.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
