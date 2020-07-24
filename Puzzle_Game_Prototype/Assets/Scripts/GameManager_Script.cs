using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Script : MonoBehaviour
{
    public GameObject[] placeholders;
    public GameObject[] pieces;


    private bool complete = false;

    public GameObject complete_notification;

    // Update is called once per frame
    void Update()
    {
        bool temp = true;
        for (int i =0; i < placeholders.Length; i++)
        {
            if (!placeholders[i].GetComponent<Placeholder_Script>().Get_Correct())
            {
                temp = false;
            }
        }
        if (temp)
        {
            complete = true;
        }

        if (complete)
        {
            //complete_notification.SetActive(true);
            StartCoroutine(level_complete());
        }

        if (complete && Input.GetMouseButtonDown(0) && complete_notification.gameObject.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator level_complete()
    {
        Color nCol = Color.red;
        if (pieces.Length == 4)
        {
            nCol = Color.red;
        }
        else if (pieces.Length == 9)
        {
            nCol = Color.blue;
        }
        else
        {
            nCol = Color.yellow;
        }


        for (int i=0; i<pieces.Length; i++)
        {
            pieces[i].GetComponent<SpriteRenderer>().color = Color.Lerp(pieces[i].GetComponent<SpriteRenderer>().color, nCol, Time.deltaTime);
        }
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4f);
        complete_notification.SetActive(true);
    }
}
