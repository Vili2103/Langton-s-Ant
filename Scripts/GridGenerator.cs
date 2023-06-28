using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject tile, organizer, ant;

    public  int size;
    [SerializeField]
    private Camera cam;

    public void GenerateGrid()
    {
        ClearAll();
        for (int x = 0; x < size; x++)
        {
            for(int y = 0; y<size; y++)
            {
                var pos = new Vector3(x, y, 0);
                Instantiate(tile, pos, transform.rotation, organizer.transform);
                // I use the organizer gameobject so that I can clean up the Editor
            }
        }
        CenterAnt();
        SetCamSize();
    }
    public void ClearAll()
    {
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

}
