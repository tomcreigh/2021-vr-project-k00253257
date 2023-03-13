using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{

    private Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatable;
    public float speed = 2f;
    public float duration = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            minScale = transform.localScale;
            maxScale = transform.localScale;
            maxScale.y += 0.05f;
            repeatable = true;
            StartCoroutine(Bounce());
        }
    }

    //animate movement
    IEnumerator Bounce()
    {
        while (repeatable)
        {
            //lerp up scale
            yield return RepeatLerp(minScale, maxScale, duration);
            //lerp down scale
            yield return RepeatLerp(maxScale, minScale, duration);
        }
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f/time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}