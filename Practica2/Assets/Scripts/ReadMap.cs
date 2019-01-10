using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

using UnityEngine.UI;


public class ReadMap : MonoBehaviour
{
    [Tooltip("Prefab block")]
    public Block blockGObj;
    private Transform parent;

    public int y;
    public List<Block> loadMap(int level) {
        parent = new GameObject("Blocks").transform;

        List<Block> _blocks = new List<Block>();
        TextAsset text = Resources.Load("Maps/mapdata" + level) as TextAsset;
        string[] mapas = text.text.Split(new char[] { '\r','\n' }, StringSplitOptions.RemoveEmptyEntries);
        int iLine= 0;

        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            if (mapas.Length>0)
            {
                string line;
                y = 0;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while (iLine <= mapas.Length) {
                    line = mapas[iLine];
                    if (line == "[layer]") {
                        iLine++;
                        line = mapas[iLine]; //Type
                        if (line == "type=Tile Layer 1")
                        {
                            iLine++; // Saltamos línea Data
                            bool ended = false;
                            while(!ended)
                            {
                                iLine++;
                                line = mapas[iLine];
                                //Compruebo si es la última linea
                                if (line.EndsWith(".")) {
                                    line = line.Substring(0, line.Length - 1);
                                    ended = true;
                                }
                                string[] casillas = line.Split(',');

                                int x = 0;

                                foreach (string _aux in casillas) {
                                    if (_aux != "0" && _aux != "") {
                                        Block _block = Instantiate(blockGObj,parent);
                                        int type;
                                        int.TryParse(_aux, out type);
                                        _block.SetType(type);
                                        _block.SetPos(x, y);
                                        _blocks.Add(_block);
                                    }
                                    x++;
                                }
                                y++;
                            }
                        }
                        else if (line == "type=Tile Layer 2") {
                            iLine++;
                            line = mapas[iLine];
                            bool ended = false;
                            int i = 0;//Casilla que necesita la vida
                            int b = 0;//Índice que marca las casillas leídas
                            int id = _blocks[0].GetPosX()+ _blocks[0].GetPosY() * 11;//Id de la casilla que queremos
                            while (!ended)
                            {
                                iLine++;
                                line = mapas[iLine];
                                //Compruebo si es la última linea
                                if (line.EndsWith("."))
                                {
                                    line = line.Substring(0, line.Length - 1);
                                    ended = true;
                                }
                                string[] casillas = line.Split(',');
                                foreach (string _aux in casillas)
                                {
                                    if (_aux != "")
                                    {
                                        if (b == id) { 
                                            int type;
                                            int.TryParse(_aux, out type);
                                            _blocks[i].SetLife(type);
                                            _blocks[i].invertPosY(y);
                                            i++;
                                            id = _blocks[i].GetPosX() + _blocks[i].GetPosY() * 11;
                                        }
                                        b++;
                                    }//Fin if
                                }//Fin foreach
                            }// Fin del while
                        }//Fin if layer 2
                    }
                    iLine++;
                }
                blockGObj.enabled=false;
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return _blocks;
    }

}
