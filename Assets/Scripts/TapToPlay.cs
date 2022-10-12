using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TapToPlay : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        transform.DOScale(1.1f, 0.3f).SetLoops(-1, LoopType.Yoyo);
    }
}
