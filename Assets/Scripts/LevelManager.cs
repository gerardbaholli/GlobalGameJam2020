using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void LoadLevel(int index)
    {
        SceneManager.LoadScene(index.ToString());
    }
    
    public void LoadLevelFromScene(int index)
    {
        SceneManager.LoadScene(index.ToString());
    }
}
