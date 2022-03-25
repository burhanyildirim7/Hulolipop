using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    
    private GameObject Player;

    Vector3 aradakiFark;

    public float afterFinishCameraTransformX;
    public float afterFinishCameraTransformY;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        aradakiFark = transform.position - Player.transform.position;
    }


    void FixedUpdate()
    {


        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isFinish)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(afterFinishCameraTransformX, afterFinishCameraTransformY, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);
            transform.DORotate(new Vector3(0,-20,0),3*Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + aradakiFark.y + 5, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);
        }
     
           
      
    }

}
