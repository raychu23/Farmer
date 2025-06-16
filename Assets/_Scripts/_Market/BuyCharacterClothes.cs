using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCharacterClothes : MonoBehaviour
{
	public GameObject errortext;

    public GameObject hair;
    public GameObject hair2;
    public GameObject hair3;
    public GameObject shirt;
    public GameObject shirt2;
    public GameObject shirt3;
    public GameObject pants;
    public GameObject pants2;
    public GameObject pants3;
    public Sound sound;

	public static bool buyhair = false;
	public static bool buyhair2 = false;
    public static bool buyhair3 = false;
    public static bool buyshirt = false;
    public static bool buyshirt2 = false;
    public static bool buyshirt3 = false;
    public static bool buypants = false;
    public static bool buypants2 = false;
    public static bool buypants3 = false;
    // Start is called before the first frame update
    void Start()
    {
		errortext.SetActive(false);
	}


    void OnMouseDown()
	{
        if (Sale.currentclick == "hair1")
		{
            if (Global.gold < 950)
            {
                sound.PlayButtonSound();
                errortext.SetActive(true);
			}
			else
            {
                sound.PlayCoinSound();

                Global.gold -= 950;
				Global.hair = 1;
				buyhair = true;
                hair.SetActive(false);
			}
		}

        if (Sale.currentclick == "hair2")
		{
            if (Global.gold < 950)
			{
                sound.PlayButtonSound();

                errortext.SetActive(true);
			}
			else
			{
                sound.PlayCoinSound();

                Global.gold -= 950;
				Global.hair = 2;
				buyhair2 = true;
                hair2.SetActive(false);
			}
		}
        if (Sale.currentclick == "hair3")
        {
            if (Global.gold < 950)
            {
                sound.PlayButtonSound();

                errortext.SetActive(true);
            }
            else
            {
                sound.PlayCoinSound();

                Global.gold -= 950;
                Global.hair = 3;
                buyhair3 = true;
                hair3.SetActive(false);
            }
        }

        if (Sale.currentclick == "shirt1")
		{
            if (Global.gold < 2000)
			{
                sound.PlayButtonSound();

                errortext.SetActive(true);
			}
			else
			{
                sound.PlayCoinSound();

                Global.gold -= 2000;
				Global.shirt = 2;
				buyshirt = true;
                shirt.SetActive(false);
			}
		}
        if(Sale.currentclick == "shirt2")

        {
            if (Global.gold < 2000)
            {
                sound.PlayButtonSound();

                errortext.SetActive(true);
            }
            else
            {
                sound.PlayCoinSound();

                Global.gold -= 2000;
                Global.shirt = 3;
                buyshirt2 = true;
                shirt2.SetActive(false);
            }
        }
        if(Sale.currentclick == "shirt3")

        {
            if (Global.gold < 2000)
            {
                sound.PlayButtonSound();

                errortext.SetActive(true);
            }
            else
            {
                sound.PlayCoinSound();

                Global.gold -= 2000;
                Global.shirt = 4;
                buyshirt3 = true;
                shirt3.SetActive(false);
            }
        }

        if (Sale.currentclick == "pants1")
		{
			if (Global.gold < 2000)
			{
                sound.PlayButtonSound();

                errortext.SetActive(true);
			}
			else
			{
                sound.PlayCoinSound();

                Global.gold -= 2000;
				Global.pants = 2;
				buypants = true;
                pants.SetActive(false);
			}
		}
        if (Sale.currentclick == "pants2")
        {
            if (Global.gold < 2000)
            {
                sound.PlayButtonSound();

                errortext.SetActive(true);
            }
            else
            {
                sound.PlayCoinSound();

                Global.gold -= 2000;
                Global.pants = 3;
                buypants2 = true;
                pants2.SetActive(false);
            }
        }
        if (Sale.currentclick == "pants3")
        {
            if (Global.gold < 2000)
            {
                sound.PlayButtonSound();

                errortext.SetActive(true);
            }
            else
            {
                sound.PlayCoinSound();

                Global.gold -= 2000;
                Global.pants = 4;
                buypants3 = true;
                pants3.SetActive(false);
            }
        }
    }
}
