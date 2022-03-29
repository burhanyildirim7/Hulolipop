using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kafalarAnim : MonoBehaviour
{
    float distance;
    GameObject player;
    Animator kafaAnim;
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
        kafaAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
       
        if (distance<=15f)
        {
            kafaAnim.SetBool("saldiri", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        kafaAnim.SetBool("tutma", true);
        kafaAnim.SetBool("saldiri", false);
    }
}
