using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{


    
    [Header("Out Componen")]
    [SerializeField] float speed;
    [SerializeField] Text scoreText,bestScoreText, SbestScoreText;//
    [SerializeField] GameObject restartPanel,playGamePanel,messagePanel;
    [SerializeField] Animator Panim;
    [Header("Public Variable")]
    public GroundSpawner groundSpawner;
    public static bool isDeath = true;
   public float hizlanmaZorlugu=0.1f;

    
    Vector3 yon = Vector3.left;
    float score =0f;
    float artisMiktari=1f;
    int bestScore = 0;

    bool isOkay=false;

    private void Start()
    {
        //if (score > 3)
        //{
          //  hizlanmaZorlugu += 0.5f;
       // }
        if (RestarGame.isRestart)
        {
            isDeath = false;
            playGamePanel.SetActive(false);
        }
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best Score : " + bestScore.ToString();
        SbestScoreText.text = "Best Score : " + bestScore.ToString();
    }
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
            if (bestScore < score)
            {
                bestScore = (int)score;
                PlayerPrefs.SetInt("BestScore", bestScore);
                
            }
            restartPanel.SetActive(true);
            Destroy(this.gameObject, 3f);
        }
    }
    private void FixedUpdate()
    {
        
        if (isDeath)
        {
            return;
        }

        Vector3 hareket = yon * speed * Time.deltaTime;//objemizin hareket değeri
        speed += Time.deltaTime * hizlanmaZorlugu;
        transform.position += hareket;//hareket değerini sürekli pozisyona ekle
                                      // score += artisMiktari * speed * Time.deltaTime;
        
        if (score > bestScore)
        {
            messagePanel.SetActive(true);
            isOkay = true;
        }
        Panim.SetBool("isOkay",isOkay);
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
    public void PLayGame()
    {
        isDeath = false;
        playGamePanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            Destroy(other.gameObject);
        }
    }
}//class
