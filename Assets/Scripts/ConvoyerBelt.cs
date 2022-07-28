using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoyerBelt : MonoBehaviour
{
    private float speed = 2.0f;
    [SerializeField] GameManager gameManager;

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.transform.Translate(gameObject.transform.right * (speed + gameManager.speedRate) * Time.deltaTime);
    }
}