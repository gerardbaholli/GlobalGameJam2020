﻿using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float totalTime;
    [SerializeField] private int numberOfBalls;
    [SerializeField] private GameObject timeBallPrefab;

    private TimeBallController[] _ballControllers;
    private float _elapsedTime;
    private float _timePerBall;
    private bool _gameOver;

    private void OnValidate()
    {
        if (timeBallPrefab == null || transform.childCount == numberOfBalls)
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

    private void Start()
    {
        _ballControllers = GetComponentsInChildren<TimeBallController>();
        _timePerBall = totalTime / numberOfBalls;
    }

    private void Update()
    {
        if(_gameOver)
            return;

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _timePerBall)
        {
            var index = (int) (_elapsedTime / _timePerBall) - 1;
            _ballControllers[index].Disable();
        }
        
        if (totalTime <= _elapsedTime)
        {
            _gameOver = true;
            // GameEnd
        } 
    }
}