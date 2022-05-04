using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPysics : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        rb.velocity = (transform.parent.position - transform.position) / Time.fixedDeltaTime;
    }
}
