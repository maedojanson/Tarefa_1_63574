using UnityEngine;

public class Chall5Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private Chall5GameManager gameManager;
    
    [Header("Configurações de Salto")]
    public float xRange = 4;
    public float ySpawnPos = -6; 

    [Header("Efeitos e Pontos")]
    public int pointValue;
    public GameObject explosionParticle;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = Object.FindAnyObjectByType<Chall5GameManager>();

        float speedBase = 8f;
        float speedMultiplier = gameManager != null ? gameManager.dificuldadeAtual : 1;
        float finalSpeed = speedBase + (speedMultiplier * 5f);

        targetRb.constraints = RigidbodyConstraints.FreezeRotationZ;
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        targetRb.AddForce(Vector3.up * finalSpeed, ForceMode.VelocityChange);
        
        float torque = 0.5f * speedMultiplier;
        targetRb.AddTorque(Random.Range(-torque, torque), Random.Range(-torque, torque), 0, ForceMode.VelocityChange);
        
        // Aumentei um pouco o tempo de vida para garantir que ele chega ao sensor
        Destroy(gameObject, 5.0f); 
    }

    private void OnMouseDown()
    {
        if (gameManager != null && gameManager.isGameActive)
        {
            if (explosionParticle != null) 
            {
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            }

            // Se clicar na Pedra (valor negativo), GAME OVER ✅
            if (pointValue < 0)
            {
                gameManager.GameOver();
            }
            else
            {
                gameManager.UpdateScore(pointValue);
            }

            Destroy(gameObject);
        }
    }

    // ESTA É A FUNÇÃO QUE CONTROLA A QUEDA ✅
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            // Se o jogo ainda estiver ativo
            if (gameManager != null && gameManager.isGameActive)
            {
                // REGRA: Se o que caiu NÃO for a pedra (Bad), significa que deixaste passar comida.
                // Logo... GAME OVER!
                if (!gameObject.CompareTag("Bad"))
                {
                    gameManager.GameOver();
                }
            }
            
            Destroy(gameObject);
        }
    }
}
