using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int life = 0;
    public float speedRate;
    public float spawnRate;
    public bool isGameActive;
    public Button restartButton;
    public List<Image> lifeImages;
    public GameObject[] packagePrefab;
    private TextMeshProUGUI buttonName;
    private Color gameOverTextColor = new Color(140, 13, 14, 255);
    private Color winTextColor = new Color(168, 255, 248, 255);
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private TextMeshProUGUI winOrOverText;
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private TextMeshProUGUI counterText;

    private void Start()
    {
        buttonName = restartButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonName.text = "Play Game";
    }
    public void StartGame()
    {
        foreach (var image in lifeImages)
        {
            image.gameObject.SetActive(true);
        }
        isGameActive = true;
        restartButton.gameObject.SetActive(false);
        endGameText.gameObject.SetActive(false);
        speedRate = 0.0f;
        spawnRate = 2.0f;
        score = 0;
        life = 0;
        counterText.text = "Score : " + score;
        StartCoroutine("SpeedIncrease");
        StartCoroutine("SpawnRandomPackage");
        restartButton.GetComponent<TextMeshProUGUI>(); 
    }

     private IEnumerator SpeedIncrease()
    {
        float increaseSpeed = 1.0f;
        float increaseSpawn = 0.1f;
        while (isGameActive)
        {
            Debug.Log("is increase");
            speedRate += increaseSpeed;
            if (spawnRate >= 0.5)
                spawnRate -= increaseSpawn;
            yield return new WaitForSecondsRealtime(10);
        }
        yield return null;
    }

    private IEnumerator SpawnRandomPackage()
    {
        while (isGameActive)
        {
            Debug.Log("SpawnRandomPackage is started");
            int packageIndex = Random.Range(0, packagePrefab.Length);
            Vector3 spawnPos = gameObject.transform.position;
            Instantiate(packagePrefab[packageIndex], spawnPos, gameObject.transform.rotation);
            Debug.Log("spawnRate : " + spawnRate);
            yield return new WaitForSecondsRealtime(spawnRate);
        }
    }
    public void IsEndOfGame()
    {
        isGameActive = false;
        endGameText.gameObject.SetActive(true);
        if (score <= 0)
        {
            winOrOverText.color = Color.red;
            endScoreText.color = gameOverTextColor;
            winOrOverText.text = "GAME OVER";
            endScoreText.text = "you have not scored any points :(";
            restartButton.gameObject.SetActive(true);


        }
        else
        {
            winOrOverText.color = Color.cyan;
            endScoreText.color = winTextColor;
            winOrOverText.text = "GOOD JOB !!";
            endScoreText.text ="Your score is : " + score;
            buttonName.text = "Restart Game";
            restartButton.gameObject.SetActive(true);
        }
    
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
