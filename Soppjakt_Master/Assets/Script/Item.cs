using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;

    [HideInInspector]
    public bool equipped;

    [HideInInspector]
    public GameObject weapon;
    public GameObject steinsopp;
    public GameObject sopp;

    [HideInInspector]
    public GameObject weaponManager;
    public GameObject steinSopp;
    public GameObject skrubbSopp;

    public bool playersWeapon;
    public bool playersSteinsopp;
    public bool playersSkrubbsopp;


    public void Start()
    {
        weaponManager = GameObject.FindWithTag("weaponManager");

        if (!playersWeapon)
        {
            int allWeapons = weaponManager.transform.childCount;
            for (int i = 0; i < allWeapons; i++)
            {
                if(weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
        steinSopp = GameObject.FindWithTag("steinSopp");

        if (!playersSteinsopp)
        {
            int allSopp = steinSopp.transform.childCount;
            for (int i = 0; i < allSopp; i++)
            {
                if (steinSopp.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    steinsopp = steinSopp.transform.GetChild(i).gameObject;
                }
            }
        }
        skrubbSopp = GameObject.FindWithTag("skrubbSopp");

        if (!playersSkrubbsopp)
        {
            int allSopp = skrubbSopp.transform.childCount;
            for (int i = 0; i < allSopp; i++)
            {
                if (skrubbSopp.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    skrubbSopp = skrubbSopp.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    public void Update()
    {
        if(equipped)
        {
            //perform eapon acts here

            if (Input.GetKeyDown(KeyCode.G))
                equipped = false;

            if (equipped == false)
                this.gameObject.SetActive(false);
        }
    }

    public void ItemUsage()
    {
        //Weapon

        if(type == "Weapon")
        {
            weapon.SetActive(true);
            weapon.GetComponent<Item>().equipped = true;
        }

        if( type == "Steinsopp")
        {
            steinsopp.SetActive(true);
            steinsopp.GetComponent<Item>().equipped = true;
        }
        //Health item
    }
}
