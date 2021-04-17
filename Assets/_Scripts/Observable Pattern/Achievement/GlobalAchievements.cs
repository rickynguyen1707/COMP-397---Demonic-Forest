using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAchievements : MonoBehaviour
{
    // General Variables
    public GameObject achNote;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    // Achievement 01 Specific
    public GameObject ach01Image;
    public static int ach01Count;
    public int ach01Trigger = 1;
    public int ach01Code;

    // Achievement 02 Specific
    public GameObject ach02Image;
    public static bool triggerAch02 = false;
    public int ach02Code;

    // Update is called once per frame
    void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");
        ach02Code = PlayerPrefs.GetInt("Ach02");

        if (ach01Count == ach01Trigger && ach01Code != 12345)
        {
            StartCoroutine(Trigger01Ach());
        }

        if (triggerAch02 == true && ach02Code != 12346)
        {
            StartCoroutine(Trigger02Ach());
        }
    }

    //private void Start()
    //{
    //    PlayerPrefs.SetInt("Ach01", 0);
    //    PlayerPrefs.SetInt("Ach02", 0);
    //}
    IEnumerator Trigger01Ach()
    {
        achActive = true;
        ach01Code = 12345;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        ach01Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "FIRST TIMER";
        achDesc.GetComponent<Text>().text = "Don't wish it were easier";
        achNote.SetActive(true);
        yield return new WaitForSeconds(7);
        // Resetting UI
        achNote.SetActive(false);
        ach01Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator Trigger02Ach()
    {
        achActive = true;
        ach02Code = 12346;
        PlayerPrefs.SetInt("Ach02", ach02Code);
        ach02Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "COMPLETED";
        achDesc.GetComponent<Text>().text = "You've made it out";
        achNote.SetActive(true);
        yield return new WaitForSeconds(7);
        // Resetting UI
        achNote.SetActive(false);
        ach02Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
}
