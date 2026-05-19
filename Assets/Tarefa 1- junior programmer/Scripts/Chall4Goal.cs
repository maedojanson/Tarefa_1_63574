using UnityEngine;
using UnityEngine.SceneManagement; // Garante que continua aqui para podermos reiniciar ✅

public class Chall4Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Se a bola do inimigo (ou o inimigo) entrar na tua baliza...
        if (other.CompareTag("Enemy"))
        {
            // Alterado para a mensagem que querias! 💀
            Debug.Log("💀 GAME OVER! O adversário marcou golo na tua baliza!");
            
            // Destruímos a bola imediatamente para dar efeito de golo
            Destroy(other.gameObject);

            // Chama a função de reiniciar após 1 segundo (dá tempo de respirar!) ✅
            Invoke("RestartGame", 1.0f);
        }
    }

    void RestartGame()
    {
        // Limpa a vaga atual e recomeça o desafio do zero
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
