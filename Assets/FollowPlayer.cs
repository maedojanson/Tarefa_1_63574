using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // Arraste o carro/avião para aqui no Unity
    private Vector3 offset = new Vector3(0, 5, -7); // Posição relativa atrás do player

    // LateUpdate é melhor para câmaras porque corre depois do movimento do player
    void LateUpdate()
    {
        // Define a posição da câmara como a posição do player + a distância definida
        transform.position = player.transform.position + offset;
    }
}