using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceTraveled;
    [SerializeField] private TextMeshProUGUI coinsCollected;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Player player;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject sky;


    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        sky.SetActive(false);
        var roundedDistance = Mathf.Ceil(player.distanceTravelled);
        distanceTraveled.text = "" + roundedDistance;
        coinsCollected.text = "" + player.coinsCollected;

    }
    public void GameRestart()
    {
        SceneManager.LoadScene("EndlessRunner");
    }
}
