using UnityEngine;
using UnityEngine.Events;

public class BugContainer : MonoBehaviour
{
    
    [SerializeField] private GameObject bugPrefab;
    public UnityEvent OnBugsKilled = new UnityEvent();

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            OnBugsKilled?.Invoke();
        }
    }

    public void InstantiateBug(Vector3 position)
    {
        Instantiate(bugPrefab, position, Quaternion.identity, transform);
    }
}
