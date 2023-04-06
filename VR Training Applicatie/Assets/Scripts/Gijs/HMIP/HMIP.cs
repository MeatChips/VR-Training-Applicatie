using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HMIP : MonoBehaviour
{
    public Slider peopleSlider;

    public GameObject go;

    public bool isSpawned;

    public List<GameObject> ListOfSpawnpoints = new List<GameObject>();


    public bool optionOne;
    public bool optionTwo;
    public bool optionThree;

    public bool destroyPeople;
    public bool spawnPeople;

    // Start is called before the first frame update
    void Start()
    {
        optionOne = false;
        optionTwo = false;
        optionThree = false;

        foreach (GameObject Obj in GameObject.FindGameObjectsWithTag("PeopleSpawnPoint"))
        {
            ListOfSpawnpoints.Add(Obj);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (peopleSlider.value == 1)
        {
            optionOne = true;
            if (optionOne)
            {
                SpawnPeople(3);
            }
        }

        //if (peopleSlider.value == 0)
        //{
        //    DestroyPeople();
        //    optionOne = false;
        //    optionTwo = false;
        //    optionThree = false;
        //}
        //
        //if(peopleSlider.value == 1)
        //{
        //    DestroyPeople();
        //    optionOne = true;
        //    if (optionOne)
        //    {
        //        SpawnPeople(1);
        //        optionTwo = false;
        //        optionThree = false;
        //    }
        //}
        //
        //if (peopleSlider.value == 2)
        //{
        //    DestroyPeople();
        //    optionTwo = true;
        //    if (optionTwo)
        //    {
        //        SpawnPeople(2);
        //        optionOne = false;
        //        optionThree = false;
        //    }
        //}
        //
        //if (peopleSlider.value == 3)
        //{
        //    DestroyPeople();
        //    optionThree = true;
        //    if (optionThree)
        //    {
        //        SpawnPeople(3);
        //        optionOne = false;
        //        optionTwo = false;
        //    }
        //}
    }

    public void DestroyPeople()
    {
        Destroy(GameObject.FindWithTag("People"));
        isSpawned = false;
    }

    public void SpawnPeople(int spawnIndex)
    {
        if (!isSpawned)
        {
            Instantiate(/*Resources.Load<GameObject>("Person")*/go, ListOfSpawnpoints[spawnIndex].transform.position, go.transform.rotation);
            isSpawned = true;
        }
    }

    public void SliderTest()
    {
        //Displays the value of the slider in the console.
        Debug.Log(peopleSlider.value);
    }
}
