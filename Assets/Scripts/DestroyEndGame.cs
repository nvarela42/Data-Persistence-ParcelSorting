using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEndGame : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!gameManager.isGameActive)
        {
            Destroy(gameObject);
        }
    }
}
