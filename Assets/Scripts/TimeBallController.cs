using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class TimeBallController : MonoBehaviour
{
    [SerializeField] private Sprite enabled;
    [SerializeField] private Sprite disabled;

    [SerializeField] private Image _image;

    public bool IsEnabled => _image.sprite.Equals(enabled);

    private void Reset()
    {
        _image = GetComponent<Image>();
    }

    public void Enable()
    {
        _image.sprite = enabled;
    }

    public void Disable()
    {
        _image.sprite = disabled;
    }
}
