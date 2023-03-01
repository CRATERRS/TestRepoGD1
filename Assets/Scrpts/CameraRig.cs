using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public Transform player;
    public float cameraDamp;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        //transform.position = player.position;

       //transform.position = Vector3.Lerp(transform.position, player.position, cameraDamp * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, cameraDamp * Time.deltaTime);
    }
}
