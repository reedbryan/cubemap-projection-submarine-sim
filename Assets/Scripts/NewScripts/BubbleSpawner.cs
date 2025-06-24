using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject BubblePS_Prefab;
    public EnclosureScaler enclosure;

    public int bubbleStreamsCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float enclosureSize = enclosure.enclosureSize;
        
        for (int i = 0 ; i < bubbleStreamsCount; i++){
            Vector3 pos = new Vector3(
                Random.Range(enclosureSize/2,-enclosureSize/2),
                -enclosure.enclosureSize,
                Random.Range(enclosureSize/2,-enclosureSize/2)
            );
            Instantiate(BubblePS_Prefab, pos, Quaternion.Euler(-90f, 0f, 0f));
        }
    }
}
