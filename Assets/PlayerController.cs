using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variáveis que podes ajustar no Unity Inspector
    public float speed = 20.0f;
    public float turnSpeed = 45.0f;
    
    private float horizontalInput;
    private float forwardInput;

    void Update()
    {
        // 1. Receber o input do utilizador (Setas ou WASD)
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // 2. Mover o veículo para a frente e para trás
        // Tradução: Direção * Tempo * Velocidade * Input do Jogador
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // 3. Rodar o veículo (Fazer a curva)
        // Usamos Rotate para que o carro vire de forma realista em vez de apenas deslizar
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}