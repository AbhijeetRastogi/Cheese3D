using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class SetupBoard : MonoBehaviour
{
    [SerializeField] private GameObject[] box;
        
    
    private ChessPiece[] piece;
    private Vector2[] piecePosition;
    private int numOfpiece = 8 * 4;
    
    private void Start()
    {
        playerGeneration();
    }

    private void playerGeneration()
    {
        piecePosition = new Vector2[numOfpiece];
    

    //position
        // WK, BK, WQ, BQ, WB, BB, WN, BN, WR, BR, WP1, BP1, WP2......
        // [11,22, ]
        piece = new ChessPiece[numOfpiece];

        // black and white 
        for (int i = 0; i < numOfpiece; i++)
        {
            piece[i] = new ChessPiece();
            piece[i].color = (i % 2 == 0) ? Color.White : Color.Black;
        }
        
        // type
        for (int i = 0; i < numOfpiece; i++)
        {
            if(i<2)
                piece[i].type = Type.King;
            if(i<4)
                piece[i].type = Type.Queen;
            if(i<8)
                piece[i].type = Type.Knight;
            if(i<12)
                piece[i].type = Type.Bishop;
            if(i<18)
                piece[i].type = Type.Rook;
            else
                piece[i].type = Type.Pawn;
        }
        
        //instantiate
        for (int i = 0; i < numOfpiece; i++)
        {
            GameObject gm = Instantiate(box[0], new Vector3(0,0,0), Quaternion.identity);
            gm.transform.parent = gameObject.transform;
        }
    }
}
