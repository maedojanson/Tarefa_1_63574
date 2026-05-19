using UnityEngine;
using UnityEngine.UI;

public class Proto5DifficultyButton : MonoBehaviour
{
    private Button proto5Button;
    private Prot5GameManager gameManager;

    [Header("Configuração de Dificuldade")]
    public int difficultyValue; // 1 = Easy, 2 = Medium, 3 = Hard ✅

    void Start()
    {
        proto5Button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<Prot5GameManager>();

        // Listener para detetar o clique no botão
        proto5Button.onClick.AddListener(SetProto5Difficulty);
    }

    void SetProto5Difficulty()
    {
        Debug.Log("Botão " + gameObject.name + " ativado!");
        gameManager.StartGame(difficultyValue);
    }
}
