using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BestScoreData
{
    public int score = 0;
}

public class Scores : MonoBehaviour
{
    public SquareTextureData squareTextureData;
    public Text scoreText;
    private bool newBestScore_ = false;
    private BestScoreData bestScores_ = new BestScoreData();
    private int currentScore_;
    private string bestScoreKey_ = "bsdata";

    private void Awake()
    {
        if(BinaryDataStream.Exist(bestScoreKey_))
        {
            StartCoroutine(ReadDataFile());
        }
    }

    private IEnumerator ReadDataFile()
    {
        bestScores_ = BinaryDataStream.Read<BestScoreData>(bestScoreKey_);
        yield return new WaitForEndOfFrame();
        GameEvent.UpdateBestScoreBar(currentScore_,bestScores_.score);
    }

    void Start()
    {
        currentScore_ = 0;
        newBestScore_ = false;
        squareTextureData.SetStartColor();
        UpdateScoreText();
    }

    private void OnEnable()
    {
        GameEvent.AddScores += AddScore;
        GameEvent.GameOver += SaveBestScores;
    }

    private void OnDisable()
    {
        GameEvent.AddScores -= AddScore;
        GameEvent.GameOver -= SaveBestScores;
    }

    public void SaveBestScores(bool newBestScore)
    {
        BinaryDataStream.Save<BestScoreData>(bestScores_,bestScoreKey_);
    }

    private void AddScore(int scores)
    {
        currentScore_ += scores;
        if (currentScore_ > bestScores_.score)
        {
            newBestScore_ = true;
            bestScores_.score = currentScore_;
            SaveBestScores(true);
        }

        UpdateSquareColor();
        GameEvent.UpdateBestScoreBar(currentScore_,bestScores_.score);
        UpdateScoreText();
    }

    private void UpdateSquareColor()
    {
        if(GameEvent.UpdateSquareColor != null && currentScore_ >= squareTextureData.tresholdVal)
        {
            squareTextureData.UpdateColors(currentScore_);
            GameEvent.UpdateSquareColor(squareTextureData.currentColor);
        }
    }
     
    private void UpdateScoreText()
    {
        scoreText.text = currentScore_.ToString();
    }
}
