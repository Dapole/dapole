using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _ConBtn;

    private void Start()
    {
        string path = Application.persistentDataPath + "/player.sls";
        if (File.Exists(path))
        {
            _ConBtn.SetActive(true);
        }
        else
        {
            _ConBtn.SetActive(false);
        }
    }

    public void StartHandler()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitHandler()
    {
        Application.Quit();
    }

    public void ContinueHandler()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.level);
    }
}
