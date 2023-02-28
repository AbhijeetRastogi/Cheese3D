using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BoardGeneration : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private Material white;
    [SerializeField] private Material black;


    private int boardSize = 8;
    private int blockSize = 10;
    private Vector3 blockScale;
    
    void Start()
    {
        blockScale = new Vector3(blockSize, 1, blockSize);
        generateBoard();
    }

    public string GetBoardPosition(int row, int col)
    {
        return $"{col}{(char)(row+96)}";
    }

    private void instantiateBlock(GameObject gm, int row, int col)
    {
        gm.transform.parent = gameObject.transform;
        gm.transform.localScale = blockScale;
        gm.name = GetBoardPosition(row,col);
 
        gm.GetComponent<Renderer>().material =  ((row + col) % 2 != 0) ? white : black;
     
    }
    private void generateBoard()
    {
        float offset = (boardSize + 1) * blockSize / 2 ;
        for (int col = 1; col <= boardSize; col++)
        {
            for (int row = 1; row <= boardSize; row++)
            {
                Vector3 position = new Vector3(blockSize * col - offset,-0.5f ,blockSize * row - offset);
                instantiateBlock(Instantiate(block, position, Quaternion.identity), row, col);
                

            }
        }
    }
    
}
