using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] int day = 13;
    [SerializeField] float  myFloat = 4.5f;

    [Header("Combat")]
    [SerializeField] bool myBool = true;
    [SerializeField] string myString = "asfnkasnc";



    public LayerMask mask;


  
    // Start is called before the first frame update
    void Start()
    {
        myString = LogDay(day);
        LogDay(23);
        LogDay(12);

        float sunResult = Sum(day, myFloat);

    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public string LogDay(int dayToLog)
    {
       dayToLog = dayToLog + 1;
       string messageOfTheDay = $"Oggi e il giorno {dayToLog} febbraio";

       //Debug.Log("Oggi e il giorno" + 8 + " febbraio" );
       Debug.Log(messageOfTheDay);

       return messageOfTheDay;
    }

    float Sum(float a, float b)
    {
        return a + b; 
    }


    void MyMethod()
    {

    }

}
