using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuController : MonoBehaviour
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
        StaticClass.CrossSceneValue = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadSlot2()
    {
        StaticClass.CrossSceneValue = 2;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadSlot3()
    {
        StaticClass.CrossSceneValue = 3;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadSlot4()
    {
        StaticClass.CrossSceneValue = 4;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
