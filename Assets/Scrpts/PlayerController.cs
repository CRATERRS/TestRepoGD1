using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float speed = 5f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");

        Vector3 playerMovement = Vector3.right * xMove * speed * Time.deltaTime; 
        transform.position += playerMovement;
    }
}
