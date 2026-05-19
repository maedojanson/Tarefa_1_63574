using UnityEngine;

public class Prot5Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private Prot5GameManager gameManager;

    [Header("Efeitos")]
    public GameObject explosionParticle; 

    [Header("Configurações")]
    public int pointValue;
    private float minSpeed = 16; 
    private float maxSpeed = 20; 
    private float maxTorque = 2;
    private float xRange = 4;
    private float ySpawnPos = -6; 

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<Prot5GameManager>();

        // Física básica
        targetRb.mass = 1.0f;
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
        
        // Salto inicial
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.VelocityChange);
        targetRb.AddTorque(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), ForceMode.VelocityChange);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);
            
            // Explosão e Cor
            GameObject explosion = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            var mainModule = explosion.GetComponent<ParticleSystem>().main;

            if (gameObject.name.Contains("Carne")) { mainModule.startColor = Color.red; }
            else if (gameObject.name.Contains("Pizza")) { mainModule.startColor = new Color(1f, 0.5f, 0f); }
            else if (gameObject.name.Contains("Pao") || gameObject.name.Contains("Sandes")) { mainModule.startColor = Color.green; }
            else { mainModule.startColor = Color.gray; }

            // Se for a pedra (valor negativo), Game Over
            if (pointValue < 0) {
                gameManager.GameOver();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Se bater no sensor lá em baixo
        if (other.CompareTag("Sensor")) 
        {
            Destroy(gameObject);
            
            // Se for comida (ponto positivo) e cair, perdeu!
            if (gameManager.isGameActive && pointValue > 0) 
            {
                gameManager.GameOver();
            }
        }
    }
}
