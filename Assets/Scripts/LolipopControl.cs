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

            transform.tag = "Untagged";
            other.gameObject.tag = "Untagged";
            other.GetComponent<BoxCollider>().enabled = false;


            FindDividedLolipop();


            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().shouldDeleteObjects.Add(gameObject);
            player = null;
            transform.parent = other.gameObject.transform.GetChild(0).gameObject.transform;
            transform.localRotation = Quaternion.Euler(0, 0, 0);

            //transform.localScale = new Vector3(1, 1, 1);
            //transform.rotation = Quaternion.LookRotation(transform.position - other.transform.position);
            // transform.position = new Vector3(other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.x+0.3f, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.y+0.2f, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.z+0.8f);
            // transform.parent = other.gameObject.transform;
            //transform.DOMove(new Vector3(other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.x, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.y - 0.7f, other.gameObject.GetComponent<MouthPosition>().mouthPosition.transform.position.z + 0.2f), 10 * Time.deltaTime);
            transform.localPosition = new Vector3(0, -0.1f, -1);
            transform.localScale = transform.localScale * 1.5f;
            //transform.parent = other.transform;



            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().objectNumber -= 2;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().Spawn();
            //transform.localScale = new Vector3(1, 1, 1);
            //transform.eulerAngles = new Vector3(0, 180, 0);
            // transform.eulerAngles = other.gameObject.transform.eulerAngles;





        }

        if (other.gameObject.tag == "finishKafa")
        {
            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            player = null;
            FindDividedLolipop();
            transform.DOMove(new Vector3(0, 1, transform.position.z), 5 * Time.deltaTime);
            if (GameObject.FindGameObjectWithTag("Level1") != null)
            {
                transform.parent = GameObject.FindGameObjectWithTag("Level1").transform;
            }

            else if (GameObject.FindGameObjectWithTag("Level2") != null)
            {
                transform.parent = GameObject.FindGameObjectWithTag("Level2").transform;
            }

            else if (GameObject.FindGameObjectWithTag("Level3") != null)
            {
                transform.parent = GameObject.FindGameObjectWithTag("Level3").transform;
            }
            transform.tag = "Untagged";
            other.gameObject.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().objectNumber -= 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().shouldDeleteObjects.Add(gameObject);
            transform.eulerAngles = new Vector3(-90, 0, 0);

            other.GetComponent<FinishKafaEfektScript>().KonfetiPatlat();
        }

        if (other.gameObject.tag == "finishSonKafa")
        {
            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            player = null;
            FindDividedLolipop();
            transform.DOMove(new Vector3(0, 1, transform.position.z), 5 * Time.deltaTime);
            transform.parent = null;
            transform.tag = "Untagged";
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().shouldDeleteObjects.Add(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().objectNumber -= 1;

            transform.eulerAngles = new Vector3(-90, 0, 0);

            other.GetComponent<FinishKafaEfektScript>().KonfetiPatlat();

        }

        if (other.gameObject.tag == "x")
        {
            GameObject.FindGameObjectWithTag("CalculateX").GetComponent<CalculateX>().allX.Add(other.gameObject);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }

    void FindDividedLolipop() // Halkadan Ayr?lan Lolipopu Tespit Ediyor
    {

        for (int i = 0; i < 50; i++)
        {

            if (gameObject.name == "NewLolipop(Clone)")
            {

                if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops[i].gameObject.name == "NewLolipop")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops.RemoveAt(i);
                    break;
                }

            }

            else if (gameObject.name == "LimonluLolipop(Clone)")
            {

                if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops[i].gameObject.name == "LimonluLolipop")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops.RemoveAt(i);
                    break;
                }
            }

            else if (gameObject.name == "MorLolipop(Clone)")
            {

                if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops[i].gameObject.name == "MorLolipop")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops.RemoveAt(i);
                    break;
                }
            }

            else if (gameObject.name == "SariLolipop(Clone)")
            {

                if (GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops[i].gameObject.name == "SariLolipop")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnWithDistance>().nextLolipops.RemoveAt(i);
                    break;
                }
            }


        }

    }
}
