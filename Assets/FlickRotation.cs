using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickRotation : MonoBehaviour
{
    public Vector2 interval;
    public Vector2 rotationDeviation;
    public float stabilityChance;
    public Vector2 stabilityTimeInterval;
    private Quaternion defaultRotation;


    private void OnEnable()
    {
        defaultRotation = transform.rotation;
        StopAllCoroutines();
        StartCoroutine(Flick());
    }

    private void OnDisable()
    {
        transform.rotation = defaultRotation;
    }

    private IEnumerator Flick()
    {
        while (true)
        {
            var delay = Random.Range(interval.x, interval.y);
            if (Random.Range(0f, 100f) < stabilityChance)
            {
                delay += Random.Range(stabilityTimeInterval.x, stabilityTimeInterval.y);
                transform.rotation = defaultRotation;
            }
            else
            {
                transform.Rotate(0f,0f,Random.Range(rotationDeviation.x,rotationDeviation.y));
            }

            yield return new WaitForSeconds(delay);
        }
    }
}
