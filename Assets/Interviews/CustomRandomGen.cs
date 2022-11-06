using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRandomGen : MonoBehaviour
{
    [SerializeField] float chance1 = 0;
    [SerializeField] float chance2 = 0;
    [SerializeField] float chance3 = 0;
    [SerializeField] float chance4 = 0;

    private void Start()
    {
        print(CustomRandomChance());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print($"Resultado: {CustomRandomChance()}");
        }
    }

    public int CustomRandomChance()
    {
        int result = 0; 
        float randomChance = Random.Range(0f, 100f);

        float rangeForFirstChance = chance1; 
        float rangeForSecondChance = rangeForFirstChance + chance2; 
        float rangeForThirdChance = rangeForSecondChance + chance3; 

        if (randomChance <= rangeForFirstChance)
        {
            result = 0;
        }
        else if (randomChance <= rangeForSecondChance)
        {
            result = 1;
        }
        else if (randomChance <= rangeForThirdChance)
        {
            result = 2;
        }
        else
        {
            result = 3;
        }

        print($"Tirada de random: {randomChance}");
        return result;
    }
}
