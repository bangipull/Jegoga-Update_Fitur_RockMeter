using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int multiplier = 1; // Inisialisasi dengan nilai 1
    int streak = 0;

    public RockMeter rockMeter; // Referensi ke RockMeter

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("RockMeter", 25);
    }

    void Update()
    {
        // Panggil AddStreak atau ResetStreak sesuai dengan kondisi permainan
        // Contoh:
        // if (playerCorrect) { AddStreak(); }
        // if (playerMistake) { ResetStreak(); }
    }

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Multi", multiplier);
    }

    public void AddStreak()
    {
        int rockMeterValue = PlayerPrefs.GetInt("RockMeter");
        if (rockMeterValue + 1 < 50)
            PlayerPrefs.SetInt("RockMeter", rockMeterValue + 1);

        streak++;
        if (streak >= 24)
            multiplier = 4;
        else if (streak >= 16)
            multiplier = 3;
        else if (streak >= 8)
            multiplier = 2;
        else
            multiplier = 1;

        UpdateGUI(); // Update GUI setelah mengubah streak dan multiplier
        rockMeter.UpdateNeedle(); // Memanggil update needle pada rock meter
    }

    public void ResetStreak()
    {
        int rockMeterValue = PlayerPrefs.GetInt("RockMeter");
        PlayerPrefs.SetInt("RockMeter", rockMeterValue - 2);
        if (rockMeterValue - 2 < 0)
            Lose();

        streak = 0;
        multiplier = 1;
        UpdateGUI();
        rockMeter.UpdateNeedle(); // Memanggil update needle pada rock meter
    }

    void Lose()
    {
        SceneManager.LoadScene(8);
    }

    public void Win()
    {
        if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        SceneManager.LoadScene(7);
    }

    public int GetScore()
    {
        return 10 * multiplier;
    }
}
