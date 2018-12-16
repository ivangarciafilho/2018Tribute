using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayeedUnpause : MonoBehaviour
{
    public float delay = 8.5f;
    private ParticleSystem itsParticleSystem;

    private void OnEnable()
    {
        itsParticleSystem = GetComponent<ParticleSystem>();
        StopAllCoroutines();
        StartCoroutine(UnpauseAfterDelay());
    }

    private IEnumerator UnpauseAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            itsParticleSystem.Play();
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
    }
}
