using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector2 lastMovement;
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed;
    GameObject doorpanel;
    DoorController activeDoor = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        lastMovement = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();

        Button openbutton = GameObject.Find("OpenButton").GetComponent<Button>();
        openbutton.onClick.AddListener(OnOpenButton);

        Button closebutton = GameObject.Find("CloseButton").GetComponent<Button>();
        closebutton.onClick.AddListener(OnCloseButton);

        Button lockbutton = GameObject.Find("LockButton").GetComponent<Button>();
        lockbutton.onClick.AddListener(OnLockButton);

        Button unlockbutton = GameObject.Find("UnlockButton").GetComponent<Button>();
        unlockbutton.onClick.AddListener(OnUnlockButton);

        doorpanel = GameObject.Find("DoorPanel");
        doorpanel.SetActive(false);
    }

    void OnOpenButton()
    {
        Debug.Log("Door Opened");
        activeDoor.ReceiveAction(DoorController.Toiminto.Avaa);
       
    }

    void OnCloseButton()
    {
        Debug.Log("Door Closed");
        activeDoor.ReceiveAction(DoorController.Toiminto.Sulje);
    }

    void OnLockButton()
    {
        Debug.Log("Door Locked");
        activeDoor.ReceiveAction(DoorController.Toiminto.Lukitse);
    }

    void OnUnlockButton()
    {
        Debug.Log("Door Unlocked");
        activeDoor.ReceiveAction(DoorController.Toiminto.AvaaLukko);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + lastMovement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Huomaa mitä pelaaja löytää
        if (collision.CompareTag("Door"))
        {
            Debug.Log("Found Door");

            doorpanel.SetActive(true);
            activeDoor = collision.gameObject.GetComponent<DoorController>();
        }
        else if (collision.CompareTag("Merchant"))
        {
            Debug.Log("Found Merchant");
        }
    }

    void OnMoveAction(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        lastMovement = v;
    }    
}
