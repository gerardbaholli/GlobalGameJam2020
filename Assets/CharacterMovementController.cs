using System;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private void Reset()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
