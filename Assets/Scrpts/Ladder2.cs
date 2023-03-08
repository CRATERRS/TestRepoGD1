using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder2 : MonoBehaviour
{
    public float climbSpeed = 3f;
    private bool isClimbing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float verticalInput = Input.GetAxisRaw("Vertical");
            Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();

            if (isClimbing)
            {
                playerRigidbody.velocity = new Vector3(0f, verticalInput * climbSpeed, 0f);
                playerRigidbody.useGravity = false;
            }
            else
            {
                playerRigidbody.useGravity = true;
            }
        }
    }
}
