using UnityEngine;
using Unity.Netcode;
using TMPro;
using UnityEngine.UI;

public class GameUI : NetworkBehaviour
{
    public TextMeshProUGUI leftPlayerScore;
    public TextMeshProUGUI rightPlayerScore;
    public TextMeshProUGUI leftWinText;
    public TextMeshProUGUI rightWinText;
    public Button startButton;
    private GameManager gameManager;
    private int winState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        leftPlayerScore.text = $"{gameManager.GetLeftScore()}";
        rightPlayerScore.text = $"{gameManager.GetRightScore()}";
        winState = gameManager.GetWinState();
        if (winState == 2)
        {
            leftWinText.gameObject.SetActive(true);
            rightWinText.gameObject.SetActive(false);
        }
        else if(winState == 3)
        {
            leftWinText.gameObject.SetActive(false);
            rightWinText.gameObject.SetActive(true);
        }

        if (winState != 1)
        {
            startButton.gameObject.SetActive(true);
        }
        else
        {
            startButton.gameObject.SetActive(false);
            rightWinText.gameObject.SetActive(false);
            leftWinText.gameObject.SetActive(false);
        }
    }
}
