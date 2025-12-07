using UnityEngine;

public class hunterAI : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 3f;
    public float distance;

    void Start()
    {
        // Find the player by name
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
         distance = Vector3.Distance(transform.position, playerTransform.position);

        // If player is close (within 15 meters), chase!
        if (distance < 15f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                playerTransform.position,
                speed * Time.deltaTime
            );

            transform.LookAt(playerTransform);
        }
    }

    // Game Over when the Hunter touches the Player
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
        }
    }
}
