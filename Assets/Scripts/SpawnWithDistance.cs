using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnWithDistance : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> nextLolipops = new List<GameObject>();

    public GameObject morLolipop;
    public GameObject sariLolipop;
    public GameObject limonluLolipop;
    public GameObject karpuzluLolipop;

    GameObject[] lolipop;

   

    

    public int objectNumber = 1;
    float rad = 2f;
    public void CreateEnemiesAroundPoint(int num, Vector3 point, float radius)
    {

        for (int i = 0; i < num; i++)
        {

            
            var radians = 2 * Mathf.PI / num * i;

            
            
            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);

            var spawnDir = new Vector3(horizontal, 0, vertical);

            
            var spawnPos = point + spawnDir * radius; 

           
            var unit = Instantiate(nextLolipops[i], spawnPos, Quaternion.identity) as GameObject;

     
            unit.transform.tag = "collected";
           
           unit.transform.parent = transform.GetChild(0).transform;

            //nextLolipops[i].AddComponent<LolipopControl>();
            

           

          unit.transform.Translate(new Vector3(0, 0, 0));

          
            
        }
    

    }

    private void Update()
    {
        for (var i = nextLolipops.Count - 1; i > -1; i--)
        {
            if (nextLolipops[i] == null)
                nextLolipops.RemoveAt(i);

        
        }

        if (nextLolipops.Count <= 0 && GetComponent<PlayerController>().isFinish)
        {
            GameObject.Find("KarakterPaketi").GetComponent<KarakterPaketiMovement>().enabled = false;
            GetComponent<PlayerController>().FinishScreen();
        }

    }

    public void Spawn()
    {
        DestroyLolipops();

      


        if (objectNumber >= 12)
        {
            rad = 2.3f;
            transform.localScale = new Vector3(1.3f, 1, 1.3f);
            
        }


        if (objectNumber >= 18)
        {
            rad = 2.6f;
            transform.localScale = new Vector3(1.6f, 1, 1.6f);

        }

        if (objectNumber >= 24)
        {
            rad = 2.9f;
            transform.localScale = new Vector3(1.9f, 1, 1.9f);

        }


        CreateEnemiesAroundPoint(objectNumber, transform.position, rad);
        objectNumber += 1;





    }

    public void SpawnAfterLips()
    {
        DestroyLolipops();
        objectNumber -= 1;
        //CreateEnemiesAroundPoint(objectNumber, transform.position, rad);
        Spawn();


        if (objectNumber >= 12)
        {
            rad = 2.3f;
            transform.localScale = new Vector3(1.3f, 1, 1.3f);

        }


        if (objectNumber >= 18)
        {
            rad = 2.6f;
            transform.localScale = new Vector3(1.6f, 1, 1.6f);

        }

        if (objectNumber >= 24)
        {
            rad = 2.9f;
            transform.localScale = new Vector3(1.9f, 1, 1.9f);

        }
    }

    

    public void DestroyLolipops()
    {
        lolipop = GameObject.FindGameObjectsWithTag("collected");

        for (int i = 0; i < lolipop.Length; i++)
        {

            Destroy(lolipop[i]);
        }
    }


}
