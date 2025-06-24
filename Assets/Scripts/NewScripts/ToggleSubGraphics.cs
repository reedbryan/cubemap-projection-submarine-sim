using UnityEngine;

public class ToggleSubGraphics : MonoBehaviour
{
    public GameObject subBody;
    public bool isActive = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)){
            ToggleSub();
        }
    }

    private void ToggleSub(){
        if (isActive){
            subBody.SetActive(false);
            isActive = false;
        } else {
            subBody.SetActive(true);
            isActive = true;
        }
    }
}
