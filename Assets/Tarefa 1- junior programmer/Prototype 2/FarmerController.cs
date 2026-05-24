using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    [SerializeField] private float xRange = 20.0f;

    void Update()
    {
        // 1. Movimento Lateral do Fazendeiro
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // 2. Barreira para não fugir das bordas do ecrã
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // 3. Disparar a Pizza usando o PizzaPooler (CORRIGIDO!)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Alterado de ObjectPooler para PizzaPooler para encontrar o teu script novo!
            GameObject pooledProjectile = PizzaPooler.SharedInstance.GetPooledObject();
            
            if (pooledProjectile != null)
            {
                pooledProjectile.transform.position = transform.position;
                pooledProjectile.transform.rotation = transform.rotation;
                pooledProjectile.SetActive(true); // Ativa a pizza no jogo!
            }
        }
    }
}