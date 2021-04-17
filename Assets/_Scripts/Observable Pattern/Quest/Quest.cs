using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
    //public Sprite goalSprite;
    //public Sprite rewardSprite;

    public QuestGoal goal;
    public Item reward;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " was completed");
        GlobalAchievements.ach01Count += 1;
    }
}
