using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private Transform blockPosition;

    [SerializeField] private Text scoreText;
    
    private int score = 0;  

    string blockText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(block, blockPosition);
        StartCoroutine(GenerateBlock(obj));
    }

    private void Update()
    {
        string pressedKey = Input.inputString.ToUpper();

        Debug.Log(pressedKey);
        if(blockText == pressedKey )
        {
            score = score + 1;
            scoreText.text = (score).ToString();
        }
    }

    // Update is called once per frame
    IEnumerator GenerateBlock(GameObject obj)
    {
        while (true)
        {
            blockText = ((char)UnityEngine.Random.Range(65, 90)).ToString();
            obj.transform.GetChild(0).GetComponent<Text>().text = blockText;
            yield return new WaitForSeconds(2f);
        }
    }



}
