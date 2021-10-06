using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelsButtonLoader : MonoBehaviour
{
    const string UserProgress = "UserProgress";
    [SerializeField] Button ContinueButton;
    [SerializeField] GameObject GameOverObject;
    private void Start()
    {
        if(PlayerPrefs.GetString(UserProgress, null) == null)
        {
            if(ContinueButton != null)
            {
                ContinueButton.interactable = false;
            }
        }
    }

    public void Restart()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        LoaderLevels(currentScene);
    }

    public void Continue()
    {
        // �������� ������� �������. E��� ��������, ���� ��� - ������
        string lastLevel = PlayerPrefs.GetString(UserProgress, "1");

        // �������� ����� �������� ������� � ������� ��� ����
        LoaderLevels(lastLevel);
    }

    public void GameOver()
    {
        this.gameObject.SetActive(true);
        this.GameOverObject.SetActive(true);
    }
    
    // ����� ��� ���������� �������� ������
    public void Save()
    {
        // �������� ������� �����
        string currentScene = SceneManager.GetActiveScene().name;

        // �������� ����� �������� ������� � ������� ��� ����
        SetupUserProgress(currentScene);
    }

    public void NewGame()
    {
        // ��������� ������ �������
        SetupUserProgress("1");
        LoaderLevels("1");
    }

    public void LoadMainMenu()
    {
        // ��������� ������� ����
        LoaderLevels("GameMenu");
    }

    public void ExitGame()
    {
        // ������� � ����
        Application.Quit();
    }

    // ����� ��� ���������� �������� ��������� ������
    private void SetupUserProgress(string scene)
    {
        // ��������� �������� ����� 
        PlayerPrefs.SetString(UserProgress, scene);
        // ���������
        PlayerPrefs.Save();
    }
    private void LoaderLevels(string level)
    {
        SceneManager.LoadScene(level);
    }
}
