using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCollectable : BaseCollectable
{
    private ParticleSystem particle;
    private void Start()
    {
        particle = Player.Instance.transform.GetChild(0).GetComponent<ParticleSystem>();
        gameObject.LeanMoveY(transform.position.y + .5f, .7f).setEaseInOutSine().setLoopPingPong();
    }
    protected override void Increase()
    {
        base.Increase();
        
        particle.gameObject.SetActive(true);
        particle.Play();
        transform.LeanScale(Vector3.one*.01f,.4f).setEaseOutSine().setOnComplete(FinalAnimate);
        
    }
    private void FinalAnimate()
    {
        ScoreController.Instance.GoodScore++;
        gameObject.SetActive(false);
    }



}
