using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Script : MonoBehaviour
{
    public int piece_ID;
    public Transform start_position;

    private Transform target_position;
    private Vector2 mousePos;
    private bool isDragging;
    private bool locked = false;

    private void Awake()
    {
        //target_position = start_position;
    }

    public void OnMouseDown()
    {
        isDragging = true;
        locked = false;
        GetComponent<AudioSource>().Play();
    }

    public void OnMouseUp()
    {
        isDragging = false;
        if (!locked)
        {
            transform.position = start_position.position;
        }
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "placeholder")
        {
            if (collision.gameObject.GetComponent<Placeholder_Script>().is_empty)
            {
                collision.gameObject.GetComponent<Placeholder_Script>().Set_empty(false);
                collision.gameObject.GetComponent<Placeholder_Script>().Set_Occupying(piece_ID);
                target_position = collision.transform;
                transform.position = target_position.position;
                
                locked = true;
            }
            if (collision.gameObject.GetComponent<Placeholder_Script>().Get_ID() == piece_ID)
            {
                collision.gameObject.GetComponent<Placeholder_Script>().Set_Correct(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "placeholder")
        {
            if ((!collision.gameObject.GetComponent<Placeholder_Script>().is_empty) && (collision.gameObject.GetComponent<Placeholder_Script>().Get_Occupying() == piece_ID))
            {
                collision.gameObject.GetComponent<Placeholder_Script>().Set_empty(true);
                collision.gameObject.GetComponent<Placeholder_Script>().Set_Occupying(-1);
                collision.gameObject.GetComponent<Placeholder_Script>().Set_Correct(false);
            }
        }
    }

    private void Update()
    {
        if (isDragging && !locked)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
    }


}
