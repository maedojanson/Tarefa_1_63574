using UnityEngine;

public sealed class FollowPlayer : MonoBehaviour
{
    public GameObject player; 
    // Valores sugeridos para ver o carro de cima e de trás
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10); 

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }
}