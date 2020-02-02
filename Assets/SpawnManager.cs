using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

     [SerializeField] private GameObject bugPrefab;
     
     private void Awake()
     {
          foreach (Transform childTransform in transform)
          {
               Instantiate(bugPrefab, childTransform.position, Quaternion.identity);
          }
     }
}
