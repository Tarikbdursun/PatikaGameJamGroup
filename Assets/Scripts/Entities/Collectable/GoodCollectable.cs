using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCollectable : BaseCollectable
{
    private ParticleSystem particle;
    private void Start()
    {
        particle = Player.Instance.transform.GetChild(0).GetComponent<ParticleSystem>();
    }
    protected override void Increase()
    {
        base.Increase();
        ScoreController.Instance.GoodScore++;
        particle.Play();
        particle.Clear();
    }



}
