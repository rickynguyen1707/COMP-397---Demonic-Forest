using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinished : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GlobalAchievements.triggerAch02 = true;
    }
}
