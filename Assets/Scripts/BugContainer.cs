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
            UIPopup.Instance.Show("You win! You are the new Steve Jobs!", index =>
            {
                if (index == 0)
                {
                    LevelManager.Instance.LoadMenu();
                }
                else
                {
                    LevelManager.Instance.LoadLevel(2);
                }
            }, "Main Menù", "Next");
        }
    }

    public void InstantiateBug(Vector3 position)
    {
        Instantiate(bugPrefab, position, Quaternion.identity, transform);
    }
}
