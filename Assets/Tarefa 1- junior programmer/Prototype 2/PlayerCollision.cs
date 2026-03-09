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
            
            // Destrói a Farmer
            Destroy(gameObject);
            
            // Opcional: Destrói também o animal que a atingiu
            Destroy(other.gameObject);
            
            // Congela o jogo para mostrar que acabou
            Time.timeScale = 0;
        }
    }
}
