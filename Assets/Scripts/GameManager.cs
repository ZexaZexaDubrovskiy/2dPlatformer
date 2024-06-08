using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        HeartManager.Instance.ResetHearts();
        KeyManager.Instance.KeysPlayer = 0;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
