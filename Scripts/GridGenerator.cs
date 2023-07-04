using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject tile, organizer, ant;
    [Range(1,250)]
    public int size;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private TMP_InputField inputField;

    public static HashSet<Vector3> tilePositions = new HashSet<Vector3>();

    public void GenerateGrid()
    {
        ClearAll(); 
        changeSize();
        for (int x = 0; x < size; x++)
        {
            for(int y = 0; y<size; y++)
            {
                var pos = new Vector3(x, y, 0);
                Instantiate(tile, pos, transform.rotation, organizer.transform);
                tilePositions.Add(pos);
                // I use the organizer gameobject so that I can clean up the Editor
            }
        }
        CenterAnt();
        SetCamSize();
        Movement.steps = 0;
    }
    public void ClearAll()
    {
        tilePositions.Clear();
        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
        {
            DestroyImmediate(tile);
        }
    }
    public void CenterAnt()
    {
        ant.transform.position = new Vector3(size/2,size/2, -5f);
    }
    public void SetCamSize()
    {
        float pos = (float)(size / 2.0);
        Vector3 pos3 = new Vector3(pos, pos, -10f);
        cam.transform.position = pos3;
        cam.orthographicSize = (float)(size / 2.0 + 1.0);
        
    }
    public void changeSize()
    {
        size = int.Parse(inputField.text);
    }

}
