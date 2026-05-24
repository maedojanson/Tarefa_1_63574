using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Este método deteta quando um animal (Trigger) toca na Farmer
    void OnTriggerEnter(Collider other)
    {
        // Verifica se o que bateu na Farmer foi um animal
        // (Garante que os teus animais têm a Tag "Animal")
        if (other.CompareTag("Animal"))
        {
            Debug.Log("GAME OVER! Um animal atingiu a Farmer!");
            
            // 1. Faz o animal desaparecer (Otimizado para Pooling!)
            other.gameObject.SetActive(false);
            
            // 2. Destrói a Farmer (Fim de jogo)
            Destroy(gameObject);
            
            // 3. Congela o jogo para mostrar que acabou
            Time.timeScale = 0;
        }
    }
}
