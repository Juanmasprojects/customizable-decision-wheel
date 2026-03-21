using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Button jugar;
    public Button instrucciones;
    public Button cerrar;
    public Button normal;
    public Button personalizada;
    public Button atras;
    public Button crear;

    void Start ()
    {
        normal.image.enabled = false;
        personalizada.image.enabled = false;
        atras.image.enabled = false;
        crear.image.enabled = false;
	}
    
    public void buttonPress (string action)
    {
        switch (action)
        {
            case "JUGAR":
                normal.image.enabled = true;
                personalizada.image.enabled = true;
                atras.image.enabled = true;
                crear.image.enabled = true;
                jugar.image.enabled = false;
                instrucciones.image.enabled = false;
                cerrar.image.enabled = false;
                break;
            case "ATRAS":
                normal.image.enabled = false;
                personalizada.image.enabled = false;
                atras.image.enabled = false;
                crear.image.enabled = false;
                jugar.image.enabled = true;
                instrucciones.image.enabled = true;
                cerrar.image.enabled = true;
                break;
            case "CERRAR":
                Application.Quit();
                break;
            case "INSTRUCCIONES":
                StartCoroutine(LoadAsync("Instrucciones"));
                break;
            case "NORMAL":
                StartCoroutine(LoadAsync("Ruleta"));
                break;
            case "PERSONALIZADA":
                StartCoroutine(LoadAsync("RuletaPremium"));
                break;
            case "CREADOR":
                StartCoroutine(LoadAsync("Creador"));
                break;
        }
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

}
