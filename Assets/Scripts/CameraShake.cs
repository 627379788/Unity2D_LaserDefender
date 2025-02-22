using System;
using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;
    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play() {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while(shakeDuration > elapsedTime) {
            elapsedTime += Time.deltaTime;
            transform.position = initialPosition + (Vector3)UnityEngine.Random.insideUnitCircle * shakeMagnitude;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
} 
