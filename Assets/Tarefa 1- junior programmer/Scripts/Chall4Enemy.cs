using UnityEngine;

public class Chall4Enemy : MonoBehaviour
{
    // Baixei de 1.5f para 0.5f. Agora eles movem-se como caracóis! ✅
    public float speed = 0.5f; 
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        // Ele continua a procurar a tua baliza verde para te atacar devagarinho
        playerGoal = GameObject.Find("Player Goal");
    }

    void Update()
    {
        if (playerGoal != null)
        {
            // Calcula a direção para a baliza verde
            Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
            
            // Aplica a força de movimento (agora muito mais fraca) ✅
            enemyRb.AddForce(lookDirection * speed);
        }

        // Se o empurrares para fora e ele cair, ele desaparece
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
