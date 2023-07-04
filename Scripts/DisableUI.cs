using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUI : MonoBehaviour
{
    
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && gameObject.activeInHierarchy)
        gameObject.SetActive(false);

          else if(Input.GetKeyDown(KeyCode.Escape) && gameObject.activeInHierarchy == false)
            gameObject.SetActive(true);

    }
}
