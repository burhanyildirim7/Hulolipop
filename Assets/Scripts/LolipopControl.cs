using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LolipopControl : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //  transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
        transform.LookAt(player.transform.position);
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "engel")
        {
         
            player = null;
            transform.rotation = Quaternion.LookRotation(transform.position - other.transform.position);
            transform.position = other.gameObject.transform.position;
         
            transform.parent = other.transform;
            other.gameObject.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().objectNumber--;

        }
    }
}
