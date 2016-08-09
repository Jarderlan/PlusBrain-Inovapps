using UnityEngine;
using System.Collections;

public class LoadingBehaviour : MonoBehaviour 
{
    void Start()
    {
        GetComponent<Animator>().Play("OpenLoading");
    }

	public void LoadScene () 
    {
        Application.LoadLevel(PlayerPrefs.GetString("IdScene"));
	}
}
