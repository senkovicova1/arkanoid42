using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    public int side;
    public int id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (side == 1)
        {
            if (GM.instance.lives1x == id - 1)
            {
                Destroy(gameObject);
            }
        }
	}
}
