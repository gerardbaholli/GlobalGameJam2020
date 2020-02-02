using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField, Range(0f, 3f)] private float speed = 1f;

    private LayerMask _layerMask;
    private Vector2 _boxSize;
    private Camera _camera;
    private bool _movementEnabled = true;

    private void Reset()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        _layerMask = Physics2D.GetLayerCollisionMask(gameObject.layer);
        _boxSize = new Vector2(1f, 2f) * gameObject.transform.localScale;
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!_movementEnabled)
            return;

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 newPosition = _rigidbody2D.position + input * speed;
        if (Physics2D.BoxCast(newPosition, _boxSize, 0f, Vector2.zero, 0f, _layerMask).collider == null)
        {
            var screenPosition = _camera.WorldToViewportPoint(newPosition);
            screenPosition.x = Mathf.Clamp01(screenPosition.x);
            screenPosition.y = Mathf.Clamp01(screenPosition.y);
            newPosition = _camera.ViewportToWorldPoint(screenPosition);
            _rigidbody2D.MovePosition(newPosition);
        }
    }

    public void EnableMovement(bool enabled)
    {
        _movementEnabled = enabled;
    }
}