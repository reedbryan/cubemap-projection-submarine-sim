using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleMovement : MonoBehaviour
{
    public Animation animator;
    public EnclosureScaler enclosure;

    private float MaxDirstanceFromCenter;
    public Vector2 ChangeDirectionTime = new Vector2(2f, 20f);

    public float minRotationX = -30f; // Minimum rotation on the X-axis
    public float maxRotationX = 30f;  // Maximum rotation on the X-axis
    public float minRotationY = -45f; // Minimum rotation on the Y-axis
    public float maxRotationY = 45f;  // Maximum rotation on the Y-axis
    public float moveSpeed = 5f;      // Speed of movement

    void Start()
    {
        MaxDirstanceFromCenter = enclosure.enclosureSize * 2.5f;

        // Set a random rotation on the X and Y axes
        float randomX = Random.Range(minRotationX, maxRotationX);
        float randomY = Random.Range(minRotationY, maxRotationY);
        transform.rotation = Quaternion.Euler(randomX, randomY, 0f);

        ChangeDirection();
    }

    void Update()
    {
        // Move the transform forward based on its current rotation
        transform.position += transform.forward * -1f * moveSpeed * Time.deltaTime;
    }

    public float ChangeDirectionDuration = 9.8f; // 9.8f is the duration of the "dive" animation
    void ChangeDirection()
    {
        if (animator != null)
        {
            animator.Blend("dive"); // Play the "dive" animation
            //Debug.Log("Dive animation played");
        }

        StartCoroutine(
            ChangeDirectionCR(
                GetNewRotation()
                , ChangeDirectionDuration
                , "fastswim2" // Animation to play when surfacing
            )
        );
    }

    Quaternion GetNewRotation(){
        if (transform.position.magnitude > MaxDirstanceFromCenter) 
        {   // If the whale is getting too far from the camera then point it back towards 0,0,0
            return Quaternion.LookRotation(transform.position.normalized); 
        }
        else // Else get a random direction
        { 
            return Random.rotation; 
        }
    }
    
    IEnumerator ChangeDirectionCR(Quaternion targetRotation, float duration, string animationName)
    {
        Quaternion startRotation = transform.rotation;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure it ends exactly at the target rotation
        animator.Blend(animationName); // Play the "fastswim" animation for surfacing
        //Debug.Log($"{animationName} animation played");

        // Wait a random amount of time
        yield return new WaitForSeconds(Random.Range(ChangeDirectionTime.x, ChangeDirectionTime.y));

        ChangeDirection();
    }
}