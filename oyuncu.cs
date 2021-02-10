using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyuncu : MonoBehaviour
{

    public GameObject patlama_efekti;
    public GameObject oyuncu_kursunu;
    public Image oyuncu_can_bari;
    public yonetici yonet;

    float can = 100.0f;
    float simdiki_can = 100.0f;

    float hareket_hizi = 5.0f;
    float kursun_hizi = 500.0f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="dusman_kursunu")
        {
            Destroy(collision.gameObject);
            can_azalt(10.0f);

        }
    }

    void can_azalt(float deger)
    {
        simdiki_can -= deger;
        oyuncu_can_bari.fillAmount = simdiki_can / can;

        if(simdiki_can <= 0)
        {
            yok_ol();
        }
    }

    void yok_ol()
    {
        Destroy(gameObject);
        GameObject yeni_patlama = Instantiate(patlama_efekti, transform.position, Quaternion.identity);
        Destroy(yeni_patlama, 1.0f);
        yonet.paneli_goster();

    }

    void ates_et()
    {
        GameObject yeni_kursun = Instantiate(oyuncu_kursunu, transform.position, Quaternion.identity);
        yeni_kursun.GetComponent<Rigidbody2D>().AddForce(Vector2.up*kursun_hizi);
        
        Destroy(yeni_kursun, 2.0f);
    }
    void Update()
    {
        float tus_tespiti = Input.GetAxis("Horizontal");

        transform.Translate(tus_tespiti * Time.deltaTime *hareket_hizi, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ates_et();
        }

        
    }
}
