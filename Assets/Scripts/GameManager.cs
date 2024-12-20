using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject Player;
    MovementSystem PMovement;
    CameraSystem PCamera;


    [SerializeField]
    bool PlayerDead;
    [SerializeField]
    float DeathTime;
    [SerializeField]
    float CurrentDeathTime;
    [SerializeField]
    bool GateUnlocked;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameController") != this.gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDead)
        {
            CurrentDeathTime -= Time.deltaTime;
            if (CurrentDeathTime < 0)
            {
                PlayerDead = false;
                ReturnToMainMenu();
            }
        }
    }
    public void UnlockGate()
    {
        GateUnlocked = true;
    }
    public bool GetGateUnlocked()
    {
        return GateUnlocked;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
        
    }
    public void GameStart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player = GameObject.FindGameObjectWithTag("Player");
        PMovement = Player.GetComponent<MovementSystem>();
        PCamera = Player.GetComponentInChildren<CameraSystem>();
        PlayerDead = false;
        CurrentDeathTime = DeathTime;
    }
    public void ReturnToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void KillPlayer()
    {
        PlayerDead = true; 
        PMovement.Kill();
        PCamera.CanMove = false;
        PMovement.CanMove = false;
    }
    public void FreezePlayer()
    {
        PMovement.CanMove = false;
        PMovement.Freeze = true;
        PCamera.CanMove = false;
        Cursor.lockState = CursorLockMode.None;
    }
    public void UnFreezePlayer()
    {
        PMovement.CanMove = true;
        PCamera.CanMove = true;
        PMovement.Freeze = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
