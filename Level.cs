using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Block.cs altına da bir level serialized'i açtık.Diğerlerine de erişmek için.


    //parameters
    [SerializeField] int breakableBloks; //serialized for debugging purposes(hata ayıklama amaçları için seri hale getirildi.)
    //Kaç tane blogumuzun kalduıgunu buraya belırtip bittiğinde won yazısını cıkarmak için.
    //Level'in inspectoruynde scpitinde BreakableBlock ol. gelir.

    //cache reference. ön bellekten alıyoruz.
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();//sceneloader'ımıza erişmemize saglıyor.
    }

    public void CountBlocks()//bu blok her çapırıldıgında daha kırılabilir bir blok eklemek istiyoruz kırılabilir blokların toplam sayısına eşitlemek için.
    {
        breakableBloks++;

    }

    public void BlockDestroyed()//block azaltma. Yani burda 0'a ulasan block sayısı var mı onu yazıyoruz.
    {
        breakableBloks--;
        if (breakableBloks <=0)//0'a eşit oldugu zaman diğer seviyeyi yüklemek istiyoruz.SceneLoader.cs'den yaparız.
        {
            sceneloader.LoadNextScene();
        }

    }



}
