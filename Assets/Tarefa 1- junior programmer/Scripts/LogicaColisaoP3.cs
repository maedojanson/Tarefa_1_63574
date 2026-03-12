using UnityEngine;

public class LogicaColisaoP3 : MonoBehaviour
{
    public bool gameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Se batermos em algo que tenha a Tag "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over: Colisão com obstáculo detetada.");
            
            // Podes adicionar aqui um efeito visual depois!
        }
    }
}
