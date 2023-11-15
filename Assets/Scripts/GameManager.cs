using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreTxt, coinsTxt;
    public float score;
    [SerializeField] private GameObject gameOverPanel;
    public bool gameOver;
    private bool oneTime;
    public float coins;
    private GameObject player;

    public delegate void GameOverEvent();
    public static event GameOverEvent OnGameOver;

    private void OnEnable()
    {
        OnGameOver += GameOverr;
    }

    private void OnDisable()
    {
        OnGameOver -= GameOverr;
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        oneTime = false;
        Debug.Log(PlayerPrefs.GetFloat("Coins"));
        coins = PlayerPrefs.GetFloat("Coins");
        coinsTxt.text = Mathf.FloorToInt(PlayerPrefs.GetFloat("Coins")).ToString();
    }

    private void Update()
    {
        SetScoreText();
        if (gameOver && !oneTime)
        {
            OnGameOver();
        }
    }

    private void SetScoreText()
    {
        score = player.transform.position.x - 6.51f;
        scoreTxt.SetText("Score: " + Mathf.FloorToInt(score));
    }

    public static void GameOver()
    {
        if(OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public void LoadScene(int sceneToRealod)
    {
        SceneManager.LoadScene(sceneToRealod);
    }

    private void GameOverr()
    {
        gameOverPanel.SetActive(true);
        coins += score;
        oneTime = true;
        PlayerPrefs.SetFloat("Coins", coins);
        coinsTxt.text = Mathf.FloorToInt(PlayerPrefs.GetFloat("Coins")).ToString();
    }
}
