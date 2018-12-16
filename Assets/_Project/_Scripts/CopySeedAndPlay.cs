using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopySeedAndPlay : MonoBehaviour
{
    private ParticleSystem itsParticleSystem;
    public ParticleSystem target;

    private void FixedUpdate()
    {
        itsParticleSystem.useAutoRandomSeed = false;
        itsParticleSystem.randomSeed = target.randomSeed;
    }
}
