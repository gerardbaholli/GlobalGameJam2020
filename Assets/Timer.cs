using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalTime;
    [SerializeField] private int numberOfBalls;
    [SerializeField] private GameObject timeBallPrefab;

    private void OnValidate()
    {
        if (timeBallPrefab == null)
            return;

        foreach (Transform child in transform)
        {
            UnityEditor.EditorApplication.delayCall += () =>
            {
                if (child.gameObject != null)
                    DestroyImmediate(child.gameObject);
            };
        }

        for (int i = 0; i < numberOfBalls; i++)
        {
            Instantiate(timeBallPrefab, transform);
        }
    }
}