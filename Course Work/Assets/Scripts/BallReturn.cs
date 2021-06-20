using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private BallLauncher ballLauncher;

    private void Awake()
    {
       ballLauncher = FindObjectOfType<BallLauncher>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            ballLauncher.ReturnBall();
            other.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }
}
