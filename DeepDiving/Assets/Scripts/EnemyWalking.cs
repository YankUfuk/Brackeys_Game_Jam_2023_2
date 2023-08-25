using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    public float speed;

    private int moveDirection = 1; // 1 for moving right, -1 for moving left
    private int movesCount = 0;

    private bool shouldFlip = false;

    void FixedUpdate()
    {
        if (shouldFlip)
        {
            FlipObject();
            shouldFlip = false;
        }

        transform.position += Vector3.right * moveDirection * speed * Time.deltaTime;

        if (moveDirection == 1 && transform.position.x > 17.2f)
        {
            moveDirection = -1;
            movesCount++;
            shouldFlip = true;
        }
        else if (moveDirection == -1 && transform.position.x < 6.15f)
        {
            moveDirection = 1;
            movesCount++;
            shouldFlip = true;
        }

      
    }

    void FlipObject()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
