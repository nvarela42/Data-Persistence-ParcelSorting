using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLife : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<GameObject> spriteLife;

    void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (gameManager.life > 0 && gameManager.life < 6)
        {
            spriteLife[gameManager.life - 1].SetActive(false);
        }
    }
}
