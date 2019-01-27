using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPaddle : MonoBehaviour {
    

    // Update is called once per frame
    void Update()
    {
    }

    public void changeSize(float times)
    {
        transform.localScale = new Vector3(transform.localScale.x * times, transform.localScale.y, transform.localScale.z);
    }
}
