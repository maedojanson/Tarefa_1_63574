using UnityEngine;
using UnityEngine.SceneManagement;

public class Lab5Shooter : MonoBehaviour {
    private Transform playerTransform;
    private Lab5Player playerScript;
    public GameObject macaInimigaPrefab; 
    public float speed = 2.0f; 
    public float fireRate = 2.5f;
    private float nextFire;

    void Start() {
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null) {
            playerTransform = playerObj.transform;
            playerScript = playerObj.GetComponent<Lab5Player>();
        }
    }

    void Update() {
        if (playerTransform == null) return;

        transform.LookAt(playerTransform);
        
        if (Vector3.Distance(transform.position, playerTransform.position) > 1.0f) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            AtirarMacaInimiga();
        }
    }

    void AtirarMacaInimiga() {
        if (macaInimigaPrefab == null) return;
        GameObject tiro = Instantiate(macaInimigaPrefab, transform.position + transform.forward * 1.5f, transform.rotation);
        tiro.tag = "Projetil"; 
        Rigidbody rb = tiro.GetComponent<Rigidbody>();
        if (rb != null) rb.AddForce(transform.forward * 18f, ForceMode.Impulse);
        Destroy(tiro, 3.0f);
    }

    // DETEÇÃO POR TRIGGER (Se a maçã passar por dentro) ✅
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            VerificarFimDeJogo();
        }
        
        // Verifica se foi atingido pelo tiro da maçã
        if (other.CompareTag("TiroPlayer") || other.gameObject.name.Contains("maça")) {
            AcertouNoCavalo(other.gameObject);
        }
    }

    // DETEÇÃO POR COLISÃO FÍSICA (Se a maçã bater e ricochetear) ✅
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            VerificarFimDeJogo();
        }

        // Verifica se foi atingido pelo tiro da maçã
        if (collision.gameObject.CompareTag("TiroPlayer") || collision.gameObject.name.Contains("maça")) {
            AcertouNoCavalo(collision.gameObject);
        }
    }

    void VerificarFimDeJogo() {
        if (playerScript != null) {
            if (!playerScript.temEscudo) {
                Debug.Log("game over");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            }
        }
    }

    void AcertouNoCavalo(GameObject projetil) {
        Debug.Log("🎯 Maçã acertou no Cavalo!");
        Destroy(projetil); // Destrói a maçã voadora
        
        if (playerScript != null) {
            playerScript.MarcarVitoria(); // Ativa o WIN! em baixo e reinicia
        }
        
        Destroy(gameObject); // O Cavalo desaparece instantaneamente! 🐎❌
    }
}