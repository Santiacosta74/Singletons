using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // Necesario para reiniciar la escena

public class GameManager : MonoBehaviour
{
    public int pointsToWin = 10;
    private int currentPoints = 0;

    public TextMeshProUGUI currentPointsText;
    public TextMeshProUGUI pointsToWinText;
    public GameObject victoryText;
    public GameObject restartButton;

    private bool gameIsOver = false; 

    void Start()
    {
        UpdatePointsText();
        restartButton.SetActive(false);  
    }

    void Update()
    {
        if (gameIsOver)
            return; 

        if (Input.GetKeyDown(KeyCode.P))
        {
            AddPoints(1);
        }
    }

    public void AddPoints(int points)
    {
        currentPoints += points;

        UpdatePointsText();

        if (currentPoints >= pointsToWin)
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Level Complete!");
        SoundManager.instance.PlaySound("victory");
        victoryText.SetActive(true);  
        gameIsOver = true; 
        restartButton.SetActive(true);  
    }

    private void UpdatePointsText()
    {
        currentPointsText.text = "Current Points: " + currentPoints.ToString();
        pointsToWinText.text = "Points to Win: " + pointsToWin.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
}
