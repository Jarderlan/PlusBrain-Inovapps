using UnityEngine;
using System.Collections;

public class StartMenuController : MonoBehaviour 
{
    [HideInInspector]
    public GameObject canvasObjects;

	void Start () 
	{

	}
	
	void Update ()
	{

	}

    public void LoadColors()
    {
        SoundController.PlaySound(SoundState.BUTTON_CLICK);
        GameController.GameControllerProperties.SetGameState(GameState.CORES);
        PlayerPrefs.SetString("IdScene", "Colors");
        StartCoroutine(LoadSceneLoading());
        StopCoroutine("LoadSceneLoading");
    }

    public void LoadCardTrick()
    {
        SoundController.PlaySound(SoundState.BUTTON_CLICK);
        GameController.GameControllerProperties.SetGameState(GameState.CARD_TRICK);
        PlayerPrefs.SetString("IdScene", "Card_Trick");
        StartCoroutine(LoadSceneLoading());
        StopCoroutine("LoadSceneLoading");
    }

    public void LoadGenius()
    {
        SoundController.PlaySound(SoundState.BUTTON_CLICK);
        GameController.GameControllerProperties.SetGameState(GameState.GENIUS);
        PlayerPrefs.SetString("IdScene", "Genius");
        StartCoroutine(LoadSceneLoading());
        StopCoroutine("LoadSceneLoading");
    }

    public void LoadSelfColor()
    {
        SoundController.PlaySound(SoundState.BUTTON_CLICK);
        GameController.GameControllerProperties.SetGameState(GameState.SELF_COLOR);
        PlayerPrefs.SetString("IdScene", "Self_Filled_Color");
        StartCoroutine(LoadSceneLoading());
        StopCoroutine("LoadSceneLoading");
    }

    /*
    IEnumerator LoadSceneColors()
    {
        yield return new WaitForSeconds(0.2f);
        Application.LoadLevelAsync("Colors");
    }

    IEnumerator LoadSceneCardTrick()
    {
        yield return new WaitForSeconds(0.2f);
        Application.LoadLevel("Card_Trick");
    }

    IEnumerator LoadSceneGenius()
    {
        yield return new WaitForSeconds(0.2f);
        Application.LoadLevel("Genius");
    }

    IEnumerator LoadSceneSelfColor()
    {
        yield return new WaitForSeconds(0.2f);
        Application.LoadLevel("Self_Filled_Color");
    }
    */

    IEnumerator LoadSceneLoading()
    {
        yield return new WaitForSeconds(0.3f);
        canvasObjects.SetActive(false);
        Application.LoadLevelAdditiveAsync("Loading");
    }
}
