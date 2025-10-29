using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
public TMP_Text winnerText;
    public Button playAgainButton;
    public Button quitButton;

    void Start()
    {
        gameOverPanel.SetActive(false);
        playAgainButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void GameOver(string winner)
    {
        gameOverPanel.SetActive(true);
        winnerText.text = winner + " has won!";
    }

    public void PlayAgain()
    {

        gameOverPanel.SetActive(false); // Hide panel immediately
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
}
    
}