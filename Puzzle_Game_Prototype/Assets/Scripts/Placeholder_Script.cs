using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder_Script : MonoBehaviour
{
    public int placeholder_ID;

    private bool correct_piece = false;

    public bool is_empty = true;

    private int occupying_piece = -1;

    public int Get_Occupying()
    {
        return occupying_piece;
    }

    public void Set_Occupying(int x)
    {
        occupying_piece = x;
    }

    public bool Get_empty()
    {
        return is_empty;
    }

    public void Set_empty(bool set)
    {
        is_empty = set;
    }

    public int Get_ID()
    {
        return placeholder_ID;
    }

    public void Set_ID(int x)
    {
        placeholder_ID = x;
    }

    public void Set_Correct( bool x)
    {
        correct_piece = x;
    }

    public bool Get_Correct()
    {
        return correct_piece;
    }
}
