using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color[] colors;

    Color ikinciRenk;
    int birinciRenk;

    public Material zeminMat;
    private void Start()
    {
        birinciRenk = Random.Range(0, colors.Length);
        ikinciRenk = colors[ikinciRenkSec()];
        zeminMat.color = colors[birinciRenk];
    
        Camera.main.backgroundColor = colors[birinciRenk];
        
       
    }
    private void Update()
    {
        //rgb renlerini birbirinden çıkarıp yeni bir renk oluşturuyor
        Color fark = zeminMat.color - ikinciRenk;
        if (Mathf.Abs(fark.r)+Mathf.Abs(fark.g)+Mathf.Abs(fark.b) < 0.2f)
        {
            //0.2f den küçük olmak çok yakın renk olmuş oluyor yeni renk oluşturmak istediğimizden bu kontrolü koyduk
            ikinciRenk = colors[ikinciRenkSec()];
        }
        zeminMat.color = Color.Lerp(zeminMat.color,ikinciRenk,0.003f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor,ikinciRenk,0.0007f);
    }
    //zemin ve background farklı renkler olsun istiyorsak
    int ikinciRenkSec()
    {
        int ikinciRenkIndex;
        ikinciRenkIndex = Random.Range(0, colors.Length);
        while (ikinciRenkIndex==birinciRenk)
        {
            ikinciRenkIndex = Random.Range(0, colors.Length);
        }
        return ikinciRenkIndex;
    }

}//class
