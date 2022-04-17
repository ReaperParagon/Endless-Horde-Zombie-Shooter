using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieModelPicker : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> modelList = new List<GameObject>();

    private void OnEnable()
    {
        for (int i = 0; i < modelList.Count; i++)
        {
            modelList[i].SetActive(false);
        }

        int index = Random.Range(0, modelList.Count);

        modelList[index].SetActive(true);
    }

}
