using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerX : MonoBehaviour
{
    public float rotationSpeed = 1000f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
