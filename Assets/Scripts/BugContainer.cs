using UnityEngine;
using UnityEngine.Events;

public class BugContainer : MonoBehaviour
{
    
    [SerializeField] private GameObject bugPrefab;
    public UnityEvent OnBugsKilled = new UnityEvent();

    private bool _gameOver;

    private void Update()
    {
        if (_gameOver)
            return;
        if (transform.childCount <= 0)
        {
            OnBugsKilled?.Invoke();
            _gameOver = true;
            UIPopup.Instance.Show("You win! You are the new Steve Jobs!", index =>
            {
                if (index == 0)
                {
                    LevelManager.LoadMenu();
                }
                else
                {
                    LevelManager.LoadLevel(2);
                }
            }, "Main Menù", "Next");
        }
    }

    public void InstantiateBug(Vector3 position)
    {
        Instantiate(bugPrefab, position, Quaternion.identity, transform);
    }
}
