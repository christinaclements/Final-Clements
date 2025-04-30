using UnityEngine;

public class ScreenChange : MonoBehaviour
{
    
    public void goToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("gameplay");
    }
}
