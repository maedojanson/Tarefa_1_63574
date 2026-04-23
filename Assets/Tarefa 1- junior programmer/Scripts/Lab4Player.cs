using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lab4Player : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody playerRb;
    
    [Header("Defesa (Escudo)")]
    public bool temEscudo = false;
    public GameObject escudoVisual; 

    [Header("Ataque (Munição)")]
    public int municao = 0;
    public GameObject projetilPlayerPrefab; 

    private bool jogoAcabou = false;

    void Start() {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (jogoAcabou) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && municao > 0) {
            Disparar();
        }

        if (transform.position.y < -5) Perder();
    }

    void Disparar() {
        municao--;
        Debug.Log("🔥 FOGO! Munição restante: " + municao);
        
        GameObject tiro = Instantiate(projetilPlayerPrefab, transform.position + transform.forward * 1.5f, transform.rotation);
        tiro.tag = "TiroPlayer"; 
        Rigidbody rb = tiro.GetComponent<Rigidbody>();
        if (rb != null) rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
        Destroy(tiro, 2.0f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PowerupEscudo")) {
            Debug.Log("🛡️ ESCUDO ATIVADO!");
            AtivarEscudo();
            Destroy(other.gameObject);
        }
    }

    void AtivarEscudo() {
        temEscudo = true;
        if (escudoVisual != null) escudoVisual.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(DesativarEscudoDepoisDeTempo(7.0f));
    }

    IEnumerator DesativarEscudoDepoisDeTempo(float tempo) {
        yield return new WaitForSeconds(tempo);
        temEscudo = false;
        if (escudoVisual != null) escudoVisual.SetActive(false);
        Debug.Log("⚠️ ESCUDO ACABOU!");
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("InimigoCubo")) {
            if (temEscudo) {
                municao += 5; 
                Debug.Log("💎 ENERGIA CAPTURADA! Munição atual: " + municao);
                Destroy(collision.gameObject);
            } else {
                Perder();
            }
        }

        if (collision.gameObject.CompareTag("Projetil")) {
            if (temEscudo) {
                Debug.Log("🛡️ Projétil bloqueado pelo escudo!");
                Destroy(collision.gameObject);
            } else {
                Perder();
            }
        }
    }

    public void Ganhar() {
        if (jogoAcabou) return;
        jogoAcabou = true;
        Debug.Log("🏆🏆🏆 YOU WIN! O BOSS FOI DERROTADO! 🏆🏆🏆");
        StartCoroutine(ReiniciarAposTempo());
    }

    public void Perder() {
        if (jogoAcabou) return;
        jogoAcabou = true;
        Debug.Log("💀💀💀 GAME OVER! TU PERDESTE! 💀💀💀");
        StartCoroutine(ReiniciarAposTempo());
    }

    IEnumerator ReiniciarAposTempo() {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
