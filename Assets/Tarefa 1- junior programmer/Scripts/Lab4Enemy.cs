using UnityEngine;

public class Lab4Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    void Start() {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update() {
        if (player != null) {
            // Direção para o jogador
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            // Movimento LENTO ✅
            enemyRb.AddForce(lookDirection * speed);
        }

        // Destrói se sair do ecrã/mapa
        if (transform.position.y < -5) Destroy(gameObject);
    }
}
