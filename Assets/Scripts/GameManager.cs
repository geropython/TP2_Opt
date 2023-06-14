using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        //Juego 
        {
            SceneManager.LoadScene(1);
        }
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        //Menu
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}