using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiviateReturnButton : MonoBehaviour
{
    public GameObject returnButton;

    //Set the return to main button to active
    public void SetButtonActive()
    {
        returnButton.SetActive(true);
    }
}
