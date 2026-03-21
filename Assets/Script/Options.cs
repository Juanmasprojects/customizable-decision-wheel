using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour{

    public Image body;
    public Button seguir;
    public Button volver;
    public Button cerrar;

    void Start()
    {
        desactivate();
    }

    public void buttonPress (string action)
    {
        switch(action)
        {
            case "MENU":
                body.enabled = true;
                seguir.image.enabled = true;
                volver.image.enabled = true;
                cerrar.image.enabled = true;
                break;
            case "CERRAR":
                Application.Quit();
                break;
            case "SEGUIR":
                desactivate();
                break;
            case "VOLVER":
                StartCoroutine(LoadAsync("Menu"));
                break;
        }
       
    }

    private void desactivate ()
    {
        body.enabled = false;
        seguir.image.enabled = false;
        volver.image.enabled = false;
        cerrar.image.enabled = false;
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
