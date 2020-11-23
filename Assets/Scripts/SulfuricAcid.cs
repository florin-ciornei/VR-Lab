using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SulfuricAcid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sugar"))
        {
            other.gameObject.GetComponent<Sugar>().ApplySulfuricAcid();
            Destroy(gameObject);
        }
    }
}
