using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class BallRenderer2
{
    public int idBall;
    public int chessID;
    public Sprite ballSprite;
}

public class SkipButton : MonoBehaviour
{
    private int idBall;
    private SpriteRenderer sr;
    public SpriteRenderer renderer;
    public List<BallRenderer2> renderers;
    public GameObject chestroom;

    private void Awake()
    {
        this.sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void Skip()
    {
        chestroom.SetActive(false);
        idBall = PlayerPrefs.GetInt("idballselected");
        this.sr.enabled = true;
        renderer.sprite = renderers.Find(o => o.idBall == idBall).ballSprite;
    }
 
}
