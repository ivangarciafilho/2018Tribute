using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedActivation : MonoBehaviour
{
    public float delay;
    public GameObject target;

    public void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(ActivateAfteerDelay());
    }

    private IEnumerator ActivateAfteerDelay()
    {
        yield return new WaitForSeconds(delay);
        target.SetActive(true);
    }
}
