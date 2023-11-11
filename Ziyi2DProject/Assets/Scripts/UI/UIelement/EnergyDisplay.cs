using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : UIelement
{

    public GameObject livesDisplayImage = null;

    public GameObject numberDisplay = null;

    public int maximumNumberToDisplay = 3;

    public PlayerController playerController;


    //public override void UpdateUI()
    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.player != null)
        {
            Health playerHealth = GameManager.instance.player.GetComponent<Health>();
            if (playerHealth != null)
            {
                SetChildImageNumber(playerController.currentEnergy);
            }
        }
    }


    private void SetChildImageNumber(int number)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        if (livesDisplayImage != null)
        {
            if (maximumNumberToDisplay >= number)
            {
                for (int i = 0; i < number; i++)
                {
                    Instantiate(livesDisplayImage, transform);
                }
            }
            else
            {
                Instantiate(livesDisplayImage, transform);
                GameObject createdNumberDisp = Instantiate(numberDisplay, transform);
                createdNumberDisp.GetComponent<Text>().text = number.ToString();
            }
        }
    }
}
