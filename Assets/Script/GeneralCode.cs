using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralCode : MonoBehaviour {

    public ColDetector colDet;
    public RuleteForce rulete;
    public CartelResult result;
    private string currentResult;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        currentResult = colDet.result;
    

        if (rulete.showResult)
        {
            rulete.showResult = false;
            result.Current(currentResult);
        }
	}
}
