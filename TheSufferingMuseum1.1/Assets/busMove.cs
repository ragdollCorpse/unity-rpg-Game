using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busMove : MonoBehaviour {
    Vector3 dir;
	// Use this for initialization
	void Start () {
        dir = new Vector3(-5, 0, 0);

        Destroy(GameObject.FindGameObjectWithTag("DESTRUCTIBLE"), 5);
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime;
    }
}
