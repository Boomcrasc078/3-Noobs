using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    [SerializeField] private int firstLevelSceneIndex;
    [SerializeField] private GameObject creditsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene(firstLevelSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }
    public void HideCredits()
    {
        creditsPanel.SetActive(false);
    }
}