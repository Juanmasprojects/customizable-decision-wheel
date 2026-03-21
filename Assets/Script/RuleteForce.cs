using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RuleteForce : MonoBehaviour {

    public Image ruletePoint;
    public float minSpeed;
    public float maxSpeed;
    public float minRandom;
    public float maxRandom;
    public bool showResult;

    private float finalSpeed;
    private bool startRotation;
    private bool rotating;
    private float timeToStop;
    private float currentTimeToStop;

	void Start ()
    {

	}

    public void Fuerza()
    {
        if(!rotating)
        {
            timeToStop = currentTimeToStop = Random.Range(minRandom, maxRandom);
            finalSpeed = Random.Range(minSpeed, maxSpeed);
            startRotation = true;
        }  
    }

    void Update()
    {
        if (startRotation)
        {
            rotating = true;
            transform.Rotate(-Vector3.forward * finalSpeed);

            currentTimeToStop -= Time.deltaTime;
            if(currentTimeToStop <= 0)
            {
                currentTimeToStop = timeToStop;
                startRotation = false;
                rotating = false;
                showResult = true;
            }
        }
    }

}
