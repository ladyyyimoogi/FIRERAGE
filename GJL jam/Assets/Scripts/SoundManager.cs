using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] internal AudioSource as_collect;
    [SerializeField] internal AudioSource as_dead;
    [SerializeField] internal AudioSource as_flamethrower;
    [SerializeField] internal AudioSource as_opencage;
    [SerializeField] internal AudioSource as_explosion;
    [SerializeField] internal AudioSource as_gameover;

    public enum SoundPlay
    {
        collect,
        dead,
        flamethrower,
        opencage,
        explosion,
        gameover
    }

    private void OnEnable()
    {
        EventManager.StartListening("PlaySound", OnPlaySound);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PlaySound", OnPlaySound);
    }

    private void OnPlaySound(Dictionary<string, object> message)
    {
        SoundPlay sfx = (SoundPlay)message["sfx"];
        switch (sfx)
        {
            case SoundPlay.collect: { as_collect.Play(); break; }
            case SoundPlay.dead: { as_dead.Play(); break; }
            case SoundPlay.flamethrower: { as_flamethrower.Play(); break; }
            case SoundPlay.opencage: { as_opencage.Play(); break; }
            case SoundPlay.explosion: { as_explosion.Play(); break; }
            case SoundPlay.gameover: { as_gameover.Play(); break; }
            default: { break; }
        }
    }
}

