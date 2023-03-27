using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelKontroller levelKontroller;
    private bool afterFinishedTab = false;

    private bool isFfinished = false;

    void Update()
    {
        if (isFfinished)
        {
            if (Input.GetMouseButtonDown(0) && !afterFinishedTab)
            {
                afterFinishedTab = true;
                levelKontroller.nextLevel();
            }
        }
    }
    private void OnCollisionEnter(Collision col)
    {

        if (!isFfinished)
        {
            isFfinished = true;
        }

    }
}
