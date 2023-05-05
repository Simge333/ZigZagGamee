using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color[] colors;

    Color ilkRenk, ikinciRenk;
    int birinciRenk;

    public Material zeminMat;
    private void Start()
    {
        birinciRenk = Random.Range(0, colors.Length);
        if (birinciRenk%2==0)
        {
            zeminMat.color = colors[birinciRenk];
            Camera.main.backgroundColor = colors[birinciRenk+1];
        }
        else
        {
            zeminMat.color = colors[birinciRenk+1];
            Camera.main.backgroundColor = colors[birinciRenk + 2];

        }
       
    }

}
