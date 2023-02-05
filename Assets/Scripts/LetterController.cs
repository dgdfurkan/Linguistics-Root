using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (InventorySystem.Instance.ownLetterNames.Contains(gameObject.name)) return;
            InventorySystem.Instance.ownLetterNames.Add(gameObject.name);
            InventorySystem.Instance.ownLetterNamesTemp.Add(gameObject.name);
            InventorySystem.Instance.UpdateLetters();
            Destroy(gameObject);
        }
    }
}
