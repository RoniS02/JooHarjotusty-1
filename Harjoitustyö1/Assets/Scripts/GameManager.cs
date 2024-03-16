using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float score;
    public int pips;
    public int levelToChange;
    public TextMeshProUGUI scoreText;
    private PlayerController playerControllerScript;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button QuitButton;
    public int scoreGoal;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        pips = 1;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            score += pips * Time.deltaTime;
            scoreText.text = "Score: " + Mathf.Round(score);
        }
        if (playerControllerScript.gameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            QuitButton.gameObject.SetActive(true);
        }

        if (score >= scoreGoal)
        {
            SceneManager.LoadScene(levelToChange);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

}
