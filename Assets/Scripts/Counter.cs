using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public TextMeshProUGUI CounterText;
    public int count = 0;

    private void Start()
    {
        count = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (IsGoodBox(other))
        {
            count += 10;
            gameManager.score += 10;
        }
        else
        {
            gameManager.score -= 5;
            count -= 5;
        }

        CounterText.text = "Score : " + gameManager.score;
        Destroy(other.gameObject);
    }

    private bool IsGoodBox(Collider other)
    {
        string tagName = gameObject.tag;
        if (other.CompareTag(tagName))
            return true;
        else
            return false;
    }
}
