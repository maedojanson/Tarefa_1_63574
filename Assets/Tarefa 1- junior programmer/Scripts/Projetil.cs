using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float velocidadeBala = 20.0f;

    void Update()
    {
        transform.Translate(Vector3.up * velocidadeBala * Time.deltaTime);
        
        // Destruir se for para muito longe
        if (transform.position.z > 50 || transform.position.z < -50) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Mata o inimigo
            Destroy(gameObject);       // Destrói a bala
        }
    }
}
