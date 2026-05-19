using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prot5GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    
    [Header("UI do Jogo")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen; // O objeto "Title Screen" que agrupa o menu ✅
    
    public bool isGameActive = false;

    void Start()
    {
        // O jogo aguarda o clique num Proto5DifficultyButton
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        
        // A dificuldade divide o spawnRate (ex: 1.0 / 3 = 0.33s entre frutas no Hard)
        spawnRate /= difficulty; 

        UpdateScore(0);
        StartCoroutine(SpawnTarget());
        
        titleScreen.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        if (isGameActive)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
