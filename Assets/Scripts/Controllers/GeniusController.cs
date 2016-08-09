using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeniusController : MonoBehaviour
{
    private Vector3 fadeIndicatorInitialPosition;
    public Transform fadeIndicator;
    public Transform[] fadePositions;

    private float currentTimeToChangeFadePosition;
    public int countTime;
    private float currentTimeToSort;
    private bool canSort = true;
    private int sortPosition;
    private int numberOfSort;

    //id sort
    private int idColor;
    public GameObject rightImg;
    public GameObject wrongImg;

    //colors
    public TouchColorGenius[] touchColors;
    private int idTouchColor;
    public int[] geniusSequence;
    public List<int> userSequence = new List<int>();
    public Animator gameOverObjects;

    //check color
    //public List<int> geniusSequence = new List<int>();
    //public List<int> userSequence = new List<int>();

	void Start ()
    {
        fadeIndicatorInitialPosition = fadeIndicator.position;
        rightImg.SetActive(false);
        wrongImg.SetActive(false);
        geniusSequence = new int[4]{0, 1, 2, 3};
	}

	void Update ()
    {
        //GeniusLogic();
        TouchColorGenius();

        if (idColor >= 3)
        {
            for (int i = 0; i < geniusSequence.Length; i++)
            {
                if (geniusSequence[i] == userSequence[i])
                {
                    Debug.Log("OK");
                }
            }
        }

        //currentTimeToChangeFadePosition += Time.deltaTime;

     //   if(currentTimeToChangeFadePosition > 1)
     //   {
     //       countTime++;
     //   }

     //   currentTimeToSort += Time.deltaTime;

	    //if(sortPosition == 0 || sortPosition == 4 || sortPosition == 8 && countTime == 1)
     //   {
     //       //geniusSequence.Add(1);
     //       //Debug.Log("Add 1");
     //       //SoundController.PlaySound(SoundState.GENIUS_RED);
     //       fadeIndicator.position = fadePositions[0].position;
     //       fadeIndicator.localScale = fadePositions[0].localScale;
     //       idColor = 1;
     //       currentTimeToChangeFadePosition = 0;
     //   }

     //   else if (sortPosition == 1 || sortPosition == 5 || sortPosition == 9 && countTime == 1)
     //   {
     //       //SoundController.PlaySound(SoundState.GENIUS_YELLOW);
     //       fadeIndicator.position = fadePositions[1].position;
     //       fadeIndicator.localScale = fadePositions[1].localScale;
     //       idColor = 2;
     //       currentTimeToChangeFadePosition = 0;
     //   }

     //   else if (sortPosition == 2 || sortPosition == 6 || sortPosition == 10 && countTime == 1)
     //   {
     //       //SoundController.PlaySound(SoundState.GENIUS_BLUE);
     //       fadeIndicator.position = fadePositions[2].position;
     //       fadeIndicator.localScale = fadePositions[2].localScale;
     //       idColor = 3;
     //       currentTimeToChangeFadePosition = 0;
     //   }

     //   else if (sortPosition == 3 || sortPosition == 7 || sortPosition == 11 && countTime == 1)
     //   {
     //       //SoundController.PlaySound(SoundState.GENIUS_GREEN);
     //       fadeIndicator.position = fadePositions[3].position;
     //       fadeIndicator.localScale = fadePositions[3].localScale;
     //       idColor = 4;
     //       currentTimeToChangeFadePosition = 0;
     //   }
    }

    void GeniusLogic()
    {
        if (numberOfSort < 5)
        {
            if (currentTimeToSort > 1)
            {
                canSort = true;
                currentTimeToSort = 0;
                numberOfSort++;
            }

            if (canSort)
            {
                sortPosition = Random.Range(0, 11);
                canSort = false;
            }
        }

        else if (numberOfSort >= 5)
        {
            fadeIndicator.gameObject.SetActive(false);
        }
    }

    void TouchColorGenius()
    {
        //touch color red
        if (touchColors[0].canDo == 1)
        {
            SoundController.PlaySound(SoundState.GENIUS_RED);
            userSequence.Add(0);
            idTouchColor = 0;
            touchColors[0].canDo = 0;

            if (geniusSequence[0] == userSequence[0])
            {
                Debug.Log("ok");
            }
        }

        //touch color yellow
        if (touchColors[1].canDo == 1)
        {
            SoundController.PlaySound(SoundState.GENIUS_YELLOW);
            userSequence.Add(1);
            idTouchColor = 1;
            touchColors[1].canDo = 0;

            if (geniusSequence[1] == userSequence[1])
            {
                Debug.Log("ok");
            }
        }

        //touch color blue
        if (touchColors[2].canDo == 1)
        {
            SoundController.PlaySound(SoundState.GENIUS_BLUE);
            userSequence.Add(2);
            idTouchColor = 2;
            touchColors[2].canDo = 0;

            if (geniusSequence[2] == userSequence[2])
            {
                Debug.Log("ok");
            }
        }

        //touch color green
        if (touchColors[3].canDo == 1)
        {
            SoundController.PlaySound(SoundState.GENIUS_GREEN);
            userSequence.Add(3);
            idTouchColor = 3;
            touchColors[3].canDo = 0;

            if (geniusSequence[3] == userSequence[3])
            {
                Debug.Log("ok");
            }

            gameOverObjects.Play("OpenGameOver");
        }
    }
}
