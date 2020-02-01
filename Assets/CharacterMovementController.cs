using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField, Range(0f, 3f)] private float speed = 1f;

    private LayerMask _layerMask;
    private Vector2 _boxSize;

    private void Reset()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        _layerMask = Physics2D.GetLayerCollisionMask(gameObject.layer);
        _boxSize = new Vector2(1f, 2f) * gameObject.transform.localScale;
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 newPosition = _rigidbody2D.position + input * speed;
        if (Physics2D.BoxCast(newPosition, _boxSize, 0f, Vector2.zero, 0f, _layerMask).collider == null)
        {
            _rigidbody2D.MovePosition(newPosition);
        }
    }
}