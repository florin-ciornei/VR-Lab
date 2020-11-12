using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Natrium : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}