using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> questList = new List<Quest>();
    public Quest quest1;
    public Quest quest2;
    public Quest quest3;
    public GameObject questUI;

    public PlayerBehaviour player;
    public Transform playerTransform;
    public Transform nPC;
    public Text titleText;
    public Text descriptionText;
    //public GameObject goalItemImg;
    //public GameObject rewardItemImg;
     void Start()
    {
        questList.Add(quest1);
        questList.Add(quest2);
        questList.Add(quest3);
    }

    public void ToggleOnQuestUI()
    {
        if (Vector3.Distance(playerTransform.position, nPC.position) < 4)
        {
            questUI.SetActive(true);
            titleText.text = questList[0].title;
            descriptionText.text = questList[0].description;
            //goalItemImg.GetComponent<Image>().sprite = questList[0].goalSprite;
            //rewardItemImg.GetComponent<Image>().sprite = questList[0].rewardSprite;
        }
    }

    public void AcceptQuest()
    {
        questUI.SetActive(false);
        questList[0].isActive = true;
        player.quest = questList[0];
    }

    public void UpdateQuestList()
    {
        questList.Remove(questList[0]);
    }
}
