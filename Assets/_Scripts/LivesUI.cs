using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] Text livesText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + PlayerStats.Lives.ToString();
        //TODO: Change to some better UI. But it's ok for now
    }
}
