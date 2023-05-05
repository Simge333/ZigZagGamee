using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GroundSpawner groundSpawner;

    [SerializeField] float speed;

    Vector3 yon = Vector3.left;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (yon.x==0)
            {
                //z ekseninde hareket ediyor
                yon = Vector3.left;

            }
            else
            {
                //x ekseninde hareket ediyor
                yon = Vector3.back;
            }
        }
    }
    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime;//objemizin hareket değeri
        transform.position += hareket;//hareket değerini sürekli pozisyona ekle
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            YokEt(collision.gameObject);
            groundSpawner.ZeminOlustur();
        }
    }
    void YokEt(GameObject zemin)
    {
        Destroy(zemin,1);
    }

}//class
