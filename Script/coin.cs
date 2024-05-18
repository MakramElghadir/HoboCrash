using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coin : MonoBehaviour
{
    public int moneiy = 0;
    public TMP_Text CoinText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            moneiy++;
            Debug.Log(moneiy);
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        CoinText.text = moneiy.ToString();
    }
}
