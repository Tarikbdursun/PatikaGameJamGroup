using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCollectable : BaseCollectable
{
    private ParticleSystem particle;
    private void Start()
    {
        particle = Player.Instance.transform.GetChild(1).GetComponent<ParticleSystem>();
        gameObject.LeanMoveY(transform.position.y + .5f, .7f).setEaseInOutSine().setLoopPingPong();
    }
    protected override void Increase()
    {
        base.Increase();
        particle.gameObject.SetActive(true);
        particle.Play();
        transform.LeanScale(Vector3.zero,1).setOnComplete(FinalAnimate);
        
    }
    private void FinalAnimate()
    {
        ScoreController.Instance.BadScore++;
        gameObject.SetActive(false);
    }


}
