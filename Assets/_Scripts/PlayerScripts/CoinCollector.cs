using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
 
    public float respawnTime = 5f;  

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.coinCount++;
            GameManager.instance.UpdateCoinUI();

            this.gameObject.SetActive(false);

        }
    }



    IEnumerator RespawnCoin(GameObject coin)
    {
        yield return new WaitForSeconds(respawnTime);
        coin.SetActive(true);
    }
}
