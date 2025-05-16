using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowlingScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    private List<int> rolls = new List<int>();
    private int currentRoll = 0;

    public void Roll(int pinsKnockedDown)
    {
        if (rolls.Count < 21)  // Max possible rolls
        {
            rolls.Add(pinsKnockedDown);
            UpdateScoreDisplay();
        }
    }

    private int CalculateScore()
    {
        int score = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (rolls.Count <= rollIndex) break;

            if (IsStrike(rollIndex))
            {
                score += 10 + StrikeBonus(rollIndex);
                rollIndex += 1;
            }
            else if (IsSpare(rollIndex))
            {
                score += 10 + SpareBonus(rollIndex);
                rollIndex += 2;
            }
            else
            {
                score += SumOfBallsInFrame(rollIndex);
                rollIndex += 2;
            }
        }

        return score;
    }

    private bool IsStrike(int rollIndex) => rolls[rollIndex] == 10;
    private bool IsSpare(int rollIndex) => rolls[rollIndex] + rolls[rollIndex + 1] == 10;

    private int StrikeBonus(int rollIndex) =>
        (rollIndex + 2 < rolls.Count) ? rolls[rollIndex + 1] + rolls[rollIndex + 2] : 0;

    private int SpareBonus(int rollIndex) =>
        (rollIndex + 2 < rolls.Count) ? rolls[rollIndex + 2 - 1] : 0;

    private int SumOfBallsInFrame(int rollIndex) =>
        (rollIndex + 1 < rolls.Count) ? rolls[rollIndex] + rolls[rollIndex + 1] : rolls[rollIndex];

    private void UpdateScoreDisplay()
    {
        int total = CalculateScore();
        scoreText.text = $"Score: {total}";
    }
}
