using UnityEngine;
using System.Collections;

public enum GameState
{
	START_MENU,
	CORES,
    CARD_TRICK,
    GENIUS,
    SELF_COLOR,
	GAME_OVER,
	WAIT
}

public class GameController
{
    private static GameController gameControllerInstance = null;
	private GameState currentGameState = GameState.CORES;

    private GameController()
    {
        Debug.Log(currentGameState);
    }

    public static GameController GameControllerProperties
    {
        get
        {
            if (gameControllerInstance == null)
            {
                gameControllerInstance = new GameController();
            }

            return gameControllerInstance;
        }
    }

    public void SetGameState(GameState newGameState)
    {
        currentGameState = newGameState;
        Debug.Log(currentGameState);
    }

    public GameState GetCurrentGameState()
    {
        return currentGameState;
    }
}
