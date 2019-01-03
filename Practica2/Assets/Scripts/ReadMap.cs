using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;


public class ReadMap : MonoBehaviour
{
    public Block blockGObj;

    public List<Block> loadMap(int level) {
        List<Block> _blocks = new List<Block>();
        string ruta = "Assets/Maps/mapdata"+ level + ".txt";


        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader(ruta))
            {
                char c;
                int aux;
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null) {
                    if (line == "[layer]") {
                        string layer = sr.ReadLine();
                        if (layer == "type=Tile Layer 1")
                        {
                            sr.ReadLine();
                            int i = 0;
                            do
                            {
                                aux = sr.Read();
                                if (aux == 13 ) { //Salto de línea
                                   sr.ReadLine();
                                    aux= sr.Read()- 48;
                                }
                                else aux -= 48;

                                if (aux != 0)
                                {
                                    int x = i % 11;
                                    int y = i / 11;
                                    Block _block = Instantiate(blockGObj);
                                    _block.gameObject.transform.position = new Vector3(x, y, 0);
                                    _block.gameObject.GetComponent<Block>().SetLife(20);
                                    // Block _block = block.GetComponent<Block>();
                                    _block.SetType(aux);
                                    _block.SetPos(i % 11, i / 11);
                                    _blocks.Add(_block); 
                                }
                                i++;
                            } while ((c = (char)sr.Read()) != '.');
                        }
                        else if (layer == "type=Tile Layer 2") {
                            sr.ReadLine();
                            int i = 0;
                            do
                            {
                                // aux = sr.Read();
                                // if (aux == 13)
                                // { //Salto de línea
                                //     sr.ReadLine();
                                //     aux = sr.Read() - 48;
                                // }
                                // else aux -= 48;
                                _blocks[1].SetLife(900);
                                aux = sr.Read() - 48;
                                if (aux != 0)
                                {
                                   // _blocks[i].SetLife(aux);
                                    i++;
                                }//Fin if

                            } while ((c = (char)sr.Read()) != '.');
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return null;
    }

}
