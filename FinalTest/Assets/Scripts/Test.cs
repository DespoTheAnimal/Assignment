using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    // This was done with my friends Mikkel Sommer, and Daniel Lerche
    private bool isMeasuring = false;
    private Save save;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Button button;
    private void Awake()
    {
        save = new Save();
        Input.gyro.enabled = true;
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Press;
     }

    private void Start()
    {
        button.onClick.AddListener(StartSaving);   
    }

    private void StartSaving()
    {
        if(isMeasuring != true)
        {
            isMeasuring = true;
            Debug.Log("Saving...");
        }
        else
        {
            isMeasuring=false;
            Debug.Log("Data saved");
        }
    }

    private void Update()
    {
        text.text = "Accel " + Input.acceleration;
        if(isMeasuring)
        {
            save.data.Add(Input.acceleration);
        }
        if(save.data.Count > 0 && !isMeasuring)
        {
            save.WriteCSV();
            save.data.Clear();
        }
        
    }

    public void Press(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump! " + context.phase);
        }
    }
}
