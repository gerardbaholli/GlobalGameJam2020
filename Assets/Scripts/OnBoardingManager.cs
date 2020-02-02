using System;
using System.Security;
using UnityEngine;

public class OnBoardingManager : MonoBehaviour
{
    [SerializeField]private GameObject bug;

    private void Update()
    {
        if (bug == null)
        {
            LevelManager.LoadMenu();
        }
    }
}
