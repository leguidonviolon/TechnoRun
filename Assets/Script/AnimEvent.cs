﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private AudioClip m_soundWalkingClip;
    [SerializeField] private Transform m_LeftFoot;
    [SerializeField] private Transform m_RightFoot;
    [SerializeField] private ParticleSystem m_StepParticles;
    private ParticlePooling m_ParticlePooling;

    private void Awake()
    {
        m_ParticlePooling = GameObject.Find("ParticlePooling").GetComponent<ParticlePooling>();
    }

    public void PlayStepAudio()
    {
        m_audioSource.clip = m_soundWalkingClip;
        m_audioSource.Play();
    }

    public void CreateParticles(int pFoot)
    {
        if (pFoot == 0)
        {
            m_ParticlePooling.CreateParticle(m_StepParticles, m_LeftFoot);
        }
        else
        {
            m_ParticlePooling.CreateParticle(m_StepParticles, m_RightFoot);
        }
        
    }
}
