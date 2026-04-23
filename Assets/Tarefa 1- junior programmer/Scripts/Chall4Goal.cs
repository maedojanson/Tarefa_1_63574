using UnityEngine;
using UnityEngine.SceneManagement;

public class Chall4Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Se a bola do inimigo entrar no centro da baliza verde... ✅
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("GOLO! O inimigo entrou na baliza!");
            
            // Destruímos a bola
            Destroy(other.gameObject);

            // Reiniciamos o jogo para a Vaga 1 ✅
            // Usar SceneManager é a forma mais segura de limpar tudo e recomeçar
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
