using UnityEngine;
using System.Collections;

public class rayEmiter : MonoBehaviour {
    private RaycastHit2D[] hit;
    private PlayerController thePlayer;
    public LayerMask whatToHit;
    Transform firePoint;
    Vector2 firePointPos;
    bool[] moveCondition;
    private static bool playerExistFlag;

    // Use this for initialization
    void Awake () {
        thePlayer = FindObjectOfType<PlayerController>();
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No fire point found!, crashes are inevitable!");
        }
        hit = new RaycastHit2D[4];
        moveCondition = new bool[4];

        if (!playerExistFlag)
        {
            playerExistFlag = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        shoot();
	}

    void shoot()
    {
        firePointPos = new Vector2(firePoint.position.x,
            firePoint.position.y);

        hit[0] = Physics2D.Raycast(firePointPos,
            new Vector2(-1 + thePlayer.getPos().x, 0 + thePlayer.getPos().y) - firePointPos,
            1, whatToHit);
        hit[1] = Physics2D.Raycast(firePointPos,
            new Vector2(1 + thePlayer.getPos().x, 0 + thePlayer.getPos().y) - firePointPos,
            1, whatToHit);
        hit[2] = Physics2D.Raycast(firePointPos,
            new Vector2(0 + thePlayer.getPos().x, 1 + thePlayer.getPos().y) - firePointPos,
            1, whatToHit);
        hit[3] = Physics2D.Raycast(firePointPos,
            new Vector2(0 + thePlayer.getPos().x, -1 + thePlayer.getPos().y) - firePointPos,
            1, whatToHit);

     
        //Debug.DrawLine(firePointPos, new Vector2(-1 + thePlayer.getPos().x, 0 + thePlayer.getPos().y), Color.cyan);     //0 pointing left
        if (hit[0].collider != null)
        {
            moveCondition[0] = false;
            //Debug.DrawLine(firePointPos, new Vector2(-1 + thePlayer.getPos().x, 0 + thePlayer.getPos().y), Color.red);
        }
        else
        {
            moveCondition[0] = true;
        }
       // Debug.DrawLine(firePointPos, new Vector2(1 + thePlayer.getPos().x, 0 + thePlayer.getPos().y), Color.cyan);      //1 pointing right
        if (hit[1].collider != null)
        {
            moveCondition[1] = false;
           // Debug.DrawLine(firePointPos, new Vector2(1 + thePlayer.getPos().x, 0 + thePlayer.getPos().y), Color.red);
        }
        else
        {
            moveCondition[1] = true;
        }
        //Debug.DrawLine(firePointPos, new Vector2(0 + thePlayer.getPos().x, 1 + thePlayer.getPos().y), Color.cyan);      //2 pointing up
        if (hit[2].collider != null)
        {
            moveCondition[2] = false;
            //Debug.DrawLine(firePointPos, new Vector2(0 + thePlayer.getPos().x, 1 + thePlayer.getPos().y), Color.red);
        }
        else
        {
            moveCondition[2] = true;
        }
       // Debug.DrawLine(firePointPos, new Vector2(0 + thePlayer.getPos().x, -1 + thePlayer.getPos().y), Color.cyan);     //3 pointing down
        if (hit[3].collider != null)
        {
            moveCondition[3] = false;
            //Debug.DrawLine(firePointPos, new Vector2(0 + thePlayer.getPos().x, -1 + thePlayer.getPos().y), Color.red);
        }
        else
        {
            moveCondition[3] = true;
        }
    }
    public bool[] getmoveConditions()
    {
        return moveCondition;
    }
}
