using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelKontroller : MonoBehaviour
{
    public Transform[] levels;
    private int levelNo = 0;

    public void nextLevel()
    {
        levels[levelNo].gameObject.SetActive(false);
        levelNo++;
        levels[levelNo].gameObject.SetActive(true);
    }
}
