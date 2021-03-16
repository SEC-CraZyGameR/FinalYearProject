using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public bool isReadyForMove = true;

    [SerializeField] Transform roadSign;
    [SerializeField] Transform playerVehicle;


    bool isSeatBeltDone = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        isReadyForMove = false;

        _ = InputHandler.Instance;
    }

    public void Start()
    {
        SeatBeltCommand();
    }

    public void SeatBeltCommand()
    {
        string strtSeatBeltCommand = "Please, Use Seat Belt To Start Car. Input joystick's B key to wear seat belt";
        VoiceController.Instance.StartSpeak(strtSeatBeltCommand);
    }

    public void InputInstruction()
    {
        string inputInstruction = "Use joystick's left wheel to move";
        VoiceController.Instance.StartSpeak(inputInstruction);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.X))
        {
            if (!isSeatBeltDone)
            {
                isSeatBeltDone = true;
                VoiceController.Instance.StopSpeak();
                isReadyForMove = true;
                MSVehicleControllerFree.Instance.theEngineIsRunning = true;

            }
        }
    }

}
