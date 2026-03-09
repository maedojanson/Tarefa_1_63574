using UnityEngine;

public class DetetarColisoes : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Só faz alguma coisa se o objeto que o cão tocou for uma BOLA
        // (Garante que as tuas bolas têm a Tag "Ball" ou o nome "Ball")
        if (other.gameObject.name.Contains("Ball") || other.CompareTag("Ball"))
        {
            Destroy(gameObject);       // Destrói o cão
            Destroy(other.gameObject); // Destrói a bola
        }
        
        // Se o cão bater noutro cão, o código ignora e eles passam um pelo outro!
    }
}
