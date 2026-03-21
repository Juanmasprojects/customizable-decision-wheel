using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CartelResult : MonoBehaviour {

    public Image body;
    public Text description;
    public Sprite bodyYONUNCA;
    public Sprite bodyPRENDA;
    public Sprite bodyCASCADA;
    public Sprite bodyPREMIO;
    public Sprite bodyCASTIGO;
    public Sprite bodySHOT;
    public Sprite bodyTRAGOS;

    public List<string> descYONUNCA;
    public List<string> descPRENDA;
    public List<string> descCASCADA;
    public List<string> descPREMIO;
    public List<string> descCASTIGO;
    public List<string> descSHOT;
    public List<string> descTRAGOS;

    public List<string> YONUNCAhot;
    public List<string> PRENDAhot;
    public List<string> CASCADAhot;
    public List<string> SHOThot;
    public List<string> CASTIGOhot;
    public List<string> TRAGOShot;
    public List<string> PREMIOhot;

    public List<string> YONUNCAraro;
    public List<string> PRENDAraro;
    public List<string> SHOTraro;
    public List<string> CASTIGOraro;
    public List<string> TRAGOSraro;
    public List<string> PREMIOraro;

    public List<string> PRENDAmove;
    public List<string> CASTIGOmove;
    public List<string> CASCADAmove;

    public List<string> YONUNCAnormal;
    public List<string> PRENDAnormal;
    public List<string> CASCADAnormal;
    public List<string> SHOTnormal;
    public List<string> TRAGOSnormal;


    private List<string> descYONUNCAusados = new List<string>();
    private List<string> descPRENDAusados = new List<string>();
    private List<string> descCASCADAusados = new List<string>();
    private List<string> descPREMIOusados = new List<string>();
    private List<string> descCASTIGOusados = new List<string>();
    private List<string> descSHOTusados = new List<string>();
    private List<string> descTRAGOSusados = new List<string>();

    void Start()
    {
        body.enabled = false;
        description.enabled = false;
    }

    public void Personalization(bool hot, bool move, bool raro, bool normal)
    {
        if (hot)
        {
            addList(YONUNCAhot, descYONUNCA);
            addList(PRENDAhot, descPRENDA);
            addList(CASCADAhot, descCASCADA);
            addList(SHOThot, descSHOT);
            addList(CASTIGOhot, descCASTIGO);
            addList(TRAGOShot, descTRAGOS);
            addList(PREMIOhot, descPREMIO);
        }
        if (move)
        {
            addList(PRENDAmove, descPRENDA);
            addList(CASCADAmove, descCASCADA);
            addList(CASTIGOmove, descCASTIGO);
        }
        if (raro)
        {
            addList(YONUNCAraro, descYONUNCA);
            addList(PRENDAraro, descPRENDA);
            addList(SHOTraro, descSHOT);
            addList(CASTIGOraro, descCASTIGO);
            addList(TRAGOSraro, descTRAGOS);
            addList(PREMIOraro, descPREMIO);
        }
        if (normal)
        {
            addList(YONUNCAnormal, descYONUNCA);
            addList(PRENDAnormal, descPRENDA);
            addList(CASCADAnormal, descCASCADA);
            addList(SHOTnormal, descSHOT);
            addList(TRAGOSnormal, descTRAGOS);
        }
    }

    public void AddCreadas(bool creadas)
    {
        if (creadas)
        {
            if (PlayerPrefs.HasKey("TOTAL DATA"))
            {
                int MaxCount = PlayerPrefs.GetInt("TOTAL DATA");
                for (int i = 0; i < MaxCount; i++)
                {
                    string newType = PlayerPrefs.GetString("DATO " + i + " TYPE");
                    string newDesc = PlayerPrefs.GetString("DATO " + i + " NAME");
                    switch (newType)
                    {
                        case "YONUNCA":
                            descYONUNCA.Add(newDesc);
                            break;
                        case "PRENDA":
                            descPRENDA.Add(newDesc);
                            break;
                        case "CASTIGO":
                            descCASTIGO.Add(newDesc);
                            break;
                        case "PREMIO":
                            descPREMIO.Add(newDesc);
                            break;
                        case "TRAGOS":
                            descTRAGOS.Add(newDesc);
                            break;
                        case "SHOT":
                            descSHOT.Add(newDesc);
                            break;
                        case "CASCADA":
                            descCASCADA.Add(newDesc);
                            break;
                    }
                }

               
            }
        }
    }

    private void addList (List<string> origen, List<string> destino)
    {
        for (var i= 0; i< origen.Count; i++)
        {
            destino.Add(origen[i]);
        }
    }

    public void Current (string imagen)
    {
        switch(imagen)
        {
            case "YONUNCA":
                changeImage(bodyYONUNCA);
                selectText(descYONUNCA,descYONUNCAusados);
                break;
            case "PRENDA":
                changeImage(bodyPRENDA);
                selectText(descPRENDA,descPRENDAusados);
                break;
            case "SHOT":
                changeImage(bodySHOT);
                selectText(descSHOT,descSHOTusados);
                break;
            case "CASTIGO":
                changeImage(bodyCASTIGO);
                selectText(descCASTIGO,descCASTIGOusados);
                break;
            case "CASCADA":
                changeImage(bodyCASCADA);
                selectText(descCASCADA,descCASCADAusados);
                break;
            case "PREMIO":
                changeImage(bodyPREMIO);
                selectText(descPREMIO,descPREMIOusados);
                break;
            case "TRAGOS":
                changeImage(bodyTRAGOS);
                selectText(descTRAGOS,descTRAGOSusados);
                break;
        }
    }

    private void changeImage (Sprite currentbody)
    {
        body.sprite = currentbody;
        body.enabled = true;
    }

    private void selectText(List<string> currenttext, List<string> currenttrash)
    {
        if (currenttext.Count == 0)
        {
            for (int i=0; i<currenttrash.Count;i++)
            {
                currenttext.Add(currenttrash[i]);
            }
            currenttrash.Clear();
        }
        int resultado = Random.Range(0, currenttext.Count);
         for (int i = 0; i <= resultado; i++)
         {
            if (i==resultado)
                {
                description.text = currenttext[i];
                currenttrash.Add(currenttext[i]);
                currenttext.RemoveAt(i);
                }
         }
         description.enabled = true;    
    }

    public void Click ()
    {
        body.enabled = false;
        description.enabled = false;
    }
}
