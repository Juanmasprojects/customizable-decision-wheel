using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Premium : MonoBehaviour {

    public CartelResult posibleResults;

    public Image body;
    public List<Text> texts;
    public Button play;
    
    public Button hotButt;
    public Button moveButt;
    public Button raroButt;
    public Button normalButt;

    public Sprite yes;
    public Sprite no;

    private bool HOTresults;
    private bool MOVEresults;
    private bool RAROresults;
    private bool NORMALresults = true;

    public void buttonSwap (string currentButton)
    {
       switch(currentButton)
        {
            case "HOT":
                changeState(hotButt);
                HOTresults = changeVariable(HOTresults);
            break;
            case "MOVE":
                changeState(moveButt);
                MOVEresults = changeVariable(MOVEresults);
            break;
            case "RARO":
                changeState(raroButt);
                RAROresults = changeVariable(RAROresults);
            break;
            case "NORMAL":
                changeState(normalButt);
                NORMALresults = changeVariable(NORMALresults);
            break;
        }
    }

    private bool changeVariable (bool current)
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
        
        if( currentText.text == "SI")
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

    public void jugar ()
    {
        posibleResults.Personalization(HOTresults, MOVEresults, RAROresults, NORMALresults);

        body.enabled = false;
        play.image.enabled = false;

        hotButt.image.enabled = false;
        moveButt.image.enabled = false;
        raroButt.image.enabled = false;
        normalButt.image.enabled = false;

        foreach (Text item in texts)
        {
            item.enabled = false;
        }
    }
}
