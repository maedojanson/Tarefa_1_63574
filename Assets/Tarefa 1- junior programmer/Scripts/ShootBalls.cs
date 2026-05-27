using UnityEngine;

public class ShootBalls : MonoBehaviour
{
    // Arrastamos o nosso modelo (Prefab) da bola para aqui no Inspector
    public GameObject ballPrefab; 
    
    // Força do disparo das bolas
    public float shootForce = 25.0f;
    public float upwardForce = 8.0f;

    void Update()
    {
        // Sempre que pressionas a Barra de Espaço, uma bola nova é disparada!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBall();
        }
    }

    void FireBall()
    {
        if (ballPrefab != null)
        {
            // Cria a bola na posição atual da câmara
            GameObject temporaryBall = Instantiate(ballPrefab, transform.position, transform.rotation);
            
            // Pega no componente físico da bola para aplicar o empurrão
            Rigidbody rb = temporaryBall.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                // Calcula a direção (para a frente da câmara + um arco para cima)
                Vector3 launchDirection = (transform.forward * shootForce) + (transform.up * upwardForce);
                
                // Aplica a força instantânea de um disparo
                rb.AddForce(launchDirection, ForceMode.Impulse);
            }
            
            // Destrói a bola após 5 segundos para o computador não ficar lento com centenas de esferas
            Destroy(temporaryBall, 5.0f);
        }
    }
}
