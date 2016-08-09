using UnityEngine;
using System.Collections;

public class SelfFilledController : MonoBehaviour
{
    public SpriteRenderer inverseFlag;
    public Sprite greyFlag;
    public GameObject explanationText;
    private float currentTimeToChangeSprite;
    public float timeToChangeSprite;

    public bool canCountTime;
    public bool canShowInfo;
    public Animator gameOverAnimator;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        if(Input.anyKey)
        {
            if (explanationText != null && explanationText.activeSelf)
            {
                explanationText.SetActive(false);
                canCountTime = true;
            }
        }

        if (canCountTime)
        {
            currentTimeToChangeSprite += Time.deltaTime;
        }
        
        if(currentTimeToChangeSprite > timeToChangeSprite)
        {
            inverseFlag.sprite = greyFlag;
            canShowInfo = true;
        }
	}

    void OnGUI()
    {
        if (canShowInfo)
        {
            if (GUI.Button(new Rect(10, 10, 100, 100), "INFO"))
            {
                gameOverAnimator.Play("OpenGameOver");
            }
        }
    }
}
