using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text gameOverText;
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        gameOverText.text = "IS GOOD";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
