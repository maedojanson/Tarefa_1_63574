using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorObjet : MonoBehaviour
{
    public float speed = 15.0f;
    public float xRange = 15.0f;

    void Update()
    {
        // 1. Movimento Lateral Simples (Esquerda / Direita)
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // 2. Limites do ecrã para o boneco não fugir do mapa
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // 3. O DISPARO MÁGICO QUE PEDE MAÇÃS AO TEU MACAPOOL! 🍏🏊‍♂️
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Vai buscar uma maçã que esteja a descansar na piscina do MacaPool
            GameObject macaDaPiscina = MacaPool.SharedInstance.GetPooledObject();

            if (macaDaPiscina != null)
            {
                // Coloca a maçã na posição do teu Player (um bocadinho à frente)
                macaDaPiscina.transform.position = transform.position + new Vector3(0, 1, 1);
                macaDaPiscina.transform.rotation = transform.rotation;

                // Ativa a maçã! Ela acorda e voa!
                macaDaPiscina.SetActive(true);
            }
        }
    }
}
