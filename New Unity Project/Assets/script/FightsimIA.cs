using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightsimIA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fight2());
    }

    IEnumerator Fight2()
    {
        yield return new WaitForSeconds(2);
        int num = Random.Range(0, 2);
        GameManager.instance.isIA = true;
        if (num == 0)
        {
            GameManager.instance.battleWonIA = false;
        }
        else
        {
            GameManager.instance.battleWonIA = true;
        }
        GameManager.instance.battleHasEnded = true;
        
        SceneManager.LoadScene("Demo");
    }
}
