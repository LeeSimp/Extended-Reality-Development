using UnityEngine;

public class GutterZone : MonoBehaviour
{
    public Transform ballResetPoint; // Where the ball will respawn
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball entered gutter!");

            // Tell the GameManager to register 0 pins
            if (gameManager != null)
            {
                gameManager.OnBallThrown(0); // Custom method to pass 0 pins
            }

            // Reset the ball's position
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            other.transform.position = ballResetPoint.position;
            other.transform.rotation = ballResetPoint.rotation;
        }
    }
}
