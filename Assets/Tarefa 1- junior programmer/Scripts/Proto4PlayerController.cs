using UnityEngine;
using System.Collections;

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

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Movimento com as SETAS do teclado ✅
        float verticalInput = 0;
        if (Input.GetKey(KeyCode.UpArrow)) verticalInput = 1;
        if (Input.GetKey(KeyCode.DownArrow)) verticalInput = -1;

        float horizontalInput = 0;
        if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1;

        // Aplica forças baseadas na direção da câmara
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        playerRb.AddForce(focalPoint.transform.right * speed * horizontalInput);

        // O indicador segue o jogador
        if(powerupIndicator != null)
        {
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Inimigo expulso!");
        }
    }
}
