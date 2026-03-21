using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCreadas : MonoBehaviour {


    public CartelResult posibleResults;

    public Image body;
    public Text texts1;
    public Text texts2;
    public Button play;

    public Button creadasButt;

    public Sprite yes;
    public Sprite no;

    private bool creadasResult;

    public void buttonSwap()
    {
        changeState(creadasButt);
        creadasResult = changeVariable(creadasResult); 
    }

    private bool changeVariable(bool current)
    {
        if (current)
        {
            current = false;
        }
        else
        {
            current = true;
        }
        return current;
    }

    private void changeState(Button current)
    {
        Text currentText = current.GetComponentInChildren<Text>();

        if (currentText.text == "SI")
        {
            currentText.text = "NO";
            current.image.sprite = no;
        }
        else
        {
            currentText.text = "SI";
            current.image.sprite = yes;
        }
    }

    public void jugar()
    {
        posibleResults.AddCreadas(creadasResult);

        body.enabled = false;
        play.image.enabled = false;

        creadasButt.image.enabled = false;
        texts1.enabled = false;
        texts2.enabled = false;
    }
}
