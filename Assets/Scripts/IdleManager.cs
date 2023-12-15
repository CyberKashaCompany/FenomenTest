using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    public ParticleSystem[] idleParticles;

    int idleTimeSetting = 3;
    float LastIdleTime;
    bool isIdle = false;
    void Awake()
    {
        LastIdleTime = Time.time;
    }

    private void Update()
    {

        if (Input.anyKey)
        {
            isIdle = false;
            LastIdleTime = Time.time;
            foreach (var par in idleParticles)
            {
                par.Stop();
            }
        }

        if (IdleCheck() && !isIdle)
        {
            isIdle = true;
            foreach(var par in idleParticles)
            {
                par.Play();
            }
        }
    }

    public bool IdleCheck()
    {
        return Time.time - LastIdleTime > idleTimeSetting;
    }
}
