using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //public InventoryObject inventory;

    //public void OnTriggerEnter(Collider other)
    //{
    //    var item = other.GetComponent<Item>();
    //    if (item)
    //    {
    //        inventory.AddItem(item.item, 1);
    //        Destroy(other.gameObject);
    //    }
    //}
    //private void OnApplicationQuit()
    //{
    //    inventory.Container.Clear();
    //}

    //
    public CharacterController controller;

    public Joystick joystick;
    public float horizontalSensitivity;
    public float verticalSensitivity;

    public GameObject miniMap;

    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;

    public AudioClip walkAudio;
    public AudioClip jumpAudio;
    private AudioSource audioSource;

    public HealthBarScreenSpaceController healthBar;
    public int health = 100;

    [Header("Scene Data")]
    public SceneDataSO sceneData1;
    public SceneDataSO sceneData2;
    public SceneDataSO sceneData3;
    public SceneDataSO sceneData4;

    public Quest quest;
    public QuestGiver questGiver;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        //if (StaticClass.CrossSceneValue == 1)
        //{
        //    controller.enabled = false;
        //    transform.position = sceneData1.playerPosition;
        //    transform.rotation = sceneData1.playerRotation;
        //    controller.enabled = true;

        //    health = sceneData1.playerHealth;
        //    healthBar.SetHealth(sceneData1.playerHealth);
        //}
        //else if (StaticClass.CrossSceneValue == 2)
        //{
        //    controller.enabled = false;
        //    transform.position = sceneData2.playerPosition;
        //    transform.rotation = sceneData2.playerRotation;
        //    controller.enabled = true;

        //    health = sceneData2.playerHealth;
        //    healthBar.SetHealth(sceneData2.playerHealth);
        //}
        //else if (StaticClass.CrossSceneValue == 3)
        //{
        //    controller.enabled = false;
        //    transform.position = sceneData3.playerPosition;
        //    transform.rotation = sceneData3.playerRotation;
        //    controller.enabled = true;

        //    health = sceneData3.playerHealth;
        //    healthBar.SetHealth(sceneData3.playerHealth);
        //}
        //else if (StaticClass.CrossSceneValue == 4)
        //{
        //    controller.enabled = false;
        //    transform.position = sceneData4.playerPosition;
        //    transform.rotation = sceneData4.playerRotation;
        //    controller.enabled = true;

        //    health = sceneData4.playerHealth;
        //    healthBar.SetHealth(sceneData4.playerHealth);
        //}
    }

    // Update is called once per frame - once every 16.6666ms

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        // Input for WebGL and Desktop
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * maxSpeed * Time.deltaTime);

        //if (Input.GetButton("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        //}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //Sound effect
        if (isGrounded == true && move != new Vector3(0,0,0) && audioSource.isPlaying == false)
        {
            audioSource.pitch = Random.Range(0.8f, 1.1f);
            audioSource.PlayOneShot(walkAudio, 7f);
        }
        else if (isGrounded == false && audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(jumpAudio, 10f);
        }

        Questing();
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
    }

    void ToggleMinimap()
    {
        // toggle the MiniMap on/off
        miniMap.SetActive(!miniMap.activeInHierarchy);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.TakeDamage(damage);

        if(health < 0)
        {
            health = 0;
        }
    }

    public void OnJumpButtonPressed()
    {
        if (isGrounded)
        {
            Jump();
        }
    }

    public void OnMapButtonPressed()
    {
        ToggleMinimap();
    }

    public void Questing()
    {
        if (quest.isActive)
        {
            
            if (quest.goal.IsReached())
            {
                Inventory.instance.Add(quest.reward);
                questGiver.UpdateQuestList();
                quest.Complete();
            }
        }
    }
}
