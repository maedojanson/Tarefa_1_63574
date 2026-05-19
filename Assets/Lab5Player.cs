using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class Lab5Player : MonoBehaviour
{
    [Header("Movimento e Rotação")]
    public float speed = 10.0f;
    public float turnSpeed = 720f; 
    private Rigidbody playerRb;
    private Animator playerAnim;

    [Header("Ataque & UI")]
    public int municao = 0;
    public GameObject projetilMaçaPrefab; 
    public TextMeshProUGUI municaoText;
    public TextMeshProUGUI mensagemText; 

    [Header("Escudo de Partículas")]
    public ParticleSystem particulasEscudo; 
    public bool temEscudo = false;

    private bool jogoAcabou = false;

    void Start() {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<Animator>();
        
        if (playerRb != null) {
            playerRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            playerRb.isKinematic = true; 
        }

        if (mensagemText != null) {
            mensagemText.text = "";
        }
        if (particulasEscudo != null) particulasEscudo.Stop();
        
        UpdateUI();
    }

    void Update() {
        if (jogoAcabou) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (moveDirection.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (playerAnim != null) {
            bool estaAndar = (moveDirection.magnitude > 0.1f);
            playerAnim.SetBool("Static_b", true);
            playerAnim.SetFloat("Speed_f", estaAndar ? 1.0f : 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && municao > 0) {
            DispararMaca();
        }

        if (transform.position.y < -5) PerderPorQueda();
    }

    void DispararMaca() {
        if (projetilMaçaPrefab == null) return;
        municao--;
        UpdateUI();
        
        Vector3 posicaoSpawn = transform.position + transform.forward * 1.5f + new Vector3(0, 1.2f, 0);
        GameObject tiro = Instantiate(projetilMaçaPrefab, posicaoSpawn, transform.rotation);
        
        tiro.tag = "TiroPlayer"; 

        Rigidbody rb = tiro.GetComponent<Rigidbody>();
        if (rb == null) rb = tiro.AddComponent<Rigidbody>();
        
        if (rb != null) {
            rb.isKinematic = false;
            rb.useGravity = false; 
            rb.linearVelocity = transform.forward * 25f; 
        }
        
        Destroy(tiro, 2.0f); 
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Municao")) {
            municao += 5;
            UpdateUI();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PowerupEscudo")) {
            Destroy(other.gameObject);
            StartCoroutine(AtivarEscudoRoutine());
        }
    }

    // MODIFICADO: MOSTRAR MENSAGEM DO ESCUDO NA UI ✅🛡️
    IEnumerator AtivarEscudoRoutine() {
        temEscudo = true;
        
        // Escreve a mensagem lá em baixo no ecrã!
        if (mensagemText != null) {
            mensagemText.text = "ESCUDO ATIVADO! 🛡️";
        }
        
        if (particulasEscudo != null) particulasEscudo.Play();

        // Espera os 7 segundos do powerup
        yield return new WaitForSeconds(7.0f);

        temEscudo = false;
        if (particulasEscudo != null) particulasEscudo.Stop();
        
        // Limpa a mensagem se o jogo ainda estiver a decorrer
        if (!jogoAcabou && mensagemText != null) {
            mensagemText.text = "";
        }
    }

    public void MarcarVitoria() {
        if (jogoAcabou) return;
        jogoAcabou = true;
        
        if (mensagemText != null) mensagemText.text = "WIN! 🏆";
        if (playerAnim != null) playerAnim.SetFloat("Speed_f", 0.0f);
        
        Invoke("ReiniciarCena", 2.0f);
    }

    public void UpdateUI() {
        if (municaoText != null) municaoText.text = "Maçãs: " + municao;
    }

    void PerderPorQueda() {
        if (jogoAcabou) return;
        jogoAcabou = true;
        Debug.Log("game over");
        if (mensagemText != null) mensagemText.text = "GAME OVER 💀";
        ReiniciarCena();
    }

    void ReiniciarCena() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
