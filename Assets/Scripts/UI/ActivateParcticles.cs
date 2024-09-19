using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParcticles : MonoBehaviour
{
    private ParticleSystem _particle;

    private void Start()
    {
        _particle = GetComponent<ParticleSystem>();
        CommonEvents.Instance.OnPartclesStarted += StartParticle;
    }

    private void OnDisable()
    {
        CommonEvents.Instance.OnPartclesStarted -= StartParticle;
    }

    private void StartParticle()
    {
        _particle.Play();
    }
}
