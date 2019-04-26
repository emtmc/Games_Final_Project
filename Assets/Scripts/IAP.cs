using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PurchaseComplete(UnityEngine.Purchasing.Product product)
    {
        Debug.Log("Purchase Complete");
        UIScript.Instance.UnlockGameOver();
        UIScript.Instance.UnlockFullScore();
    }

    public void PurchaseFailed(UnityEngine.Purchasing.Product product,
        UnityEngine.Purchasing.PurchaseFailureReason failure)
    {
        Debug.Log("Purchase Failed");
    }
}
