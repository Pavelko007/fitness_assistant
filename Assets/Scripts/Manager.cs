using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Text restTimer;
    private float startTime;

    [SerializeField] private GameObject SubmitResultsPanel;
    [SerializeField] private GameObject RestPanel;
    [SerializeField] private Button submitButton;
    private bool isResting = false;

    void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            StartSession();
        });

        submitButton.onClick.AddListener(() =>
        {
            StartRestingPeriod();
        });
    }

    private void StartSession()
    {
         
    }

    void StartRestingPeriod()
    {
        isResting = true;
        SubmitResultsPanel.SetActive(false);
        RestPanel.SetActive(true);
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (!isResting) return;

	    float deltaTime = Time.time - startTime;
	    int minutes = (int) deltaTime / 60;
	    string seconds = (deltaTime%60).ToString("f2");
	    restTimer.text = string.Format("{0}:{1}", minutes, seconds);
	}
}
