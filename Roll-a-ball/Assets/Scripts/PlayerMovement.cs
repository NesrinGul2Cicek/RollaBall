using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed= 15f;
    public Rigidbody rb;
    float yatay,dikey;
    int skor =0;
    public Text skorTxt;
    public Text uyariText;
    public Text tebrikText;
    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move2();
    }

    private void FixedUpdate()
    {
       
       
    }
    //collision and collider(trigger)
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            // !! Nesnenin isTrigger özelliði açýk olmalý
            // Destroy(other.gameObject); // Nesneyi yok etme komutu
            other.gameObject.SetActive(false); // Nesneyi gizleme komutu
            skor += 1;
            Debug.Log(skor);
        }

    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            // !! Çalýþmasý için nesnenin isTrigger özelliði kapalý olmalý
            // Destroy(other.gameObject); // Nesneyi yok etme komutu
            collision.gameObject.SetActive(false); // Nesneyi gizleme komutu
            skor += 1;
            Debug.Log(skor);
            skorTxt.text = "SKOR : "+skor.ToString();
        }
        else if (collision.gameObject.CompareTag("special diamond") && skor == 8)
        {
            collision.gameObject.SetActive(false); // Nesneyi gizleme komutu
            skor += 2;
            skorTxt.text = "SKOR : " + skor.ToString();
            // Tebrik Mesajý (Level up ve sonraki seviyeye geçiþ) (3 sn ekranda yazacak)
            tebrikText.text = "TEBRÝKLER ! SEVÝYEYÝ GEÇTÝNÝZ !!!";
            StartCoroutine(TebrikBeklet());
        }
        else
        {
            // Uyarý Mesajý (3 sn ekranda yazacak)
            uyariText.text = "BU ELMAS EN SON YENMELÝDÝR !!";
            StartCoroutine(UyariBeklet());    
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal")*speed*Time.deltaTime;

        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0, moveZ));

    }

    private void Move2()
    {
        yatay = Input.GetAxis("Horizontal");
        dikey = Input.GetAxis("Vertical");

        Vector3 kuvvet = new Vector3(yatay,0f,dikey);

        rb.AddForce(kuvvet*speed);
    }
    //ýnterface türünde fonsiyon tanýmladýk.C++ ta olan çoklu kalýtýmýn muadili 
    //yield:
    IEnumerator UyariBeklet()
    {
        yield return new WaitForSeconds(3f);
        uyariText.text = "";
    }
    IEnumerator TebrikBeklet()
    {
        yield return new WaitForSeconds(2f);
        // Sonraki sahneye geçiþ (File -> Build Settings)
        SceneManager.LoadScene(1); 
        // 1 = Build Settings de indexi belirlenmiþ sahne indexi
        // "New Scene" = Build Settings deki bulunan indexi 1 olan sahne
    }
}
