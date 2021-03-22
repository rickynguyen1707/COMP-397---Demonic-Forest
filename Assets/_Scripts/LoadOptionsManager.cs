using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOptionsManager : MonoBehaviour
{
    [Header("Player Settings")]
    public PlayerBehaviour player;

    [Header("Scene Data")]
    public SceneDataSO sceneData1;
    public SceneDataSO sceneData2;
    public SceneDataSO sceneData3;
    public SceneDataSO sceneData4;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSlot1()
    {
        player.controller.enabled = false;
        player.transform.position = sceneData1.playerPosition;
        player.transform.rotation = sceneData1.playerRotation;
        player.controller.enabled = true;

        player.health = sceneData1.playerHealth;
        player.healthBar.SetHealth(sceneData1.playerHealth);
    }
    
    public void LoadSlot2()
    {
        player.controller.enabled = false;
        player.transform.position = sceneData2.playerPosition;
        player.transform.rotation = sceneData2.playerRotation;
        player.controller.enabled = true;

        player.health = sceneData2.playerHealth;
        player.healthBar.SetHealth(sceneData2.playerHealth);
    }
    public void LoadSlot3()
    {
        player.controller.enabled = false;
        player.transform.position = sceneData3.playerPosition;
        player.transform.rotation = sceneData3.playerRotation;
        player.controller.enabled = true;

        player.health = sceneData3.playerHealth;
        player.healthBar.SetHealth(sceneData3.playerHealth);
    }
    public void LoadSlot4()
    {
        player.controller.enabled = false;
        player.transform.position = sceneData4.playerPosition;
        player.transform.rotation = sceneData4.playerRotation;
        player.controller.enabled = true;

        player.health = sceneData4.playerHealth;
        player.healthBar.SetHealth(sceneData4.playerHealth);
    }
}
