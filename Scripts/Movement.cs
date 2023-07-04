using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Movement : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1f)]
    private float speed = 1f;
    private bool canMove = true, warp = true;
    private Vector3 targetPos = new Vector3(5,5,-5f);
    public static int steps = -1;
    [SerializeField]
    private GridGenerator gridGen;
    

    public void changeSpeed(float speed)
    {
        this.speed = speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        getDir(collision.gameObject);
       
    }
    public void beginMoving()
    {
        canMove = true;
        targetPos = transform.position;
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
        Vector3 pos = transform.position + rotatedDir;
        targetPos = new Vector3((float)System.Math.Round(pos.x, System.MidpointRounding.AwayFromZero), 
            (float)System.Math.Round(pos.y, System.MidpointRounding.AwayFromZero), -5f);
        //Debug.Log($" {targetPos.x}  {targetPos.y}, 0");
        if (!GridGenerator.tilePositions.Contains(new Vector3(targetPos.x, targetPos.y, 0)) && warp == false)
             canMove = false;
           
        else steps++;
    }

    private void Update()
    {       
        if (canMove) {
            float dist = Vector3.Distance(transform.position, targetPos);
            if (dist == 0) // To prevent early turning.
                transform.position = targetPos;
            else
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
        }      
    

    }
}
