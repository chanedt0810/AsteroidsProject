using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
	[SerializeField]
	Text scoreText;

	float elapsedSeconds = 0f;
	bool timerRunning = true;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () 
	{
		scoreText.text = "0";
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update () 
	{
		if (timerRunning)
		{
			elapsedSeconds += Time.deltaTime;
			scoreText.text = ((int)elapsedSeconds).ToString();
		}		
	}

	public void StopGameTimer()
	{
		timerRunning = false;
	}
}
