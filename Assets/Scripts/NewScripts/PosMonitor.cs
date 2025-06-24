using UnityEngine;

public class PosMonitor : MonoBehaviour
{
    public EnclosureScaler enclosure;
    public float repeatRate = 10f;

    [SerializeField] Boid[] boids;

    private float timer;
    private float outOfBoundsThreshold;

    void Start()
    {
        outOfBoundsThreshold = enclosure.enclosureSize;
        Debug.Log("outOfBoundsThreshold: " + outOfBoundsThreshold);
        boids = GetComponent<BoidManager>().boids;
        timer = repeatRate;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            CheckPosition();
            timer = repeatRate;
        }
    }

    void CheckPosition()
    {
        int counter = 0;
        foreach (Boid boid in boids)
        {
            if (CheckOutOfBounds(boid.position))
            {
                boid.transform.position = Vector3.zero;
            }
        }
        Debug.Log("Boids out of bounds: " + counter);
    }

    bool CheckOutOfBounds(Vector3 position)
    {
        return Mathf.Abs(position.x) >= outOfBoundsThreshold ||
               Mathf.Abs(position.y) >= outOfBoundsThreshold ||
               Mathf.Abs(position.z) >= outOfBoundsThreshold;
    }
}
