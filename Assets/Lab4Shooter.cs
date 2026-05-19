using UnityEngine;

public class Lab4Shooter : MonoBehaviour
{
    public Transform player;
    public GameObject bolaInimigaPrefab;
    public float speed = 2.0f;
    public float shootingRange = 12.0f;
    public float fireRate = 2.0f;
    public float forcaDoTiro = 25.0f;
    private float nextFireTime;

    void Start() {
        if (player == null) player = GameObject.Find("Player").transform;
    }

    void Update() {
        if (player == null) return;
        float distance = Vector3.Distance(transform.position, player.position);

        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        
        if (distance > 4.0f) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (distance <= shootingRange && Time.time > nextFireTime) {
            Atirar();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Atirar() {
        GameObject bola = Instantiate(bolaInimigaPrefab, transform.position + transform.forward * 1.5f, transform.rotation);
        Rigidbody rb = bola.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.AddForce(transform.forward * forcaDoTiro, ForceMode.Impulse);
        }
        Destroy(bola, 3.0f);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("TiroPlayer")) {
            // Avisa o player para disparar o Debug de Win! ✅
            GameObject.Find("Player").GetComponent<Lab4Player>().Ganhar();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
