using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{

    public Text txtScore;
    public Text txtRespawn;
    public Image healthBar;
    public int score = 0;

    public void SetHealthPercent ( float percent )
    {
        healthBar.fillAmount = percent;
    }

    public void showRespawn()
    {
        txtRespawn.gameObject.SetActive(true);
    }

    public void hideRespawn()
    {
        txtRespawn.gameObject.SetActive(false);
    }
 
    public void addPoint()
    {
        score = score + 1;
        txtScore.text = "Score:" + score.ToString();
    }
}
