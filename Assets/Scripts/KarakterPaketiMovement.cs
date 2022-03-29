using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterPaketiMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Start()
    {
     
    }


    void FixedUpdate()
    {
        if (GameController.instance.isContinue == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finishTrigger")
        {
            StartCoroutine(speedControl());
        }
    }

    IEnumerator speedControl()
    {
        _speed = 0;
        yield return new WaitForSeconds(1);
        _speed = 15;
    }

}
