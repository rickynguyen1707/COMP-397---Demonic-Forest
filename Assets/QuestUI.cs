using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject questUI;
    public Text titleText;
    public Text descriptionText;
    public GameObject interactButton;

    public Transform player;
    public Transform nPC;

    public Sprite interactIcon;
    public Sprite talkIcon; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, nPC.position) < 4)
        {
            interactButton.GetComponent<Image>().sprite = talkIcon;

        }
        else
        {
            interactButton.GetComponent<Image>().sprite = interactIcon;
        }
    }

    public void ToggleOffQuestUI()
    {
        questUI.SetActive(false);
    }
}
