using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private BugContainer _container;

    private void Awake()
    {
        foreach (Transform childTransform in transform)
        {
            _container.InstantiateBug(childTransform.position);
        }
    }
}