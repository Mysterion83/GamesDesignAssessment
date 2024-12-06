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
    // Start is called before the first frame update
    void Start()
    {
        CurrentDeathTime = DeathTime;
        DontDestroyOnLoad(gameObject);
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
                Destroy(gameObject);
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
        
    }
    public void GameStart()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PMovement = Player.GetComponent<MovementSystem>();
        PCamera = Player.GetComponentInChildren<CameraSystem>();
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void KillPlayer()
    {
        PlayerDead = true; 
        PMovement.UnfreezeRotation();
        PMovement.CanMove = false;
        PCamera.CanMove = false;
    }
}
