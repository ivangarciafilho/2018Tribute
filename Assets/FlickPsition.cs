using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickPsition : MonoBehaviour
{
    public Vector2 interval;
    public Vector2 positionDeviationX;
    public Vector2 positionDeviationY;
    public float stabilityChance;
    public Vector2 stabilityTimeInterval;
    private Vector3 defaultPosition;


    private void OnEnable()
    {
        defaultPosition = transform.localPosition;
        StopAllCoroutines();
        StartCoroutine(Flick());
    }

    private void OnDisable()
    {
        transform.localPosition = defaultPosition;
    }

    private Vector3 newPosition;
    private IEnumerator Flick()
    {
        while (true)
        {
            var delay = Random.Range(interval.x, interval.y);
            if (Random.Range(0f, 100f) < stabilityChance)
            {
                delay += Random.Range(stabilityTimeInterval.x, stabilityTimeInterval.y);
                newPosition.x = defaultPosition.x;
                newPosition.y = defaultPosition.y;
                newPosition.z = defaultPosition.z;
            }
            else
            {
                newPosition.x = defaultPosition.x + Random.Range(positionDeviationX.x, positionDeviationX.y);
                newPosition.y = defaultPosition.y + Random.Range(positionDeviationY.x, positionDeviationY.y);
                newPosition.z = defaultPosition.z;
            }

            transform.localPosition = newPosition;
            yield return new WaitForSeconds(delay);
        }
    }
}
