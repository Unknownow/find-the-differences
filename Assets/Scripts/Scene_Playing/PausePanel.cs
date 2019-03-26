﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour {
    private GameObject _pausePanel;
    private TimeManager _timeManager;

	// Use this for initialization
	void Start () {
        _pausePanel = GameObject.FindGameObjectWithTag("Pause Panel");
        _pausePanel.SetActive(false);
        _timeManager = gameObject.GetComponent<TimeManager>();
	}

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _pausePanel.SetActive(!_pausePanel.activeSelf);
        }
    }

    //pause function. 
    public void onPauseClick()
    {
        Debug.Log("resume");
        _pausePanel.SetActive(true);
        _pausePanel.GetComponent<TweenAlpha>().PlayForward();
        gameObject.GetComponent<ObjectManager>().blurBackground();
        _timeManager.stopTime(true);
    }


    //resume function
    public void onResumeClick()
    {
        _timeManager.stopTime(false);
        gameObject.GetComponent<ObjectManager>().unblurBackground();
        _pausePanel.GetComponent<TweenAlpha>().PlayReverse();
    }

    public void onBackToMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void onBackToLevelSelectionClick()
    {
        GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().setBackToLevelSelection(true);
        SceneManager.LoadScene(0);
    }
}
