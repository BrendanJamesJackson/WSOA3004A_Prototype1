using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Script : MonoBehaviour
{
    public GameObject[] placeholders;

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
            complete_notification.SetActive(true);
        }

        if (complete && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
