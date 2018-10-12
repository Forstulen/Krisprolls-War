using UnityEngine;
using System.Collections;
using System.Linq;

/// <summary>
/// CSV reader manager
/// </summary>
/// 

namespace TowerDefense
{

    public class CSVReader : SingletonScript<CSVReader>
    {

        /// <summary>
        /// Debugs the output grid.
        /// </summary>
        /// <param name="grid">Grid.</param>

        public void DebugOutputGrid(string[,] grid)
        {
            string textOutput = "";
            for (int y = 0; y < grid.GetUpperBound(1); y++)
            {
                for (int x = 0; x < grid.GetUpperBound(0); x++)
                {
                    textOutput += grid[x, y];
                    textOutput += "|";
                }
                textOutput += "\n";
            }
            Debug.Log(textOutput);
        }

        /// </summary>
        /// <returns>The csv grid.</returns>
        /// <param name="csvText">Csv text.</param>

        public string[,] SplitCsvGrid(string csvText)
        {
            string[] lines = csvText.Split("\n"[0]);

            // finds the max width of row
            int width = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] row = SplitCsvLine(lines[i]);
                width = Mathf.Max(width, row.Length);
            }

            // creates new 2D string grid to output to
            string[,] outputGrid = new string[lines.Length + 1, width + 1];
            for (int y = 0; y < lines.Length; y++)
            {
                string[] row = SplitCsvLine(lines[y]);
                for (int x = 0; x < row.Length; x++)
                {
                    outputGrid[y, x] = row[x];
                }
            }

            return outputGrid;
        }


        /// <summary>
        /// Splits the csv line.
        /// </summary>
        /// <returns>The csv line.</returns>
        /// <param name="line">Line.</param>

        public string[] SplitCsvLine(string line)
        {
            return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
                                                                                                                @"(((?<x>(?=[;\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^;\r\n]+));?)",
                                                                                                                System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
                    select m.Groups[1].Value).ToArray();
        }
    }

}