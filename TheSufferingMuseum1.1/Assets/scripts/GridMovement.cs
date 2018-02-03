using UnityEngine;
using System.Collections;

//public enum DIRECTION {UP, DOWN, LEFT, RIGHT}


public class GridMovement : MonoBehaviour
{
    private bool canMove = true, moving = false;
    public int speed;
    //private int buttonCoolDown = 0;
    //int cooldown = 0;
    //private DIRECTION dir = DIRECTION.DOWN;
    private Vector3 pos;
    private static bool playerExistFlag;
    //private Rigidbody2D myRigidbody;
    private bool[] moveConditions;
    public string spawnName;
    //private Animator anim;
    //private bool playerMoving;
    //private Vector2 lastMove;

    // Use this for initialization
    void Start()
    {
        moving = false;
        canMove = true;
        /*if (!playerExistFlag)
        {
            playerExistFlag = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
        moveConditions = GetComponent<rayEmiter>().getmoveConditions();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            pos = transform.position;
            move();
        }

        if (moving)
        {
            if (transform.position == pos)
            {
                moving = false;
                canMove = true;

                move();
            }
            transform.position = Vector2.MoveTowards(transform.position,
                pos, Time.deltaTime * speed);
        }
        /*Debug.LogError("moving: " + moving);
        Debug.LogError("canMove: " + canMove);*/
    }
    private void move()
    {
        if (Input.GetAxisRaw("Horizontal") < -0.5)
        {
            canMove = false;
            moving = true;
            if (moveConditions[0])
                pos += Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0.5)
        {
            canMove = false;
            moving = true;
            if (moveConditions[1])
                pos += Vector3.right;
        }
        else if (Input.GetAxisRaw("Vertical") > 0.5)
        {
            canMove = false;
            moving = true;
            if (moveConditions[2])
                pos += Vector3.up;
        }
        else if (Input.GetAxisRaw("Vertical") < -0.5)
        {
            canMove = false;
            moving = true;
            if (moveConditions[3])
                pos += Vector3.down;
        }
    }
    public bool getMoving()
    {
        return moving;
    }
    public void setMoving(bool flag)
    {
        moving = flag;
    }
    public bool getCanMove()
    {
        return canMove;
    }
    public void setCanMove(bool flag)
    {
        canMove = flag;
    }
}
