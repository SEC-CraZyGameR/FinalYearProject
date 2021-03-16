using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    private static InputHandler instance = null;

    public static InputHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<InputHandler>();

                if (instance == null)
                {

                    GameObject inputHandler = new GameObject("InputHandler");
                    instance = inputHandler.AddComponent<InputHandler>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null) instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    private KeyCode _restart = KeyCode.JoystickButton4;
    private KeyCode _home = KeyCode.JoystickButton5;

    private void Update()
    {
        if (Input.GetKeyDown(_restart))
        {
            ReloadScene();
        }
        if (Input.GetKeyDown(_home))
        {
            BackToHome();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToHome()
    {
        SceneManager.LoadScene(0);
    }
}
