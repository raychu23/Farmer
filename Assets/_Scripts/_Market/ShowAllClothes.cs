using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAllClothes : MonoBehaviour
{
    public GameObject allclothes;
    public GameObject halfdoor;
    public GameObject hair;
    public GameObject shirts;
    public GameObject pants;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        allclothes.SetActive(false);
        halfdoor.SetActive(true);
        hair.SetActive(false);
        shirts.SetActive(false);
        pants.SetActive(false);
		count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count % 2 == 1)
        {

        if (Sale.currentclick == "hair")
        {
            hair.SetActive(true);
            shirts.SetActive(false);
            pants.SetActive(false);
                halfdoor.SetActive(false);
                allclothes.SetActive(true);

        }
        else if (Sale.currentclick == "shirt")
        {
            hair.SetActive(false);
            shirts.SetActive(true);
            pants.SetActive(false);
                halfdoor.SetActive(false);
                allclothes.SetActive(true);
            }
        else if (Sale.currentclick == "pants")
        {
            hair.SetActive(false);
            shirts.SetActive(false);
            pants.SetActive(true);
                halfdoor.SetActive(false);
                allclothes.SetActive(true);
            }

        }
        else
        {
            hair.SetActive(false);
            shirts.SetActive(false);
            pants.SetActive(false);
            halfdoor.SetActive(true);
            allclothes.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        count++;
    }
}
