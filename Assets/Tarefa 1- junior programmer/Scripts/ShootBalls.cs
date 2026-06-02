using UnityEngine;

public class ShootBalls : MonoBehaviour
{
    public GameObject ballPrefab; 
    
    public float shootForce = 35.0f;
    public float upwardForce = 4.0f; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBall();
        }
    }

    void FireBall()
    {
        if (ballPrefab != null)
        {
            GameObject temporaryBall = Instantiate(ballPrefab, transform.position, transform.rotation);
            Rigidbody rb = temporaryBall.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                Vector3 launchDirection = (transform.forward * shootForce) + (transform.up * upwardForce);
                rb.AddForce(launchDirection, ForceMode.Impulse);
            }
            
            // REMOVIDO: O comando Destroy foi apagado! 
            // Agora as bolas ficam no cenário para sempre até encher o cesto.
        }
    }
}
