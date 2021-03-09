using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    //up and down
    //public GameObject controlPanel;

    public RectTransform rectTransform;

    public Vector2 offScreenPosition;
    public Vector2 onScreenPosition;

    [Range(0.1f, 10.0f)]
    public float speed = 1.0f;
    public float timer = 0.0f;
    public bool isOnScreen = false;

    //bag
    public GameObject inventoryPrefab;

    public InventoryObject inventory;
    public int X_START;
    public int Y_START;

    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();

        rectTransform = GetComponent<RectTransform>();


        rectTransform.anchoredPosition = offScreenPosition;

        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();

        //up and down
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOnScreen = !isOnScreen;
            timer = 0.0f;
        }
        if (isOnScreen)
        {
            MoveControlPanelDown();
        }
        else
        {
            MoveControlPanelUp();
        }
        
    }

    private void MoveControlPanelDown()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(offScreenPosition, onScreenPosition, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    private void MoveControlPanelUp()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(onScreenPosition, offScreenPosition, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
    public void CreateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMN)), 0f);
    }
}
