using UnityEngine;

public class DetectarColisao : MonoBehaviour
{
    // Ajusta este valor se o teu chão for noutra posição (ex: 0 ou 1)
    private float alturaDoChao = 5.0f; 

    void OnTriggerEnter(Collider other)
    {
        // 1. Só morre se bater no cão...
        if (other.CompareTag("Dog"))
        {
            // 2. ...E se a bola já estiver lá em baixo! ✅
            // Se a posição Y da bola for menor que 5 (perto do cão)
            if (transform.position.y < alturaDoChao)
            {
                Debug.Log("Puff! Bati no cão lá em baixo! 🐶");
                Destroy(gameObject); // Destrói a bola
            }
        }
    }
}
