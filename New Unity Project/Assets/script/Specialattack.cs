using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Specialattack : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Fight3());
    }

    IEnumerator Fight3()
    {
        yield return new WaitForSeconds(2);
        int num = Random.Range(0, 3);
        GameManager.instance.isIA = true;
        if (num == 0 || num == 1)
        {
            GameManager.instance.battleWonspecial = true;
        }
        else
        {
            GameManager.instance.battleWonspecial = false;
        }
        GameManager.instance.battleHasEnded = true;

        SceneManager.LoadScene("Demo");
    }
}
