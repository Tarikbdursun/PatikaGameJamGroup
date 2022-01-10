using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCollectable : BaseCollectable
{
    private ParticleSystem particle;
    private void Start()
    {
        particle = Player.Instance.transform.GetChild(1).GetComponent<ParticleSystem>();
    }
    protected override void Increase()
    {
        base.Increase();
        ScoreController.Instance.BadScore++;
        particle.Play();
        particle.Clear();
    }


}
