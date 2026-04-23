using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    void Update()
    {
        // MEXER NA CÂMARA SÓ COM WASD ✅
        float horizontalInput = 0;
        
        if (Input.GetKey(KeyCode.A)) horizontalInput = -1;
        if (Input.GetKey(KeyCode.D)) horizontalInput = 1;

        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
