using System.Collections;
using System.Collections.Generic;
using EasyUI.PickerWheelUI;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using System;
[Serializable]
public class ImageRenderers
{
    public int IDimages;
        
    public Sprite imageSprite;
}
public class PanelReward : MonoBehaviour
{
    //public GameObject spindemo;
    public Image renderer;
    public List<ImageRenderers> renderers;
    private int IDimages;

    private void Update()
    {
        IDimages = PlayerPrefs.GetInt("IdImages");
        renderer.sprite = renderers.Find(o => o.IDimages == IDimages).imageSprite;
    }
}
