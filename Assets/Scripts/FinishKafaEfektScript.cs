using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishKafaEfektScript : MonoBehaviour
{
    [SerializeField] private GameObject _konfetiPaketi;

    public static FinishKafaEfektScript instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);
    }

    void Start()
    {
        _konfetiPaketi.SetActive(false);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _konfetiPaketi.SetActive(true);
        }
    }
    */

    public void KonfetiPatlat()
    {
        _konfetiPaketi.SetActive(true);

    }

}
