using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalMove : MonoBehaviour
{
    Rigidbody2D rb;
    double maxL;
    double maxR;
    int dir;//right=1, left=0
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        maxL = rb.position.x-1;
        maxR = rb.position.x+1;
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.x >= maxR){
            dir = 0;
        }else if(rb.position.x <= maxL){
            dir = 1;
        }

        if(dir == 1){
            rb.velocity = new Vector3 (0.3f, 0, 0);
        }
        if(dir == 0){
            rb.velocity = new Vector3 (-0.3f, 0, 0);
        }
    }
}
