
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RaandomlyActivateOne : MonoBehaviour
{
    [Serializable]
    public struct Alternative
    {
        public float chance;
        public Vector2 timeInterval;
        public GameObject target;
        public float rolledChance;
    }

    public Alternative[] alternatives;

    private void OnEnable() { ChooseAlternative(); }

    private void ChooseAlternative()
    {
        StopAllCoroutines();

        for (int i = 0; i < alternatives.Length; i++)
        {
            alternatives[i].target.SetActive(false);
            alternatives[i].rolledChance = Random.Range(0f, alternatives[i].chance);
        }

        alternatives = alternatives.OrderByDescending(x => x.rolledChance).ToArray();
        alternatives[0].target.SetActive(true);

        StartCoroutine(HandleAlternativeLifeSpam());
    }

    private IEnumerator HandleAlternativeLifeSpam()
    {
        var delay = Random.Range(alternatives[0].timeInterval.x, alternatives[0].timeInterval.y);
        yield return new WaitForSeconds(delay);
        ChooseAlternative();
    }
}
