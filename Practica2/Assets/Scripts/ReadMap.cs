using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
/*
public class ReadMap  {
    public Block[][] loadMap(string ruta) {
        List<Block> _blocks = new List<Block>();
        
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

                    if (line == "[layer]")
                        if (sr.ReadLine() == "type=Tile Layer 1")
                        {
                            sr.ReadLine();
                            do
                            {
                                aux = sr.Read() + 48;
                                Block _aux = new Block();
                                _aux.setLife(aux);
                                _blocks.Add(_aux);

                            } while ((c = (char)sr.Read()) != '.');
                        }
                        else if (sr.ReadLine() == "type=Tile Layer 2") {
                            sr.ReadLine();
                            do
                            {
                                aux = sr.Read() + 48;

                                _blocks.Add(_aux);

                            } while ((c = (char)sr.Read()) != '.');
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
*/