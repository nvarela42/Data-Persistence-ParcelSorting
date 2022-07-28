using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DestroyLimite : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public TextMeshProUGUI lostText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Small") || other.CompareTag("Medium") || other.CompareTag("Big"))
        {
            gameManager.life += 1;
            Destroy(other.gameObject);
        }
        if (gameManager.life == 5)
        {
            gameManager.IsEndOfGame();
        }
    }
}
