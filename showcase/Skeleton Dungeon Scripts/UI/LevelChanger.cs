using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    private Animator _animator;
    private int levelToLoad;

    [SerializeField] private Vector3 position;

    [SerializeField] private Slider slider;
    [SerializeField] private GameObject loadingScreen;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void FadeToLevel(int getSceneNumber)
    {
        levelToLoad = getSceneNumber;
        _animator.SetTrigger("Fade");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        StartCoroutine(LoadingScreenOnFade());
    }

    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
