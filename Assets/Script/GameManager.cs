﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_gameOverClip;
    [SerializeField] private AudioClip m_gameOverMusicClip;
    [SerializeField] private AudioClip m_advancedInLevelMusic;
    [SerializeField] private Text m_scoreText;
    [SerializeField] private GameObject m_UI;
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private Slider m_musicSlider;
    private int m_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_UI.SetActive(false);
        m_musicSlider.value = 0.75f;
        m_audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        m_audioSource.volume = m_musicSlider.value;
    }

    public void GameOver()
    {
        m_scoreText.text = "Score : " + m_score.ToString();
        m_UI.SetActive(true);
        StartCoroutine(PlayGameOverSounds());
    }

    private IEnumerator PlayGameOverSounds()
    {
        m_audioSource.Stop();
        m_audioSource.clip = m_gameOverMusicClip;
        m_audioSource.loop = false;
        m_audioSource.Play();
        while (m_audioSource.isPlaying)
        {
            yield return null;
        }
        m_audioSource.clip = m_gameOverClip;
        m_audioSource.Play();
    }

    public void SetScore(int score)
    {
        m_score = score;
    }

    public void ChangeClip()
    {
        //faire faded ici
        m_audioSource.Stop();
        m_audioSource.clip = m_advancedInLevelMusic;
        m_audioSource.Play();
    }
}
