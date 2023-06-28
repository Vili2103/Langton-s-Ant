using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StepsCounter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text stepsText;
   
    private void FixedUpdate()
    {
        stepsText.text = $"Steps: {Movement.steps}";
    }

}
