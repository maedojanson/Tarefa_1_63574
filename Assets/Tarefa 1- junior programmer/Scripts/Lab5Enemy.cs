using UnityEngine;

public class Lab5Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    void Start() {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update() {
        if (player != null) {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            // Movimento direto e constante ✅
            enemyRb.linearVelocity = lookDirection * speed;
            
            // Faz o cão olhar para o player
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }

        if (transform.position.y < -5) Destroy(gameObject);
    }
}
