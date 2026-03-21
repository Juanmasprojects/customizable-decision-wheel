using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instruccions : MonoBehaviour {

    public Button next;
    public Text desc;
    public Image pic;

    public string text1;
    public string text2;
    public string text3;
    public string text4;
    public string text5;
    public string text6;
    public string text7;
    public string text8;
    public string text9;
    public string text10;

    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;

    private int page;


	void Start ()
    {
        pic.enabled = false;
        page = 1;
	}
	
	public void buttonClick (string currentPage)
    {
        switch(currentPage)
        {
            case "ADD":
                page++;
                break;
            case "REST":
                page--;
                break;
            case "SALIR":
                StartCoroutine(LoadAsync("Menu"));
                break;
        }
        switch (page)
        {
            case 0:
                StartCoroutine(LoadAsync("Menu"));
                break;
            case 1:
                pic.enabled = false;
                desc.text = text1;
                break;
            case 2:
                pic.sprite = sprite2;
                pic.enabled = true;
                desc.text = text2;
                break;
            case 3:
                pic.sprite = sprite3;
                desc.text = text3;
                break;
            case 4:
                pic.sprite = sprite4;
                desc.text = text4;
                break;
            case 5:
                pic.sprite = sprite5;
                desc.text = text5;
                break;
            case 6:
                pic.sprite = sprite6;
                desc.text = text6;
                break;
            case 7:
                pic.sprite = sprite7;
                desc.text = text7;
                break;
            case 8:
                pic.sprite = sprite8;
                pic.enabled = true;
                desc.text = text8;
                break;
            case 9:
                next.image.enabled = true;
                pic.enabled = false;
                desc.text = text9;
                break;
            case 10:
                next.image.enabled = false;
                desc.text = text10;
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
