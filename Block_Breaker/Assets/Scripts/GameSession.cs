using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // config parameters
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 10;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public bool isAutoPlayEnabled;

    // state variables
    [SerializeField] private int currentScore = 0;
    private readonly bool _isAutoPlayEnabled;


    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }


    public void Update()
    {
        Time.timeScale = gameSpeed;
    }


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }


    public void ResetGame()
    {
        Destroy(gameObject);
    }


    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}