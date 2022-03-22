using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LolipopControl : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.LookAt(player.transform.position);
        transform.GetChild(2).GetComponent<Animator>().enabled = false;
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "engel")
        {
            Debug.Log("Temas var");
            player = null;
            transform.rotation = Quaternion.LookRotation(transform.position - other.transform.position);
            // transform.position = new Vector3(other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.x+0.3f, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.y+0.2f, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.z+0.8f);
            // transform.parent = other.gameObject.transform;
            transform.DOMove( new Vector3(other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.x + 0.2f, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.y, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.z + 0.9f),10*Time.deltaTime);
         
            //transform.parent = other.transform;
            transform.parent = null;
            transform.tag = "Untagged";
            other.gameObject.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().objectNumber -= 2;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().Spawn();
            transform.localScale = new Vector3(1, 1, 1);
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
 
    }
}
