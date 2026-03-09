using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Se o animal for atingido pela Pizza
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);       // Morre o animal
            Destroy(other.gameObject); // Desaparece a pizza
        }
    }
}
