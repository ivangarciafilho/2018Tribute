using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickLocalScale : MonoBehaviour
{
    public Vector2 interval;
    public Vector2 scaleDeviation;
    public float stabilityChance;
    public Vector2 stabilityTimeInterval;


    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(Flick());
    }

    private Vector3 newScale;
    private IEnumerator Flick()
    {
        while (true)
        {
            var delay = Random.Range(interval.x, interval.y);
            if (Random.Range(0f, 100f) < stabilityChance)
            {
                delay += Random.Range(stabilityTimeInterval.x, stabilityTimeInterval.y);
                newScale.x = 1;
                newScale.y = 1;
                newScale.z = 1;
            }
            else
            {
                newScale.x = Random.Range(1 * scaleDeviation.x, 1 * scaleDeviation.y);
                newScale.y = Random.Range(1 * scaleDeviation.x, 1 * scaleDeviation.y);
                newScale.z = Random.Range(1 * scaleDeviation.x, 1 * scaleDeviation.y);
            }

            transform.localScale = newScale;
            yield return new WaitForSeconds(delay);
        }
    }
}
