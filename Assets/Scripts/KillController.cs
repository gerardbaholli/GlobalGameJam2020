using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class KillController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [Header("Audio"),SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip kill;
    [SerializeField] private AudioClip miss;

    private Vector2 _boxSize;

    private void Reset()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        _boxSize = new Vector2(1f, 2f) * gameObject.transform.localScale;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D hit = Physics2D.BoxCast(_rigidbody2D.position, _boxSize, 0, Vector2.zero, 0f,
                1 << LayerMask.NameToLayer("Bug"));
            if (hit.collider != null)
            {
                Destroy(hit.transform.gameObject);
                _audioSource.PlayOneShot(kill);
            }
            else
            {
                _audioSource.PlayOneShot(miss);
            }
        }
    }
}