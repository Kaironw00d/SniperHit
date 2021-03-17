using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameLevel
{
    Level1,
    Level2
}

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LoadLevel(GameLevel.Level1);
    }

    private void LoadLevel(GameLevel level)
    { 
        SceneManager.LoadSceneAsync(level.ToString());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}