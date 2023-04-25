using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class HMIP : MonoBehaviour
{
    public TMP_Dropdown peopleDropdown;

    [Header("Booleans")]
    [SerializeField] private bool isTrue;

    [SerializeField] private List<GameObject> peopleList = new List<GameObject>();

    [Header("People Amount")]
    [SerializeField] private int amountPeople1 = 0;
    [SerializeField] private int amountPeople2 = 3;
    [SerializeField] private int amountPeople3 = 5;
    [SerializeField] private int amountPeople4 = 7;

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
        Dropdown();

    }

    public void Dropdown()
    {
        if (peopleDropdown.value == 0)
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

        if (peopleDropdown.value == 1)
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

        if (peopleDropdown.value == 2)
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

        if (peopleDropdown.value == 3)
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