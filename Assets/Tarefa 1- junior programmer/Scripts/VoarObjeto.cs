using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoarObjeto : MonoBehaviour
{
    public float speed = 25.0f;
    private float topBound = 30.0f; // Limite superior do mapa

    void Update()
    {
        // Faz a maçã voar sempre para a frente
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Se a maçã passar do limite do mapa (sair do ecrã)...
        if (transform.position.z > topBound)
        {
            // EM VEZ DE DESTROY, DESATIVAMOS A MAÇÃ! ❌🏊‍♂️
            // Ela fica invisível e volta "adormecida" para dentro do teu MacaPool!
            gameObject.SetActive(false);
        }
    }
}
