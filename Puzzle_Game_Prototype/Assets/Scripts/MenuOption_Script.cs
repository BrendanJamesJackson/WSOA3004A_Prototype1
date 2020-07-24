using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOption_Script : MonoBehaviour
{
    public int Scene_to_load;

    public Transform start_position;
    private Transform target_position;


    private bool is_dragging;
    private bool locked = false;

    private void OnMouseDown()
    {
        is_dragging = true;
        locked = false;
        GetComponent<AudioSource>().Play();
    }

    private void OnMouseUp()
    {
        is_dragging = false;
        if (!locked)
        {
            transform.position = start_position.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (is_dragging && !locked)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<MenuManager_Script>().Menu_Action(Scene_to_load);
        target_position = collision.transform;
        transform.position = target_position.position;

        locked = true;
    }
}
