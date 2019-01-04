using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
<<<<<<< HEAD
using UnityEngine.UI;


public class ReadMap : MonoBehaviour
{
    [Tooltip("Prefab block")]
    public Block blockGObj;

    public int y;
    public List<Block> loadMap(int level) {
        List<Block> _blocks = new List<Block>();
        string ruta = "Assets/Maps/mapdata"+ level + ".txt";
        
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(ruta))
            {
                string line;
                y = 0;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null) {
                    if (line == "[layer]") {
                        line = sr.ReadLine(); //Type
                        if (line == "type=Tile Layer 1")
                        {
                            sr.ReadLine(); // Data
                            bool ended = false;
                            while(!ended)
                            {
                                line = sr.ReadLine();
                                //Compruebo si es la última linea
                                if (line.EndsWith(".")) {
                                    line = line.Substring(0, line.Length - 1);
                                    ended = true;
                                }
                                string[] casillas = line.Split(',');

                                int x = 0;

                                foreach (string _aux in casillas) {
                                    if (_aux != "0" && _aux != "") {
                                        Block _block = Instantiate(blockGObj);
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
                            sr.ReadLine();
                            int i = 0;
                            bool ended = false;
                            while (!ended)
                            {
                                line = sr.ReadLine();
                                //Compruebo si es la última linea
                                if (line.EndsWith("."))
                                {
                                    line = line.Substring(0, line.Length - 1);
                                    ended = true;
                                }
                                string[] casillas = line.Split(',');
                                foreach (string _aux in casillas)
                                {
                                    if (_aux != "0" && _aux != "")
                                    {
                                        int type;
                                        int.TryParse(_aux, out type);
                                        _blocks[i].SetLife(type);
                                        _blocks[i].invertPosY(y);
                                        i++;
                                    }//Fin if
                                }//Fin foreach
                            }// Fin del while
                        }//Fin if layer 2
                    }
                }
                sr.Close();
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
*/