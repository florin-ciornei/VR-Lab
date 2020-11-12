using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Natrium : MonoBehaviour
{
    public float maxMoveSpeed = 10;
    public float force = 10;
    public float sizeDecreaseSpeed = 5;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private bool onWater = false;

    IEnumerator OnWater()
    {
        while (transform.localScale.magnitude > 0.15f)
        {
            if (rb.velocity.magnitude < maxMoveSpeed)
            {
                var forward = transform.forward;
                forward.y = 0;
                forward.Normalize();
                rb.AddForce(forward * force);
            }

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, sizeDecreaseSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            if (!onWater)
                StartCoroutine(OnWater());
            onWater = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Flask"))
        {
            transform.Rotate(0, Random.Range(0, 360), 0, Space.World);
        }
    }
}