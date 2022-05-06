using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{

    public struct CharacterInfo
    {
        public int currentAnimation;

        public CharacterInfo(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;
        }
    }

    public static CustomSceneManager instance;

    public static CharacterInfo characterInfo;

    void Start()
    {
        if (CustomSceneManager.instance == null)
        {
            CustomSceneManager.instance = this;
            DontDestroyOnLoad(gameObject);
            characterInfo = new CharacterInfo(-1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void JumpLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void OnLevelWasLoaded(int level)
    {
        string levelName = SceneManager.GetActiveScene().name;
        switch(levelName)
        {
            case "Menu":
                onMenuOpen();
                break;
            case "Gameplay":
                onGameplayOpen();
                break;
        }
    }

    private void onMenuOpen()
    {
        Debug.Log("onMenuOpen");
    }

    private void onGameplayOpen()
    {
        Debug.Log("onGameplayOpen");
    }

}
