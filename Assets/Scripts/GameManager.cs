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
    public List<Image> lifeImages;
    public GameObject[] packagePrefab;
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private TextMeshProUGUI counterText;

    public void Start()
    {
        foreach (var image in lifeImages)
        {
            image.gameObject.SetActive(true);
        }
        isGameActive = true;
        speedRate = 0.0f;
        spawnRate = 2.0f;
        score = 0;
        life = 0;
        counterText.text = "Score : " + score;
        StartCoroutine("SpeedIncrease");
        StartCoroutine("SpawnRandomPackage");
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
        Debug.Log("is endof game");
        isGameActive = false;
        MainManager.instance.currentScore = score;
        MainManager.instance.isNotStartApp = true;
        MainManager.instance.SaveCurrentData();
        SceneManager.LoadScene(0);

    }

}
