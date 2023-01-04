using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ButtonTypes Type;

    void Highlight(bool isSelected)
    {
        if (isSelected == true)
        {
           Debug.Log("light"); 
        }
        else
        {
            Debug.Log("UnLight");
        }
    }

    private void OnMouseDown()
    {
        Highlight(true);
    }
}
