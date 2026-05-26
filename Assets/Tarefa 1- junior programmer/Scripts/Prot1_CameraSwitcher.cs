using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prot1_CameraSwitcher : MonoBehaviour
{
    // Modificadores públicos para arrastares no Inspector do Unity
    public Camera cameraPrincipal;
    public Camera cameraSecundaria;

    void Start()
    {
        // O jogo começa com a visão de trás ativa
        if (cameraPrincipal != null && cameraSecundaria != null)
        {
            cameraPrincipal.enabled = true;
            cameraSecundaria.enabled = false;
        }
    }

    void Update()
    {
        // Deteta quando a tecla 'C' é pressionada
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cameraPrincipal != null && cameraSecundaria != null)
            {
                // Inverte o estado de ativação das duas câmaras
                cameraPrincipal.enabled = !cameraPrincipal.enabled;
                cameraSecundaria.enabled = !cameraSecundaria.enabled;
                
                Debug.Log("Visão de câmara alterada!");
            }
        }
    }
}
