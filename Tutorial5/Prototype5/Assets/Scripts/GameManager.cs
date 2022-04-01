using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public int score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    private float SpawnRate = 1.0f;

    public Button restartButton;

    public bool gameIsActive;

    public GameObject titleScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObjects()
    {
        while (gameIsActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            Instantiate(targets[Random.Range(0, targets.Count)]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameIsActive = false;
        GameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        SpawnRate = SpawnRate / difficulty;
        gameIsActive = true;
        StartCoroutine(SpawnObjects());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}
