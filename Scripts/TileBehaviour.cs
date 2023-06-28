using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public  string color = "white";
   

    SpriteRenderer spriteRenderer;
    private void Start()
    {
         spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void SteppedOn()
    {
        if (color == "white")
        {
            color = "black";
            spriteRenderer.color = Color.gray;
        }
          
        else if (color == "black")
        {
            color = "white";
            spriteRenderer.color = Color.white;

        }
            

    }
}
