using UnityEngine;
using System.Collections;

public class HudControllerCardTrick : MonoBehaviour
{
    public Animator loadingAnimator;

    void Start()
    {
        loadingAnimator.Play("CloseLoading");
    }
	
	void Update () 
    {
	
	}

    public void LoadStartMenu()
    {
        SoundController.PlaySound(SoundState.BUTTON_CLICK);
        GameController.GameControllerProperties.SetGameState(GameState.START_MENU);
        PlayerPrefs.SetString("IdScene", "Start_Menu");
        StartCoroutine(LoadSceneStartMenu());
        StopCoroutine("LoadSceneStartMenu");
    }

    IEnumerator LoadSceneStartMenu()
    {
        yield return new WaitForSeconds(0.2f);
        Application.LoadLevelAdditiveAsync("Loading");
    }
}
