using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    // Riferimento al rigidbody dell'oggetto che viene sollevato dal Gravity Gun
    private Rigidbody objectToMove;

    // La distanza massima a cui l'oggetto può essere sollevato dal Gravity Gun
    public float maxDistance = 5f;

    // La forza con cui l'oggetto viene sollevato dal Gravity Gun
    public float moveForce = 1000f;

    // Funzione che viene chiamata quando si tiene premuto il tasto sinistro del mouse
    private void OnTriggerStay(Collider other)
    {
        // Controlla se l'oggetto ha un rigidbody
        if (other.GetComponent<Rigidbody>())
        {
            // Salva il riferimento al rigidbody dell'oggetto
            objectToMove = other.GetComponent<Rigidbody>();

            // Calcola la distanza tra l'oggetto e il Gravity Gun
            float distance = Vector3.Distance(transform.position, objectToMove.transform.position);

            // Se la distanza è inferiore alla distanza massima consentita, solleva l'oggetto
            if (distance <= maxDistance)
            {
                // Calcola la direzione in cui l'oggetto deve essere sollevato
                Vector3 moveDirection = transform.position - objectToMove.transform.position;

                // Applica la forza necessaria per sollevare l'oggetto nella direzione corretta
                objectToMove.AddForce(moveDirection.normalized * moveForce);
            }
        }
    }

    // Funzione che viene chiamata quando si rilascia il tasto sinistro del mouse
    private void OnTriggerExit(Collider other)
    {
        // Resetta il riferimento all'oggetto che era stato sollevato dal Gravity Gun
        objectToMove = null;
    }
}
