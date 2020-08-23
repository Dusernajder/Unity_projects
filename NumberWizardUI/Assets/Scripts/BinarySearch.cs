using UnityEngine;
using TMPro;

public class BinarySearch : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] TextMeshProUGUI guessText;

    private int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        NextGuess();
    }

    public void NextGuess()
    {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }

    public void OnPressHigher()
    {
        min = guess;
        NextGuess();
    }

    public void OnPressLower()
    {
        max = guess - 1;
        NextGuess();
    }
}
