using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    public Vector3 EnvironmentSize = new Vector3(100, 100, 100);
    public int numberOfObjects = 20;
    
    public GameObject Anchor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            spawnCircle();
        }
    }

    void spawnCircle()
    {
        Debug.Log("Spawning circle");
        GameObject circle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        circle.transform.parent = Anchor.transform;
        circle.transform.localScale = RandomVector3(50);
        circle.transform.position = RandomVector3(EnvironmentSize.x);
        circle.GetComponent<MeshRenderer>().enabled = false;
    }

    Vector3 RandomVector3(float wholeNumber)
    {
        float x = Random.Range(-wholeNumber, wholeNumber);
        return new Vector3(x, x, x);
    }
}
