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
        // Получаем текущий уровень. Eсли сохранен, если нет - первый
        string lastLevel = PlayerPrefs.GetString(UserProgress, "1");

        // Вызываем метод загрузки уровней и передаём его туда
        LoaderLevels(lastLevel);
    }

    public void GameOver()
    {
        this.gameObject.SetActive(true);
        this.GameOverObject.SetActive(true);
    }
    
    // Метод для сохранения текущего уровня
    public void Save()
    {
        // Получаем текущую сцену
        string currentScene = SceneManager.GetActiveScene().name;

        // Вызываем метод загрузки уровней и передаём его туда
        SetupUserProgress(currentScene);
    }

    public void NewGame()
    {
        // Запускаем первый уровень
        SetupUserProgress("1");
        LoaderLevels("1");
    }

    public void LoadMainMenu()
    {
        // Загружаем главное меню
        LoaderLevels("GameMenu");
    }

    public void ExitGame()
    {
        // Выходим с игры
        Application.Quit();
    }

    // Метод для сохранения текущего прогресса игрока
    private void SetupUserProgress(string scene)
    {
        // сохраняем название сцены 
        PlayerPrefs.SetString(UserProgress, scene);
        // Сохраняем
        PlayerPrefs.Save();
    }
    private void LoaderLevels(string level)
    {
        SceneManager.LoadScene(level);
    }
}
