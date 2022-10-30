using System.Collections;
using System.Collections.Generic;using TMPro;
using UnityEngine;




public class StartingEndScene : MonoBehaviour
{
    
    public TMP_Text blue;
    public TMP_Text red;
    public TMP_Text yellow;
    public TMP_Text black;
    public TMP_Text points;
    
    // Start is called before the first frame update
    void Start()
    {
        points.SetText("Puntos totales: " + PlayerController.totalPoints);
        black.SetText("Negros " + PlayerController.blackGroundPoints + " x1 = " + PlayerController.blackGroundPoints);
        blue.SetText("Azules " + PlayerController.blueGroundPoints + " x2 = " + PlayerController.blueGroundPoints * 2);
        red.SetText("Rojos " + PlayerController.redGroundPoints+ " x3 = " + PlayerController.redGroundPoints * 3);
        yellow.SetText("Amarillos " + PlayerController.yellowGroundPoints+ " x4 = " + PlayerController.yellowGroundPoints * 4);

    }

}
