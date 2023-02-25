using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    private int Strawberry = 0;

    [SerializeField] private Text StrawberriesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            Strawberry++;
            Destroy(collision.gameObject);
            //Debug.Log("Strawberry: "+Strawberry);

            StrawberriesText.text = $"Strawberries: {Strawberry}";
            //^^ham issay update krry hain  = ^^usay data le kr
        }
    }


}
