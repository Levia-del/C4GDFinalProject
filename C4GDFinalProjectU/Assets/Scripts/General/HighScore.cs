using UnityEngine;

public class HighScore : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "HighScore";

    /// <summary>
    /// The score from the just-finished run. Set by MainGameUI before
    /// it destroys itself. Read by DeathCanvas to display.
    /// </summary>
    public static int CurrentScore { get; set; }

    /// <summary>
    /// Saves a score. If it beats the existing high score, updates it.
    /// Call this BEFORE destroying MainGameUI / loading DeathScreen.
    /// </summary>
    public static void SaveScore(int score)
    {
        CurrentScore = score;

        int previous = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        if (score > previous)
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, score);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Returns the all-time high score (0 if never set).
    /// </summary>
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }
}
