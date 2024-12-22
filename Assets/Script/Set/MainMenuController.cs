using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton_Clik()
    {
        SceneManager.LoadScene(1);

        if (GameManager.Instance!=null)
        GameManager.Instance.GamePlay();

        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start() {
        AudioManager.Instance.StopBGM("InGameBGM");
        AudioManager.Instance.PlayBGM("MenuBGM");
    }


}
