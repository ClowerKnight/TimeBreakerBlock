using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 5.88f;
    [SerializeField] float maxX= 10.16f;



    [SerializeField] float screenWidthInUnits = 9f;
    void Update()
    {

        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX); 
        transform.position = paddlePos;



        
    }
}
