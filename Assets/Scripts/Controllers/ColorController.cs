using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameHud
{
	public TextMesh showScores;	
	public TextMesh showTime;
	[HideInInspector]
	public float countMin;
	[HideInInspector]
	public float countSec;
	public Animator gameOverAnimator;
}

public class ColorController : MonoBehaviour 
{
	public GameHud gameHud;
	public TouchColor[] touchColors;
	public GameObject[] nameColors;
	public int scores;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameHud.showScores.text = scores.ToString ();

		if (GameController.GameControllerProperties.GetCurrentGameState () == GameState.CORES) 
		{
			//Contador de tempo
			gameHud.countSec += Time.deltaTime;

			if (gameHud.countSec > 60)
			{
				gameHud.countMin++;
				gameHud.countSec = 0;
			}

			//exibe o tempo
			gameHud.showTime.text = gameHud.countMin.ToString("F0") + ":" + gameHud.countSec.ToString("F0");

			if(touchColors[0].isClicked)
			{
				if(touchColors[0].gameObject.tag == nameColors[0].tag)
				{
					Debug.Log ("Acertou");
					scores++;
					Debug.Log (scores);
					GameController.GameControllerProperties.SetGameState (GameState.WAIT);
				}
			}

			if (touchColors [1].isClicked) 
			{
				if (touchColors [1].gameObject.tag != nameColors [0].tag) 
				{
					Debug.Log ("Errou");
					GameController.GameControllerProperties.SetGameState(GameState.GAME_OVER);
					gameHud.gameOverAnimator.Play ("OpenGameOver");
				}
			}
		}

		if(GameController.GameControllerProperties.GetCurrentGameState () == GameState.GAME_OVER)
		{
			if(Input.GetKeyDown(KeyCode.A))
			{
				gameHud.gameOverAnimator.Play ("CloseGameOver");
			}
		}
	}
}
