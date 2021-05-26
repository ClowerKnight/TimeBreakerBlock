using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    //[SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;//damage aldıkça değişecek olan spriteler

    //[SerializeField] Level level;//bloklarımızın her birine tıkladıgımızda artık inspector panelinde script'in altında Level ol.gelir.

    //cached reference : ÖN BELLEGE ALINMIS OLAN REFERANS YUKARIDAKINI YAPMAKTANSA BUNU YAPARIZ.
    Level level;

    //state variables

    [SerializeField] int timesHit;//sadece hata ayıklama amacıyla saerişleştirdik.



    private void Start()//KIRILABILIR OLANLARI SÖYLÜYORUZ BRADA.
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();//Bunları yaptıgımız zaman oyun start verildğği zaman kaç adet block oldugunu kendısi yazdırır.

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//çarpısma gerçeklestiginde bu metodu çarpısmaya cagırır.
                                                          //çarpışma anını bize çarpısmanın ne oldugunu söyler.
    {
        /*Destroy(gameObject);//2 deger alır obj,float=t t:nesneyi yok etmeden çnce geciktirmek için isteğe bağlı süredir.
        //gameObject burdakı gameObject bir oyunun nesnesi oldugunu ve ben kastettiğimde sadece bu komutun üzerinde durdugunu söyleriz.

       // Debug.Log(collision.gameObject.name);//HANGİ OBJEYLE ETKİLEŞİME GİRDİĞİNİ CONSOLE'A YAZDIRIR.*/

        if (tag=="Breakable")
        {
            HandleHit();

        }
        else
        {
            ShowNextHitSprite();//spritelar aras geçiş
        }




    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;//eğer top bir kez bloga çarparsa o zmana vuruş 1 olur. diziler 0 dan baladıgı ıcın 0 yazmayız çünkü 1 kere vrus olacak 0 dan 1 olacaktır.
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];//0 oldugu zaman dizide ki ilk seviyeyi gösterir.

        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);//hatanın hangisinden kaynaklı oldugunu ve ismini verir kontrolumuzu kolaylaştırır.
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();//block imha edildiği zaman yok et ve addtoscore olan bu yöntemi çalıştır.
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void   TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }



}
