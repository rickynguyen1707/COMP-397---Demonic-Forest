using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public GoalType goalType;

    public Item questItem;

    public bool IsReached()
    {
        if (Inventory.instance.items.Contains(questItem))
        {
            Inventory.instance.Remove(questItem);
            return true;
        }
        else
        {
            return false;
        }
        
        
    }

    //public void ItemCollected()
    //{
    //    if (goalType == GoalType.Gathering)

    //}
}

public enum GoalType
{
    Kill, 
    Gathering
}
