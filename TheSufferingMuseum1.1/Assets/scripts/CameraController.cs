using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPos;
    public float moveSpeed;
    private static bool cameraExistFlag;
    //float tlx, tly, brx, bry;
    //public BoxCollider2D boundBox;
    //private Vector3 minBounds;
    //private Vector3 maxBounds;
    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;
    // Use this for initialization
    void Awake()
    {
        if (!cameraExistFlag)
        {
            cameraExistFlag = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        /*minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;*/

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
       /* float clampX;
        float clampY;*/

        targetPos = new Vector3(target.transform.position.x,
            target.transform.position.y,
            transform.position.z);
        
        transform.position = Vector3.Lerp(transform.position,
            targetPos, moveSpeed * Time.deltaTime);

        /*if (boundBox == null)
        {
            boundBox = FindObjectOfType<boundCode>().GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
        }

        clampX = Mathf.Clamp(transform.position.x,
            minBounds.x + halfWidth,
            maxBounds.x - halfWidth);

        clampY = Mathf.Clamp(transform.position.y,
            minBounds.y + halfHeight,
            maxBounds.y - halfHeight);*/

        //transform.position = new Vector3(clampX, clampY, transform.position.z);
    }

    /*public void setBound(BoxCollider2D bounds)
    {
        boundBox = bounds;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }*/
}