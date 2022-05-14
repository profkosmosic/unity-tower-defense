using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]Tower balista;
    [SerializeField]bool isPlacable;

    public bool IsPlacable {
        get {
            return isPlacable;
        }
    }

    void OnMouseDown() {
        if(isPlacable) {
            bool isPlaced = balista.CreateTower(balista, transform.position);
            isPlacable = !isPlaced;
        }
    }
}
