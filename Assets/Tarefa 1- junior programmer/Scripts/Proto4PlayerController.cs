using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // NOVO: Necessário para fazer o Restart do jogo! ✅

public class Proto4PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    
    [Header("MOVIMENTO (SETAS)")]
    public float speed = 10.0f;
    
    [Header("POWERUP SYSTEM")]
    public bool hasPowerup = false;
    public float powerupStrength = 15.0f;
    public GameObject powerupIndicator; // Arrastar o anel rosa aqui no Inspector! ✅

    private bool jogoAcabou = false; // NOVO: Evita loops no Game Over ✅

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        if (jogoAcabou) return; // Se o jogo acabou, para o movimento

        // Movimento com as SETAS do teclado ✅
        float verticalInput = 0;
        if (Input.GetKey(KeyCode.UpArrow)) verticalInput = 1;
        if (Input.GetKey(KeyCode.DownArrow)) verticalInput = -1;

        float horizontalInput = 0;
        if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1;

        // Aplica forças baseadas na direção da câmara
        if (focalPoint != null)
        {
            playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
            playerRb.AddForce(focalPoint.transform.right * speed * horizontalInput);
        }

        // O indicador segue o jogador
        if (powerupIndicator != null)
        {
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }

        // NOVO: DETETAR QUEDA DA ILHA ✅
        if (transform.position.y < -10.0f)
        {
            GameOver("Caíste da ilha!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            if (powerupIndicator != null) powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StopCoroutine("PowerupCountdownRoutine"); // Reinicia o tempo se apanhares outro
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        if (powerupIndicator != null) powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // NOVO: Verificação de impacto com o inimigo ✅
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (hasPowerup)
            {
                // Se tens o powerup, empurras o inimigo!
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                if (enemyRigidbody != null)
                {
                    Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
                    enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
                    Debug.Log("🛡️ Inimigo expulso com super força!");
                }
            }
            else
            {
                // NOVO: Se NÃO tens powerup, é Game Over imediato! 💀
                GameOver("Foste atingido por um inimigo sem proteção!");
            }
        }
    }

    // NOVO: FUNÇÃO DE GAME OVER ✅
    void GameOver(string motivo)
    {
        if (jogoAcabou) return;
        jogoAcabou = true;

        Debug.Log("💀 GAME OVER: " + motivo);
        
        // Desativa a física para o player parar de se mover
        playerRb.linearVelocity = Vector3.zero; 
        playerRb.angularVelocity = Vector3.zero;

        // Reinicia a cena após 1.5 segundos
        Invoke("ReiniciarCena", 1.5f);
    }

    void ReiniciarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
