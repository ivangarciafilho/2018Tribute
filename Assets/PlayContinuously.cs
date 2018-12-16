using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayContinuously : MonoBehaviour
{
    private ParticleSystem itsParticleSystem;


    private void OnEnable()
    {
        itsParticleSystem = GetComponent<ParticleSystem>();
        StopAllCoroutines();
        StartCoroutine(PlayAfterDelay());
    }

    private IEnumerator PlayAfterDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            itsParticleSystem.gameObject.SetActive(false);
            itsParticleSystem.gameObject.SetActive(true);
        }
    }
}
