using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Text scoreText;

    [SerializeField] float score =0f;
    float artisMiktari=1f;

    public GroundSpawner groundSpawner;

    [SerializeField] float speed;

    Vector3 yon = Vector3.left;
    public static bool isDeath = false;
    public float hizlanmaZorlugu;
    

    private void Update()
    {
        if (isDeath)
        {
            return;
        }
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
        if (transform.position.y < 0.1f)
        {
            isDeath = true;
            
            Destroy(this.gameObject, 3f);
        }
    }
    private void FixedUpdate()
    {

        Vector3 hareket = yon * speed * Time.deltaTime;//objemizin hareket değeri
        speed += Time.deltaTime * hizlanmaZorlugu;
        transform.position += hareket;//hareket değerini sürekli pozisyona ekle
        score += artisMiktari * speed * Time.deltaTime;
        scoreText.text = "Score : "+((int)score).ToString();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            StartCoroutine(YokEt(collision.gameObject));
            groundSpawner.ZeminOlustur();
             
        }
    }
    IEnumerator YokEt(GameObject zemin)
    {
        yield return new WaitForSeconds(0.2f);
        zemin.AddComponent<Rigidbody>();

        yield return new WaitForSeconds(0.8f);
        Destroy(zemin);
    }

}//class
