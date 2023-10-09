using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceTraveled;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Player player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShowGameOverScreen();
        }
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        var roundedDistance = Mathf.Ceil(player.distanceTravelled);
        distanceTraveled.text = "" + roundedDistance;
    }
    public void GameRestart()
    {
        Debug.Log("Do Game Restart");
    }
}
