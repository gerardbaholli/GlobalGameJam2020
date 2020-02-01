using UnityEngine;

public class BugMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField, Range(0f, 3f), Tooltip("How big is the step each frame?")] private float speed = .1f;
    [SerializeField, Range(0f, 5f), Tooltip("How long does it take to change rotation?")] private float straightLine = 3f;
    
    private float _lastRotationUpdate;
    private float rotation;
    

    private void Reset()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad - _lastRotationUpdate > straightLine)
        {
            rotation = Random.Range(0f, 360f);
            _rigidbody2D.SetRotation(rotation);
            _lastRotationUpdate = Time.timeSinceLevelLoad;
        }

        Vector2 newPosition = _rigidbody2D.position + (Vector2) transform.up * speed;
        _rigidbody2D.MovePosition(newPosition);
    }
}