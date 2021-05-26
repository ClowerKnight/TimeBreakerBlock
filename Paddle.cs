using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameters
    [SerializeField] float minX = 5.88f;//ekranın solunda olan değer(çerçevenin.)en solda olunca ki X değeri
    [SerializeField] float maxX= 10.16f;//ekranın sağında olan değer(çerçevenin.)en sağda olunca ki X değeri.



    [SerializeField] float screenWidthInUnits = 9f;
    void Update()
    {

        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);//farreyi x,y eks. etrafınca takip eder.
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX); //en düşük ve en yüksek değerleri söylerek bir sabitleme yaparız ektan içinde ondan dışarıya çıkış olmaz.
        transform.position = paddlePos;



        
    }
}
