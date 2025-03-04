using System;
using UnityEngine;

public class ParedesInvisibles : MonoBehaviour
{
    public GameObject metaInicial;
    public GameObject metaFinal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            metaInicial.SetActive(true);
            metaFinal.SetActive(false);
        }
    }
}
