using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDetector : MonoBehaviour
{
    public string result;

    void OnTriggerEnter(Collider col)
    {
        result = col.gameObject.name;
    }

}
