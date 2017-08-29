using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPoint : MonoBehaviour {

    public Sprite YellowPoint;
    public Sprite RedPoint;
    public Image Point;

	void Update () {
        if (GetComponent<ShipControl>().Life_points > 1 && GetComponent<ShipControl>().Life_points <= 7)
            Point.sprite = YellowPoint;
        else
            Point.sprite = RedPoint;
    }
}
