using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    [SerializeField] bool levelPassed;
    [SerializeField] bool gameIsOver;
    [SerializeField] int numberOfBricks;
    [SerializeField] int numberOfLives;
    [SerializeField] int currentScore;
    [SerializeField] int currentLevel;

    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Transform GameOverPanel;
    [SerializeField] Transform LoadLevelPanel;

    [SerializeField] Ball mainBall;
    [SerializeField] List<GameObject> allLevels;
    GameObject[] allBricks;
    GameObject currentLevelObject;

    private void Awake()
    {
        if(i == null)
        {
            i = this;
        }
        else
        {
            Destroy(i);
        }
    }
    private void Start()
    {
        LoadLevel();


        livesText.text = "Lives: " + numberOfLives;
        scoreText.text = "Score: " + currentScore;
    }

    void CountInitialBricks()
    {
        allBricks = GameObject.FindGameObjectsWithTag("Brick");
        for (int i = 0; i < allBricks.Length; i++)
        {
            var infiniteBrick = allBricks[i].GetComponent<InfiniteBrick>();

            if (!infiniteBrick)
                numberOfBricks++;
        }
    }
    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks == 0)
        {
            // level passed
            LevelCleared();

            if (currentLevel < allLevels.Count)
            {
               Invoke("LoadLevel", 3f);
            }
            else
            {
                //game over
            }
        }
    }
    void CleanupLevel()
    {
        currentLevelObject.SetActive(false);

    }
    private void LoadLevel()
    {
        currentLevelObject = Instantiate(allLevels[currentLevel], Vector2.zero, Quaternion.identity);
        levelPassed = false;
        LoadLevelPanel.gameObject.SetActive(false);
        CountInitialBricks();
    }

    private void LevelCleared()
    {
        levelPassed = true;
        CleanupLevel();


        currentLevel++;
        LoadLevelPanel.gameObject.SetActive(true);
        LoadLevelPanel.GetComponentInChildren<TMP_Text>().text = "Load Level " + (currentLevel + 1);
        //Destroy(allLevels[currentLevel--].transform);
        mainBall.ResetBall();
    }

    public void UpdateScore(int value)
    {
        currentScore += value;
        scoreText.text = "Score: " + currentScore;
    }
    public void UpdateNumberOfLives(int value = -1)
    {

        numberOfLives+= value;
        livesText.text = "Lives: " + numberOfLives;
        if (numberOfLives == 0)
        {
            // game over
            GameOver();
        }
    }

    void GameOver()
    {
        gameIsOver = true;
        GameOverPanel.gameObject.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Breakout");
    }
}
