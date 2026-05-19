using UnityEngine;

public class Lab5Obstacle : MonoBehaviour
{
    // Este script está vazio de movimento para o cubo ficar estático! ✅
    // Ele apenas serve para ser detetado pelas colisões do Player.

    void Start()
    {
        // Garante que o cubo está bem assente no chão
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
    
    void Update()
    {
        // Se o cubo cair do mapa por algum motivo, é destruído
        if (transform.position.y < -5) Destroy(gameObject);
    }
}
