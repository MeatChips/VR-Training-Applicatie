using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HMIP : MonoBehaviour
{
    public Slider peopleSlider;

    public bool isTrue;

    public List<GameObject> peopleList = new List<GameObject>();

    public int amountPeople1 = 4;
    public int amountPeople2 = 7;
    public int amountPeople3 = 2;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject Obj in GameObject.FindGameObjectsWithTag("People"))
        {
            peopleList.Add(Obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (peopleSlider.value == 1)
        {
            SetActiveTrue();
            if (isTrue)
            {
                for (int i = 0; i < amountPeople1; i++)
                {
                    peopleList[i].SetActive(true);
                }
            }
        }

        if (peopleSlider.value == 2)
        {
            SetActiveTrue();
            if (isTrue)
            {
                for (int i = 0; i < amountPeople2; i++)
                {
                    peopleList[i].SetActive(true);
                }
            }
        }

        if (peopleSlider.value == 3)
        {
            SetActiveTrue();
            if (isTrue)
            {
                for (int i = 0; i < amountPeople3; i++)
                {
                    peopleList[i].SetActive(true);
                }
            }
        }
    }

    public void SetActiveTrue()
    {
        for (int i = 0; i < 7; i++)
        {
            peopleList[i].SetActive(false);
        }

        isTrue = true;
    }
}