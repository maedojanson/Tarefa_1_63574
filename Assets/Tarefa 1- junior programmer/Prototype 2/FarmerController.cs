using UnityEngine;

public class FarmerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 15.0f;
    public float xRange = 15.0f;

    public GameObject projectilePrefab; 

    void Update()
    {
        // Movimento
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Limites
        if (transform.position.x < -xRange) { transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); }
        if (transform.position.x > xRange) { transform.position = new Vector3(xRange, transform.position.y, transform.position.z); }

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);
            Instantiate(projectilePrefab, spawnPos, projectilePrefab.transform.rotation);
        }
    }
}