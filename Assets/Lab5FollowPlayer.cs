using UnityEngine;

public class Lab5FollowPlayer : MonoBehaviour
{
    [Header("Configurações do Alvo")]
    public GameObject player; 

    [Header("Ajustes em Tempo Real")]
    // Ao colocar 'public', estas opções aparecem no Inspector à direita ✅
    public Vector3 offset = new Vector3(0, 7, -10); 
    public float inclinacaoX = 45f; 

    void LateUpdate()
    {
        if (player != null)
        {
            // Atualiza a posição baseada no valor que defines no Inspector
            transform.position = player.transform.position + offset;
            
            // Atualiza a rotação baseada no valor que defines no Inspector
            transform.rotation = Quaternion.Euler(inclinacaoX, 0, 0);
        }
    }
}
