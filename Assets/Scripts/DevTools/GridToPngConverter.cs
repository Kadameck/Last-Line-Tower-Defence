using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TGS;
using System.Linq;
using System.IO;

public class GridToPngConverter : MonoBehaviour
{
    public TerrainGridSystem tgs;

    public bool createNewPng = false;

    private Texture2D pngData;

    private void FixedUpdate()
    {
        if(createNewPng)
        {
            InitPngData();
            DrawWalkableCellsToPixel();
            SaveAsPng();

            createNewPng = false;
        }
    }

    private void InitPngData()
    {
        pngData = new Texture2D(tgs.rowCount, tgs.columnCount);

        for (int y = 0; y < tgs.columnCount; y++)
        {
            for (int x = 0; x < tgs.rowCount; x++)
            {
                pngData.SetPixel(x, y, Color.white);
            }
        }

        pngData.Apply();
    }

    

    private void DrawWalkableCellsToPixel()
    {
        List<Cell> visibleCells = 
            tgs.cells
            .Where(cell => cell.canCross)
            .ToList();

        for (int cellIndex = 0; cellIndex < visibleCells.Count(); cellIndex++)
        {
            Cell cell = visibleCells[cellIndex];
            int xValue = cell.column;
            int yValue = cell.row;

            pngData.SetPixel(xValue, yValue, Color.black);
        }

        pngData.Apply();
    }

    private void SaveAsPng()
    {
        byte[] pngByteArray = pngData.EncodeToPNG();
        Debug.Log(Application.dataPath);
        File.WriteAllBytes(Application.dataPath + "/GeneratedPNGs/WalkableAndVisibleCells.png", pngByteArray); 
    }

}
