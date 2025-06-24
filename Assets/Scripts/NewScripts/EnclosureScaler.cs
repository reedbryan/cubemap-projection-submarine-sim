using UnityEngine;

[ExecuteInEditMode]
public class EnclosureScaler : MonoBehaviour
{
    [Header("Wall Transforms")]
    public Transform wallLeft;
    public Transform wallRight;
    public Transform wallFront;
    public Transform wallBack;
    public Transform wallTop;
    public Transform wallBottom;

    [Header("Enclosure Dimensions")]
    public float enclosureSize;
    public float enclosureHeightScale;
    public float wallThickness = 1f;

    void Update()
    {
        if (!Application.isPlaying)
        {
            UpdateWalls();
        }
    }

    void UpdateWalls()
    {
        float pos = enclosureSize * 0.5f;
        float sideScaler = enclosureHeightScale;

        if (wallLeft)
        {
            wallLeft.localScale = new Vector3(wallThickness, enclosureSize * sideScaler, enclosureSize);
            wallLeft.localPosition = new Vector3(-pos, 0, 0);
            wallLeft.eulerAngles = new Vector3(0,0,0);
        }

        if (wallRight)
        {
            wallRight.localScale = new Vector3(wallThickness, enclosureSize * sideScaler, enclosureSize);
            wallRight.localPosition = new Vector3(pos, 0, 0);
            wallRight.eulerAngles = new Vector3(0,0,0);
        }

        if (wallFront)
        {
            wallFront.localScale = new Vector3(enclosureSize * sideScaler, enclosureSize, wallThickness);
            wallFront.localPosition = new Vector3(0, 0, pos);
            wallFront.eulerAngles = new Vector3(0,0,90);
        }

        if (wallBack)
        {
            wallBack.localScale = new Vector3(enclosureSize * sideScaler, enclosureSize, wallThickness);
            wallBack.localPosition = new Vector3(0, 0, -pos);
            wallBack.eulerAngles = new Vector3(0,0,90);
        }

        if (wallTop)
        {
            wallTop.localScale = new Vector3(enclosureSize, wallThickness, enclosureSize);
            wallTop.localPosition = new Vector3(0, pos * sideScaler, 0);
            wallTop.eulerAngles = new Vector3(0,90,0);
        }

        if (wallBottom)
        {
            wallBottom.localScale = new Vector3(enclosureSize, wallThickness, enclosureSize);
            wallBottom.localPosition = new Vector3(0, -pos * sideScaler, 0);
            wallBottom.eulerAngles = new Vector3(0,90,0);
        }
    }
}
