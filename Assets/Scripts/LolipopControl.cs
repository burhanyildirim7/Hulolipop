using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LolipopControl : MonoBehaviour
{
    public GameObject player;

    private bool isFinish = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isFinish == false)
        {
            if (player != null)
            {
                transform.LookAt(player.transform.position);
            }


          
        }
    }

     void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "engel")
        {

            FindDividedLolipop();




            player = null;
            transform.rotation = Quaternion.LookRotation(transform.position - other.transform.position);
            // transform.position = new Vector3(other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.x+0.3f, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.y+0.2f, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.z+0.8f);
            // transform.parent = other.gameObject.transform;
            transform.DOMove( new Vector3(other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.x, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.y-0.5f, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.z + 0.9f),10*Time.deltaTime);
         
            //transform.parent = other.transform;
            transform.parent = null;
            transform.tag = "Untagged";
            other.gameObject.tag = "Untagged";
            
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().objectNumber -= 2;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().Spawn();
            transform.localScale = new Vector3(1, 1, 1);
            transform.eulerAngles = new Vector3(0, 180, 0);

        }

        if (other.gameObject.tag == "finishKafa")
        {
            player = null;
            transform.DOMove(new Vector3(0,1,transform.position.z),5*Time.deltaTime);
            transform.parent = null;
            transform.tag = "Untagged";
            other.gameObject.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().objectNumber -= 1;
            
            transform.eulerAngles = new Vector3(-90, 0, 0);
        }
    }

    void FindDividedLolipop() // Halkadan Ayrýlan Lolipopu Tespit Ediyor
    {
   
        for (int i = 0; i < 20; i++)
        {

            if (gameObject.name == "NewLolipop(Clone)")
            {
                Debug.Log("Ayrýlan Obje Adý = KARPUZ ");
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops[i].gameObject.name == "NewLolipop")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops.RemoveAt(i);
                    break;
                }

            }

            else if (gameObject.name == "LimonluLolipop(Clone)")
            {
                Debug.Log("Ayrýlan Obje Adý = Limon ");
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops[i].gameObject.name == "LimonluLolipop")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops.RemoveAt(i);
                    break;
                }
            }

            else if (gameObject.name == "MorLolipop(Clone)")
            {
                Debug.Log("Ayrýlan Obje Adý = Mor ");
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops[i].gameObject.name == "MorLolipop")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops.RemoveAt(i);
                    break;
                }
            }

            else if (gameObject.name == "SarýLolipop(Clone)")
            {
                Debug.Log("Ayrýlan Obje Adý = Sarý ");
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops[i].gameObject.name == "SarýLolipop")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops.RemoveAt(i);
                    break;
                }
            }

         
        }

    }
}
