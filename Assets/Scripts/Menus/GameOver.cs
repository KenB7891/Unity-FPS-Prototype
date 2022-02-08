using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    //GetComponent<TMPro.TextMeshProUGUI>().text

    public TextMeshProUGUI accuracyDisplay;
    void Start()
    {           
        if (Player.shotsFired == 0)
        {
            Player.shotAccuracy = 0.0f;
        }
        else
        {
            Player.shotAccuracy = ((float)Player.shotsHit / Player.shotsFired) * 100f;
        }
                
        accuracyDisplay.text = string.Format("Accuracy: {0:#.00}%", Player.shotAccuracy);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
