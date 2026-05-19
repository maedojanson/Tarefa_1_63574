using UnityEngine;
using UnityEngine.UI;

public class Chall5DifficultyButton : MonoBehaviour
{
    private Button chall5Button;
    private Chall5GameManager gameManager;
    public int difficultyValue; 

    void Start()
    {
        chall5Button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<Chall5GameManager>();
        
        // Faz o botão funcionar automaticamente ✅
        chall5Button.onClick.AddListener(SetChall5Difficulty); 
    }

    public void SetChall5Difficulty() 
    {
        gameManager.StartGame(difficultyValue);
    }
}
