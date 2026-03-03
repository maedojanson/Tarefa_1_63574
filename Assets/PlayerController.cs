using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float speed = 20.0f;        // Aparece no Inspector
    public float turnSpeed = 45.0f;    // Aparece no Inspector

    private float verticalInput;
    private float horizontalInput;

    public void OnMove(InputValue value)
    {
        Vector2 movementVector = value.Get<Vector2>();
        verticalInput = movementVector.y;
        horizontalInput = movementVector.x;
    }

    void Update()
    {
        // Movimento para a frente e trás
        // Se 20 for lento, podes digitar 100 ou 200 no Inspector durante o Play Mode
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Rotação
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}