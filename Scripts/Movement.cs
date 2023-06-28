using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    private bool move = true;
    private Vector3 targetPos;
    public static int steps = 0;
    [SerializeField]
    private GridGenerator gridGen;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        getDir(collision.gameObject);
       
    }

    private void Start()
    {
        Move(Vector2.up);
    }

    public void getDir(GameObject tile)
    {
        if (tile.gameObject.GetComponent<TileBehaviour>().color == "white")
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 90);
          //  Debug.Log("yessir"); 
        }
        else if (tile.gameObject.GetComponent<TileBehaviour>().color == "black")
            gameObject.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);

        tile.GetComponent<TileBehaviour>().SteppedOn();

        if (transform.forward.z == 90 || transform.forward.z == - 270)
            Move(Vector2.left);
        else if (transform.forward.z == 180 || transform.forward.z == -180)
            Move(Vector2.down);
        else if (transform.forward.z == 270 || transform.forward.z == -90)
            Move(Vector2.right);
        else
            Move(Vector2.up);
    }

    public void Move(Vector2 dir)
    {
        Vector3 rotatedDir = Quaternion.Euler(0, 0, transform.eulerAngles.z) * dir;
        targetPos = transform.position + rotatedDir;
        targetPos.z = -5f;
        if (targetPos.x < 0 || targetPos.y < 0 || targetPos.x >= gridGen.size || targetPos.y >= gridGen.size)
            move = false;
        else steps++;
    }


    private void Update()
    {
        if (move) {
            float dist = Vector3.Distance(transform.position, targetPos);
            if (dist == 0) // To prevent early turning.
                transform.position = targetPos;
            else
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
        }   
    

    }
}
