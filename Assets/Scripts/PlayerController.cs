using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public int collectibleDegeri;
    public bool xVarMi = true;
    public bool collectibleVarMi = true;

    public bool isFinish = false;

   
    public List<GameObject> shouldDeleteObjects = new List<GameObject>();


    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);
    }

    void Start()
    {
        StartingEvents();
    }

     void Update()
    {
        transform.GetChild(0).transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    /// <summary>
    /// Playerin collider olaylari.. collectible, engel veya finish noktasi icin. Burasi artirilabilir.
    /// elmas icin veya baska herhangi etkilesimler icin tag ekleyerek kontrol dongusune eklenir.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("collectible"))
        {
            // COLLECTIBLE CARPINCA YAPILACAKLAR...
            // Destroy(other.gameObject);
            //GameController.instance.SetScore(collectibleDegeri); // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku
            //GetComponent<SpawnWithDistance>().Spawn(); // Dairesel şekilde Spawn ediyor.Obje sayısı arttıkça kendi içersinde tekrar düzenleme yapıyor

        }
        else if (other.CompareTag("LimonluLolipop"))
        {
            Destroy(other.gameObject);
            GameController.instance.SetScore(collectibleDegeri); // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku
            GetComponent<SpawnWithDistance>().nextLolipops.Add(GetComponent<SpawnWithDistance>().limonluLolipop);
            GetComponent<SpawnWithDistance>().Spawn();
        }
        else if (other.CompareTag("MorLolipop"))
        {
            Destroy(other.gameObject);
            GameController.instance.SetScore(collectibleDegeri); // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku
            GetComponent<SpawnWithDistance>().nextLolipops.Add(GetComponent<SpawnWithDistance>().morLolipop);
            GetComponent<SpawnWithDistance>().Spawn();
        }
        else if (other.CompareTag("SarıLolipop"))
        {
            Destroy(other.gameObject);
            GameController.instance.SetScore(collectibleDegeri); // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku
            GetComponent<SpawnWithDistance>().nextLolipops.Add(GetComponent<SpawnWithDistance>().sariLolipop);
            GetComponent<SpawnWithDistance>().Spawn();
        }
        else if (other.CompareTag("KarpuzluLolipop"))
        {
            Destroy(other.gameObject);
            GameController.instance.SetScore(collectibleDegeri); // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku
            GetComponent<SpawnWithDistance>().nextLolipops.Add(GetComponent<SpawnWithDistance>().karpuzluLolipop);
            GetComponent<SpawnWithDistance>().Spawn();
        }
        else if (other.CompareTag("engel"))
        {
            // ENGELELRE CARPINCA YAPILACAKLAR....

            GameController.instance.SetScore(-collectibleDegeri); // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku

            if (GameController.instance.score < 0) // SKOR SIFIRIN ALTINA DUSTUYSE
            {
                // FAİL EVENTLERİ BURAYA YAZILACAK..
                //burayı aç GameController.instance.isContinue = false; // çarptığı anda oyuncunun yerinde durması ilerlememesi için
                // burayı aç UIController.instance.ActivateLooseScreen(); // Bu fonksiyon direk çağrılada bilir veya herhangi bir effect veya animasyon bitiminde de çağrılabilir..
                // oyuncu fail durumunda bu fonksiyon çağrılacak.. 
            }


        }
        else if (other.CompareTag("finish"))
        {
            // finishe collider eklenecek levellerde...
            // FINISH NOKTASINA GELINCE YAPILACAKLAR... Totalscore artırma, x işlemleri, efektler v.s. v.s.
            GameController.instance.isContinue = false;
            GameController.instance.ScoreCarp(7);  // Bu fonksiyon normalde x ler hesaplandıktan sonra çağrılacak. Parametre olarak x i alıyor. 
            // x değerine göre oyuncunun total scoreunu hesaplıyor.. x li olmayan oyunlarda parametre olarak 1 gönderilecek.
            UIController.instance.ActivateWinScreen();
            // UIController.instance.ActivateLooseScreen();  // finish noktasına gelebildiyse her türlü win screen aktif edilecek.. ama burada değil..
                                                            // normal de bu kodu x ler hesaplandıktan sonra çağıracağız. Ve bu kod çağrıldığında da kazanılan puanlar animasyonlu şekilde artacak..


        }

        else if (other.CompareTag("finishTrigger"))
        {
            isFinish = true;
            transform.position = new Vector3(0,  transform.position.y,transform.position.z);
            StartCoroutine(turnHulahop());

            GetComponent<SwerveMovement>().enabled = false;
            GetComponent<SwerveInputSystem>().enabled = false;
            for (int i = 0; i < shouldDeleteObjects.Count; i++)
            {
                Destroy(shouldDeleteObjects[i]);
            }


        }

    }


    /// <summary>
    /// Bu fonksiyon her level baslarken cagrilir. 
    /// </summary>
    public void StartingEvents()
    {
        transform.parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.parent.transform.position = Vector3.zero;
        GameController.instance.isContinue = false;
        GameController.instance.score = 0;
        transform.position = new Vector3(0, transform.position.y, 0);
        GetComponent<Collider>().enabled = true;
        GetComponent<SpawnWithDistance>().DestroyLolipops();
        GetComponent<SpawnWithDistance>().objectNumber = 1;
        isFinish = false;
        transform.DORotate(new Vector3(0, 0, 0),  1);
        GameObject.Find("KarakterPaketi").GetComponent<KarakterPaketiMovement>().enabled = true;
        GetComponent<SwerveMovement>().enabled = true;
        GetComponent<SwerveInputSystem>().enabled = true;
        transform.localScale = new Vector3(1, 1, 1);
        shouldDeleteObjects.Clear();
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 1, 0);
        GetComponent<SpawnWithDistance>().objectNumber = 1;
        GetComponent<SpawnWithDistance>().rad =2f;   
    }

    IEnumerator turnHulahop()
    {
        yield return new WaitForSeconds(1);
        transform.DORotate(new Vector3(0, 0, 90), 7 * Time.deltaTime);
        transform.DOMoveY(4, 7 * Time.deltaTime);
    }

    public void FinishScreen()
    {
      
            // finishe collider eklenecek levellerde...
            // FINISH NOKTASINA GELINCE YAPILACAKLAR... Totalscore artırma, x işlemleri, efektler v.s. v.s.
            GameController.instance.isContinue = false;
            GameController.instance.ScoreCarp(2);  // Bu fonksiyon normalde x ler hesaplandıktan sonra çağrılacak. Parametre olarak x i alıyor. 
            // x değerine göre oyuncunun total scoreunu hesaplıyor.. x li olmayan oyunlarda parametre olarak 1 gönderilecek.
            UIController.instance.ActivateWinScreen();
        // UIController.instance.ActivateLooseScreen();  // finish noktasına gelebildiyse her türlü win screen aktif edilecek.. ama burada değil..
        // normal de bu kodu x ler hesaplandıktan sonra çağıracağız. Ve bu kod çağrıldığında da kazanılan puanlar animasyonlu şekilde artacak..

       

    }

}
