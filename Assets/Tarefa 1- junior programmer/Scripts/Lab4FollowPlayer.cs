using UnityEngine;

public class Lab4FollowPlayer : MonoBehaviour
{
    public GameObject player; // Arrastas o teu Player para aqui no Inspector
    private Vector3 offset = new Vector3(0, 5, -7); // Distância da câmara (ajusta como quiseres)

    void LateUpdate()
    {
        if (player != null)
        {
            // A câmara segue a posição do player mas mantém a distância (offset) ✅
            transform.position = player.transform.position + offset;
        }
    }
}
