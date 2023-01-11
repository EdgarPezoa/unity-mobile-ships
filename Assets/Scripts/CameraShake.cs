using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float maxAngle = 0.25f;
    [SerializeField] float maxOffset = 0.25f;
    [SerializeField] float addTrauma = 0.33f;
    float trauma = 0f;
    Vector3 initialPosition;
    Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    //CUSTOM METHODS
    public void Play()
    {
        trauma = AddTrauma();
        StopCoroutine(Shake());
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float angle = 0f;
        float offsetX = 0f;
        float offsetY = 0f;

        while (trauma > 0)
        {
            float shake = Mathf.Pow(trauma, 2);
            angle = maxAngle * shake * GetRandomFloatNegOneToOne();
            offsetX = maxOffset * shake * GetRandomFloatNegOneToOne();
            offsetY = maxOffset * shake * GetRandomFloatNegOneToOne();

            transform.position = initialPosition + GetVector3Offset(offsetX, offsetY);
            transform.rotation = Quaternion.Euler(0, 0, initialRotation.z + angle);

            trauma -= 0.01f;
            yield return new WaitForSeconds(0.05f);
        }

        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    float GetRandomFloatNegOneToOne()
    {
        return Random.Range(-1f, 1f);
    }

    Vector3 GetVector3Offset(float offsetX, float offsetY)
    {
        Vector3 cameraPos;
        cameraPos.x = offsetX;
        cameraPos.y = offsetY;
        cameraPos.z = 0f;
        return cameraPos;
    }

    float AddTrauma()
    {
        float newTrauma = trauma + addTrauma;
        if (newTrauma > 1)
        {
            newTrauma = 1;
        }
        return newTrauma;
    }
}
