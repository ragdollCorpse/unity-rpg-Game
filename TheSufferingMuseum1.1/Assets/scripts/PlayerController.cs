using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    private Vector2 lastMove;        //try setting the spawn position
                                     //using the same mov;
    private static bool playerExistFlag;
    private Light lantern;

    // for touch input
    private int horizontal;
    private int vertical;

    public string spawnName;

    Vector2 mov;

    void Start () {
        if (!playerExistFlag)
        {
            playerExistFlag = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        lantern = transform.Find("Lantern").GetComponent<Light>();
        horizontal = 0;
        vertical = 0;
}
	
	void Update () {

        /*mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")).normalized;*/
        
        /*if (horizontal == 0)
        {
            horizontal = (int)Input.GetAxisRaw("Horizontal");
        }
        if (horizontal == 0)
        {
            vertical = (int)Input.GetAxisRaw("Vertical");
        }*/
        mov = new Vector2(
            horizontal,
            vertical).normalized;

        if (mov != Vector2.zero)
        {
            anim.SetFloat("moveX", mov.x);
            anim.SetFloat("moveY", mov.y);

            //setLastMove(mov);

            anim.SetBool("PlayerMoving", true);
        }
        else
        {
            /*anim.SetFloat("moveX", lastMove.x);
            anim.SetFloat("moveY", lastMove.y);*/
            anim.SetBool("PlayerMoving", false);
        }
    }
    void FixedUpdate()
    {
        myRigidbody.MovePosition((myRigidbody.position 
            + mov * moveSpeed * Time.deltaTime));

        if (Input.GetButtonDown("Fire2"))
        {
            changeLightState();
        }
    }
    public void changeLightState()
    {
        if (lantern.enabled) {
            lantern.enabled = false;
        }
        else
        {
            lantern.enabled = true;
        }
    }

    //for touch input
    public void changeHorizontalToNegative()
    {
        horizontal = -1;
    }
    public void changeHorizontalToPositive()
    {
        horizontal = 1;
    }
    public void changeVerticalToNegative()
    {
        vertical = -1;
    }
    public void changeVerticalToPositive()
    {
        vertical = 1;
    }
    public void changeHorizontalToZero()
    {
        horizontal = 0;
    }
    public void changeVerticalToZero()
    {
        vertical = 0;
    }

    //get set
    public Vector2 getPos()
    {
        return transform.position;
    }
    public Vector2 getLastMoveWithPlayerPos()
    {
        return new Vector2(lastMove.x + transform.position.x,
            lastMove.y + transform.position.y);
    }
    public Vector2 getLastMove()
    {
        return lastMove;
    }
    public void setLastMove(Vector2 dir)
    {
        lastMove = dir;
    }
    public Vector2 getMov()
    {
        return mov;
    }
    public void setMov(Vector2 dir)
    {
        mov = dir;
    }
}
