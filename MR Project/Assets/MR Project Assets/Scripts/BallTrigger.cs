using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball entered trigger zone!");
            FindObjectOfType<GameManager>().OnBallThrown();
        }
    }
}
