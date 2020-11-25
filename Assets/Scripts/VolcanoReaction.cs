using System.Collections;
using UnityEngine;

public class VolcanoReaction : MonoBehaviour
{
    [SerializeField]
    private float lengthOfReaction = 10f;
    
    private bool _bakingSodaApplied;
    private bool _vinegarApplied;
    private ParticleSystem _particleSystem;
    
    private void Awake()
    {
        _bakingSodaApplied = false;
        _vinegarApplied = false;
    }

    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (_bakingSodaApplied && _vinegarApplied)
        {
            _particleSystem.Play();
            StartCoroutine(DisableParticleSystemAfter(lengthOfReaction));
            _bakingSodaApplied = false;
            _vinegarApplied = false;
        }
    }
    
    private IEnumerator DisableParticleSystemAfter(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        _particleSystem.Stop();
    }

    public void ApplyBakingSoda()
    {
        _bakingSodaApplied = true;
    }

    public void ApplyVinegar()
    {
        _vinegarApplied = true;
    }
}
