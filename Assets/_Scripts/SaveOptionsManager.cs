using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOptionsManager : MonoBehaviour
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

    public void SaveSlot1()
    {
        sceneData1.playerPosition = player.transform.position;
        sceneData1.playerRotation = player.transform.rotation;
        sceneData1.playerHealth = player.health;
    }

    public void SaveSlot2()
    {
        sceneData2.playerPosition = player.transform.position;
        sceneData2.playerRotation = player.transform.rotation;
        sceneData2.playerHealth = player.health;
    }
    public void SaveSlot3()
    {
        sceneData3.playerPosition = player.transform.position;
        sceneData3.playerRotation = player.transform.rotation;
        sceneData3.playerHealth = player.health;
    }
    public void SaveSlot4()
    {
        sceneData4.playerPosition = player.transform.position;
        sceneData4.playerRotation = player.transform.rotation;
        sceneData4.playerHealth = player.health;
    }
}
