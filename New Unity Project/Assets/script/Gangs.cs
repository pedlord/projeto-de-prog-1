using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gangs : MonoBehaviour
{
    public List<GameObject> countryganList = new List<GameObject>();
    public List<GameObject> countrygangoList = new List<GameObject>();
    //public Country country;

    public static Gangs instance;
    

    void Awake()
    {
        instance = this;
    }
    void Start()
        {
            StartCoroutine(Algo());
        }
    
    IEnumerator Algo() 
        {
            yield return new WaitForSeconds(5);
            Listapaises();
    }
    void Listapaises()
    {
        GameObject[] Array = GameObject.FindGameObjectsWithTag("country") as GameObject[];
        foreach (GameObject county in Array)
        {
            countryganList.Add(county);
            countrygangoList.Add(county);
        }
        Algumacoisa();
        Countprovince();
    }
    void Countprovince()
    {
        print(countrygangoList);
        int count = 0;
        int counnt = 0;
        for (int i = 0; i < countrygangoList.Count; i++)
        {
            print("contando");
            CountryHandler coutHandler = countrygangoList[i].GetComponent<CountryHandler>();
            if (coutHandler.country.tribe == Country.theTribes.PLAYER)
            {
                print(coutHandler.country);
                count += 1;
            }
            if (coutHandler.country.tribe == Country.theTribes.GANGS) 
            {
                counnt += 1;
            }
        }
        print("contado");
        if (count != 0) 
        {
            print("eu tenho " + count + " provincias");
        }
        if (counnt != 0)
        {
            print("gangs tem " + counnt + " provincias");
        }
        if (counnt == 9)
        {
            SceneManager.LoadScene("Vencer");
        }
        if (counnt == 9)
        {
            SceneManager.LoadScene("Perder");
        }
        
    }
    void Algumacoisa() 
    {
        for (int i = 0; i < countryganList.Count; i++)
        {
            print("ia chegou aqui");
            CountryHandler countHandler = countryganList[i].GetComponent<CountryHandler>();
            if (countHandler.country.tribe == Country.theTribes.PLAYER)
            {
                GameManager.instance.attackedCountrybyIA = countHandler.country.name;
                
                print(countHandler.country.name);
                print(GameManager.instance.attackedCountrybyIA);


                SceneManager.LoadScene("FightIA");
                print("atacou");
                //BattleSystem.instance.state = BattleState.PLAYERTURN;
            }
            else
                //BattleSystem.instance.state = BattleState.PLAYERTURN;
                print("não atacou");
        }
        //print("IA desativada");
    }
    


}
