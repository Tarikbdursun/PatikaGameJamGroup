using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCollectable : BaseCollectable
{
    protected override void Increase()
    {
        base.Increase();
        ScoreController.Instance.GoodScore++;
    }
}
