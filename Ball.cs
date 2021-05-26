using UnityEngine;

public class Ball : MonoBehaviour
{


    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;//TOP SESLERINI CAGIRMAK İSTİYORUZ BUNDAN DOLAYI TOPUN SES KLIBI DENILEN BİR DİZİ YAPTIK.
    [SerializeField] float randomFactor = 0.2f;




    //state
    Vector2 paddleToBallVector;//raket ve top arasındaki mesafe veya fark boşluğu.
    bool hasStarted = false;

    //Cached comp. references//ses kaynagını söylerız cunku biz ses kaynagı türünü istiyoruz. başka bir ses klibi bileşenini otomatık hale getirir.

    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    //daha sonra oyuna basladıgımızda ses kaynagımızın ses kaynagına eşit oldugunu söyleyerek o ses kaynagını alacagız ve bu bilmecenin 
    //   myAudioSource = GetComponent<AudioSource>(); bunu kullanırız START'ta.
    //Motora direkt olarak bu bileşeni buldururuz oyun basladıgı anda.

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;//ball ile paddle'ın yapısık olmasını sağlar.Aralarında ki boşluğu alır.
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }



    void Update() //bunları bir arada tutmamız gerek yer update methodu içerisidir.
                  //Topu paddle'a yapıstırır ve ne kadar hızlı sağa sol yapsak da ayrılmazlar.
    {
        if (!hasStarted)
        {
            lockBallToPaddle();//topu pedala kitleyen kodlar.
            LaunchOnMouseClick(); //sağ tıkla-->Hızlı eylemler yeniden düzenlemeler de ve allttaki fonk.gelir.
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush,yPush);
        }
    }

    private void lockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    //SES DOSYASININ NE ZAMAN BİR TETIKLENME OLURSA ÇALMASINI İSTEDİĞİMİZ KODU YAZARIZ.

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 velocityTweak = new Vector2
            (Random.Range(0f,randomFactor),
            Random.Range(0f,randomFactor));


        if (hasStarted)
        {

            /*AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];//SES KLIBI OLAN BİR DEĞİŞKEN OLUSTURDU KYUKARDA VE ballSounds(TOPUN UZERINDE YARATTIGIMIZ DİZİ OLAN 
            //TOP SESLERİNİ SÖYLÜYOR.VE KLİBİN RASTGELE BİR ŞEKİLDE TOP SESLERİNE GİDECEĞİNİ SÖYLÜYORUZ.(0, ballSounds.Length) 0 İLE KAÇ TANE SES DOSAYSI VARSA ONLAR ARASINDA ALACAIGINI BELIRLERIZ.)
            myAudioSource.PlayOneShot(clip);*/

            if (hasStarted)
            {
                AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
                myAudioSource.PlayOneShot(clip);
                myRigidBody2D.velocity += velocityTweak;
            }



            //GetComponent<AudioSource>().Play();//BALL HER BİR TETIKLEYICIGE GİRDİĞİ ANDA BU SES DOAYASI ÇALIŞACAKTIR ÇARPTIGI NERE OLURSA OLSUN ÇALAR.
            //TOPU PADDLE'DAN BİR TIK YUKARIDA TUTMAYALIZ YOKSA DİREKT SEKILDE ÇARPISMA SESİ GELECEKTİR.
            //birden fazla çarpıstırıcıda ses çıkması için en yuakrda [SeializeField] tarafında yazıyoruz.
        }


    }







}
