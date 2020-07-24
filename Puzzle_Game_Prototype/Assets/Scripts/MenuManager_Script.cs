using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager_Script : MonoBehaviour
{
    public void Menu_Action(int x)
    {
        StartCoroutine(SceneChange(x));
    }

    IEnumerator SceneChange(int x)
    {
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(.5f);
        if (x == -1)
        {
            Application.Quit();
        }

        else if (x == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

}
