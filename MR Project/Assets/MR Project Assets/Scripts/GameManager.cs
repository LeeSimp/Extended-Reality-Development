using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PinManager pinManager;
    public BowlingScoreManager scoreManager;
    private int previousStanding = 10;

    public void OnBallThrown(int pinsKnockedDown = -1)
    {
        if (pinsKnockedDown >= 0)
        {
            scoreManager.Roll(pinsKnockedDown);
            return;
        }

        StartCoroutine(CheckPinsAfterDelay());
    }


    IEnumerator CheckPinsAfterDelay()
    {
        yield return new WaitForSeconds(4f); // Wait for ball to settle

        int standing = pinManager.CountStandingPins();
        int pinsKnocked = previousStanding - standing;

        scoreManager.Roll(pinsKnocked);
        previousStanding = standing;

        if (standing == 0)
        {
            pinManager.ResetPins();
            previousStanding = 10;
        }
    }
}
