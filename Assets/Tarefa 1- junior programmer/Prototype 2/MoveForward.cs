using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;

    void Update()
    {
        // Move o objeto para a frente continuamente
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
