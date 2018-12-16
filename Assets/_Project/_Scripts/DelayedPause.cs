using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedPause : MonoBehaviour
{
    public float delay = 8.5f;
    public bool pauseChildren = true;
    private ParticleSystem itsParticleSystem;

    private void OnEnable()
    {
        itsParticleSystem = GetComponent<ParticleSystem>();
        StopAllCoroutines();
        StartCoroutine(PauseAfterDelay());
    }

    private IEnumerator PauseAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        itsParticleSystem.Pause(pauseChildren);
    }
}