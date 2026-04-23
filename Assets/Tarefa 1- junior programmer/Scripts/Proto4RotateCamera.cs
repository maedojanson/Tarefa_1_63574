using UnityEngine;

public class Proto4RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 60.0f;

    void Update()
    {
        // Rotação com teclas A e D ✅
        float rotationInput = 0;
        if (Input.GetKey(KeyCode.D)) rotationInput = 1;
        if (Input.GetKey(KeyCode.A)) rotationInput = -1;

        transform.Rotate(Vector3.up, rotationInput * rotationSpeed * Time.deltaTime);
    }
}
