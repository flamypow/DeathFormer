using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowCredits()
    {
        
    }
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
