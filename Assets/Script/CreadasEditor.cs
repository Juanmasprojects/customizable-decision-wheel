using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreadasEditor : MonoBehaviour {

    public Image typeSelector;
    public Image FondoEditor;
    public InputField NameEditor;
    public Text placeholder;
    public Text Desc;
    public Text TypeDesc;
    public Image Crear2;
    public Image Atras2;
    public Image Crear;
    public Image Atras;
    public Image Siguiente;
    public Image Menu;

    public Text show1;
    public Text show2;
    public Text show3;
    public Text show4;
    public Text show5;
    public Text show6;

    public Sprite typeYoNunca;
    public Sprite typePrenda;
    public Sprite typeCastigo;
    public Sprite typeCascada;
    public Sprite typePremio;
    public Sprite typeShot;
    public Sprite typeTragos;
    public Sprite ActSiguiente;
    public Sprite ActAtras;
    public Sprite DeactSiguiente;
    public Sprite DeactAtras;

    private int currentPage = 1;
    private int currentType = 1;
    private string typeString;
    private List<Creadas> created = new List<Creadas>();

    void Start()
    {
        DesactivarEditor();
        LoadPreferences();
    }

    void Update()
    {
        switch (currentType)
        {
            case 1:
                typeSelector.sprite = typeYoNunca;
                TypeDesc.text = "YO NUNCA";
                typeString = "YONUNCA";
                break;
            case 2:
                typeSelector.sprite = typePrenda;
                TypeDesc.text = "PRENDA";
                typeString = "PRENDA";
                break;
            case 3:
                typeSelector.sprite = typeCastigo;
                TypeDesc.text = "CASTIGO";
                typeString = "CASTIGO";
                break;
            case 4:
                typeSelector.sprite = typeCascada;
                TypeDesc.text = "CASCADA";
                typeString = "CASCADA";
                break;
            case 5:
                typeSelector.sprite = typePremio;
                TypeDesc.text = "PREMIO";
                typeString = "PREMIO";
                break;
            case 6:
                typeSelector.sprite = typeShot;
                TypeDesc.text = "SHOT";
                typeString = "SHOT";
                break;
            case 7:
                typeSelector.sprite = typeTragos;
                TypeDesc.text = "TRAGOS";
                typeString = "TRAGOS";
                break;
        }

        if (created.Count > currentPage + 5)
        {
            Siguiente.sprite = ActSiguiente;
        }
        else
        {
            Siguiente.sprite = DeactSiguiente;
        }

        if (currentPage > 1)
        {
            Atras.sprite = ActAtras;
        }
        else
        {
            Atras.sprite = DeactAtras;
        }
    }

    private void LoadPreferences ()
    {
        if(PlayerPrefs.HasKey("TOTAL DATA"))
        {
            int MaxCount = PlayerPrefs.GetInt("TOTAL DATA");
            for (int i = 0; i < MaxCount; i++)
            {
                Creadas newCreada = new Creadas();
                newCreada.Name = PlayerPrefs.GetString("DATO " + i + " NAME");
                newCreada.Type = PlayerPrefs.GetString("DATO " + i + " TYPE");

                created.Add(newCreada);               
            }

            ActualizarShow();
        }
      
    }

    private void ActualizarShow()
    {
        TextActualization(show1, currentPage);
        TextActualization(show2, currentPage + 1);
        TextActualization(show3, currentPage + 2);
        TextActualization(show4, currentPage + 3);
        TextActualization(show5, currentPage + 4);
        TextActualization(show6, currentPage + 5);
    }

    private void TextActualization(Text currentShow, int currentValue)
    {
        if (created.Count >= currentValue)
        {
            currentShow.text = "(" + created[currentValue - 1].Type + ") " + created[currentValue - 1].Name;
        }
        else
        {
            currentShow.text = "<< Aun no has creado algo aquí >>";
        }
    }

    public void Prev()
    {
        if (currentPage > 1)
        {
            currentPage -= 6;
            ActualizarShow();
        }
    }

    public void Next()
    {
        if (created.Count > currentPage + 5)
        {
            currentPage += 6;
            ActualizarShow();
        }
    }

    public void BorrarPrenda(int currentShow)
    {
        if(created.Count>=currentShow+currentPage)
        {
            for (int i = 0; i <= created.Count; i++)
            {
                if (i + 1 == currentShow + currentPage)
                {
                    created.RemoveAt(i);
                }
            }
        }
        ActualizarShow();
    }

    public void typeSwitch ()
    {
        if(currentType>=7)
        {
            currentType = 1;
        }
        else
        {
            currentType++;
        }
    }

    public void AbrirEditor()
    {
        ActivarEditor();
        DesactivarBotones();
    }

    public void CerrarEditor ()
    {
        DesactivarEditor();
        ActivarBotones();
    }

    public void CrearNuevaPrenda()
    {
        Creadas newCreada = new Creadas();
        newCreada.Name = Desc.text;
        newCreada.Type = typeString;

        created.Add(newCreada);

        ActualizarShow();
        DesactivarEditor();
        ActivarBotones();
    }

    public void Back ()
    {
        Save();
        StartCoroutine(LoadAsync("Menu"));
    }

    private void Save()
    {
        PlayerPrefs.DeleteAll();

        int i;
        for (i = 0; i < created.Count; i++)
        {
            PlayerPrefs.SetString("DATO " + i + " NAME", created[i].Name);
            PlayerPrefs.SetString("DATO " + i + " TYPE", created[i].Type);
        }
        PlayerPrefs.SetInt("TOTAL DATA", i);
        PlayerPrefs.Save();

    }

    IEnumerator LoadAsync(string escena)
    {
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(escena, LoadSceneMode.Single);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void DesactivarEditor ()
    {
        TypeDesc.enabled = false;
        typeSelector.enabled = false;
        FondoEditor.enabled = false;
        NameEditor.enabled = false;
        NameEditor.image.enabled = false;
        placeholder.enabled = false;
        Desc.enabled = false;
        Crear2.enabled = false;
        Atras2.enabled = false;
    }

    private void DesactivarBotones ()
    {
        Crear.enabled = false;
        Atras.enabled = false;
        Siguiente.enabled = false;
        Menu.enabled = false;
    }

    private void ActivarBotones()
    {
        Crear.enabled = true;
        Atras.enabled = true;
        Siguiente.enabled = true;
        Menu.enabled = true;
    }

    private void ActivarEditor()
    {
        TypeDesc.enabled = true;
        typeSelector.enabled = true;
        FondoEditor.enabled = true;
        NameEditor.enabled = true;
        NameEditor.image.enabled = true;
        placeholder.enabled = true;
        Desc.enabled = true;
        Crear2.enabled = true;
        Atras2.enabled = true;
    }




}
