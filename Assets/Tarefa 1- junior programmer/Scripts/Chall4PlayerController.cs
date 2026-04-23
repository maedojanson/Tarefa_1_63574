using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Chall4PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    
    public float speed = 15.0f;
    public float turboSpeed = 25.0f;
    private float currentSpeed;

    public bool hasPowerup = false;
    public float powerupStrength = 20.0f;
    public GameObject powerupIndicator;
    public ParticleSystem smokeParticle; // Arrastar o "Smoke_Particle" para aqui! ✅

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        currentSpeed = speed;
    }

    void Update()
    {
        // 1. CONTROLOS: SETAS PARA MOVER ✅
        float verticalInput = 0;
        float horizontalInput = 0;
        if (Input.GetKey(KeyCode.UpArrow)) verticalInput = 1;
        if (Input.GetKey(KeyCode.DownArrow)) verticalInput = -1;
        if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1;

        // 2. TURBO (ESPAÇO)
        if (Input.GetKey(KeyCode.Space)) {
            currentSpeed = turboSpeed;
        } else {
            currentSpeed = speed;
        }

        // 3. LÓGICA DAS PARTÍCULAS: SÓ SAEM COM POWERUP ✅
        if (hasPowerup) {
            if (smokeParticle != null && !smokeParticle.isPlaying) {
                smokeParticle.Play();
            }
        } else {
            if (smokeParticle != null && smokeParticle.isPlaying) {
                smokeParticle.Stop();
            }
        }

        playerRb.AddForce(focalPoint.transform.forward * currentSpeed * verticalInput);
        playerRb.AddForce(focalPoint.transform.right * currentSpeed * horizontalInput);

        // Game Over por queda
        if (transform.position.y < -5) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(powerupIndicator != null) {
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            if (powerupIndicator != null) powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        if (powerupIndicator != null) powerupIndicator.SetActive(false);
        // As partículas param automaticamente no Update quando hasPowerup vira false ✅
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
