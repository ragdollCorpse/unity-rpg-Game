using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour {

    private static bool controlExistFlag;
	// Use this for initialization
	void Start () {
        if (!controlExistFlag)
        {
            controlExistFlag = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
