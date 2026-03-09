using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            // Step 5: Se o animal sair por baixo, o jogo acaba
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
