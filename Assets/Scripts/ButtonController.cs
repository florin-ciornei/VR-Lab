using System;
using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private bool isPressed;
    public ParticleSystem fire;
    private ParticleSystem.MainModule mainModule;
    public Color color;
    private Renderer buttonRenderer;
    void Start()    
    {
        fire.Play();
        mainModule = fire.main;
        buttonRenderer = GetComponent<Renderer>();
    }

    private IEnumerator OnButtonPressed()
    {
        isPressed = true;
        //set button color
        buttonRenderer.material.SetColor("_Color", Color.green);
        //set fire color
        mainModule.startColor = new Color(color.r, color.g, color.b);
        
        yield return new WaitForSeconds(3);
        buttonRenderer.material.SetColor("_Color", Color.red);
        isPressed = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (!isPressed)
            {
                StartCoroutine(OnButtonPressed());
            }
        }
    }
}
