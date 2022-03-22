using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWithDistance : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obje;

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

           
            var unit = Instantiate(obje, spawnPos, Quaternion.identity) as GameObject;
            Debug.Log(spawnPos);
            unit.transform.tag = "collected";
            unit.transform.parent = transform;
         
     
            

           

            unit.transform.Translate(new Vector3(0, 0, 0));

          
            
        }
    

    }

    private void Update()
    {
   
    }

    public void Spawn()
    {
        DestroyLolipops();

          CreateEnemiesAroundPoint(objectNumber, transform.position, rad);
        objectNumber += 1;

        if (objectNumber == 16 || objectNumber == 26)
        {
            rad += 0.15f;
            transform.localScale += new Vector3(0.3f, 0, 0.3f);
        }






        if (objectNumber == 28)
        {
            rad += 0.08f;
            transform.localScale += new Vector3(0.12f, 0, 0.12f);
        }
      
    }

    public void SpawnAfterLips()
    {
        DestroyLolipops();
        objectNumber -= 1;
        CreateEnemiesAroundPoint(objectNumber, transform.position, rad);
        

        if (objectNumber == 16 || objectNumber == 26)
        {
            rad += 0.15f;
            transform.localScale += new Vector3(0.3f, 0, 0.3f);
        }






        if (objectNumber == 28)
        {
            rad += 0.08f;
            transform.localScale += new Vector3(0.12f, 0, 0.12f);
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
