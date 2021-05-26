using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Scene içinde kontrol etmemizi çağırmamıza yarar.

public class LoseCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        SceneManager.LoadScene("Game Over");
    }





}
