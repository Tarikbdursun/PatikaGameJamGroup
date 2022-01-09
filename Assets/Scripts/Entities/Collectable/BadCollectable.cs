using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCollectable : BaseCollectable
{
    protected override void Increase()
    {
        base.Increase();
        ScoreController.Instance.BadScore++;
    }
}
