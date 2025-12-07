using UnityEngine;

public class water : MonoBehaviour
{


    public float speedX = 0.1f;  // Horizontal movement speed
    public float speedY = 0.1f;  // Vertical movement speed

    private Renderer rend;
    private Vector2 currentOffset = Vector2.zero;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Increase offset over time
        currentOffset.x += speedX * Time.deltaTime;
        currentOffset.y += speedY * Time.deltaTime;

        // Apply offset to material
        rend.material.SetTextureOffset("_MainTex", currentOffset);
    }
}

