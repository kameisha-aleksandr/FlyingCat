using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice
{
    float[][] _enemyChance = new float[][] {
        new float[] { 0.5f, 0.5f, 0f, 0f, 0f, 0f },
        new float[] { 0.5f, 0.3f, 0.2f, 0f, 0f, 0f },
        new float[] { 0.4f, 0.3f, 0.2f, 0.1f, 0f, 0f },
        new float[] { 0.4f, 0.2f, 0.2f, 0.1f, 0.1f, 0f },
        new float[] { 0.3f, 0.2f, 0.2f, 0.1f, 0.1f, 0.1f },
        new float[] { 0.3f, 0.15f, 0.2f, 0.125f, 0.125f, 0.1f },
        new float[] { 0.25f, 0.15f, 0.2f, 0.15f, 0.15f, 0.1f },
        new float[] { 0.25f, 0.125f, 0.2f, 0.175f, 0.15f, 0.1f },
        new float[] { 0.2f, 0.125f, 0.225f, 0.175f, 0.15f, 0.125f },
        new float[] { 0.2f, 0.1f, 0.225f, 0.2f, 0.15f, 0.125f }};

    int Choose(float[] probs)
    {
        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
                return i;
            else
                randomPoint -= probs[i];
        }
        return probs.Length - 1;
    }

    public int ChosingEnemy(int numFloor)
    {
        int level = numFloor / 10;
        if (level > 9) level = 9;
        var numEnemy=Choose(_enemyChance[level]);
        return numEnemy;
    }
}
