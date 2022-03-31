using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KafaEfectScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem _efekt1;
    [SerializeField] private ParticleSystem _efekt2;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _efekt1.gameObject.SetActive(false);
            _efekt1.Stop();
            _efekt2.Play();
        }
    }

    public void SaskinEmojiBaslat()
    {
        _efekt1.Play();
    }
}
