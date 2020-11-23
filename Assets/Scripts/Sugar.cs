using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sugar : MonoBehaviour
{
    public GameObject wrapper;
    public Material dehydratedMaterial;
    public int maxHeight = 20;
    public float reactionSpeed = 3;

    private Renderer rend;

    void Start() 
    {
        rend = GetComponent<Renderer>();
    }

    IEnumerator StartReaction()
    {
        yield return new WaitForSeconds(reactionSpeed);
        rend.material = dehydratedMaterial;

        while (wrapper.transform.localScale.y < maxHeight)
        {
            wrapper.transform.localScale = new Vector3(wrapper.transform.localScale.x, wrapper.transform.localScale.y + 0.1f, wrapper.transform.localScale.z);
            reactionSpeed -= 0.1f;
            yield return new WaitForSeconds(reactionSpeed);
        }
    }

    public void ApplySulfuricAcid()
    {
        StartCoroutine(StartReaction());
    }
}
