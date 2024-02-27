using System.IO;
using System;

class Program
{
    static void Main()
    {
        //Változók deklarálása
        int i = 0, j = 0, k = 0, d = 0;
        char c;
        //karaktertömbök készítése
        char[] kulcsE = new char[6]; // 5 karakter + a stringet lezáró karakter (\0)
        char[] szoveg = new char[256]; // 255 karakter + a stringet lezáró karakter (\0)
        char[] szovegKodolt = new char[256]; // 255 karakter + a stringet lezáró karakter (\0)
        //Használatba szeretném venni a fájlokat.
        string szovege = "nyiltSzoveg.txt";
        string fajlKodolas = "kodolt.txt";
        string fajlDekodolas = "kodoltMegfejtés.txt";
        //A kulcs és a módszer bekérése
        Console.WriteLine("[K]ódolni vagy [D]ekódolni szeretnél? (K/D)");
        c = Console.ReadKey().KeyChar;
        Console.WriteLine("\nKérem a kulcsot!");
        kulcsE = Console.ReadLine().ToCharArray();
        //A kulcs betûit nagybetûvé alakítom.
        for (int l = 0; l < kulcsE.Length; l++)
        {
            kulcsE[l] = char.ToUpper(kulcsE[l]);
        }
        
        int x = szoveg.Length;

        // Ha az elsõ karaktertömb rövidebb, ismételd meg annyiszor, hogy elérje a második karaktertömb hosszát
        while (kulcsE.Length < x)
        {
            kulcsE = ConcatenateArrays(kulcsE,kulcsE);
        }

        // Vegyük csak az x hosszúságú részét az elsõ karaktertömbnek
        char[] kulcs = new char[x];
        Array.Copy(kulcsE, kulcs, x);

        //Ha kódolunk
        if (c == 'K' || c == 'k')
        {
        
        using (StreamReader reader = new StreamReader(szovege))
        {
            // Teljes szöveg beolvasása a fájlból
            string teljesSzoveg = reader.ReadToEnd();

            // Karaktertömb létrehozása a szövegbõl
            szoveg = teljesSzoveg.ToCharArray();
        }
            // Itt kódolunk
            while (i < szoveg.Length && szoveg[i] != '\0')
            {
                if (j == d)
                    j = 0;

                
                if (szoveg[i] >= 'A' && szoveg[i] <= 'Z')
                {
                    // A nyílt szöveg karaktere nagybetû
                    if ((szoveg[i] - 65) + (kulcs[j] - 65) <= 25)
                        szoveg[i] = (char)(szoveg[i] + (kulcs[j] - 65));
                    else
                        szoveg[i] = (char)(szoveg[i] + (kulcs[j] - 65) - 26);
                }

                i++;
                j++;
            }
            using (StreamWriter writer = new StreamWriter(fajlKodolas))
            {
                // A string tömb minden elemét kiírjuk a fájlba
                writer.Write(new string(szoveg));
            }
            
            Console.WriteLine("A fájl kódolva --> {0}", fajlKodolas);

        }
        else if (c == 'D' || c == 'd')
        {
            using (StreamReader reader = new StreamReader(fajlKodolas))
            {
                // Teljes szöveg beolvasása a fájlból
                string teljesSzoveg = reader.ReadToEnd();

                // Karaktertömb létrehozása a szövegbõl
                szoveg = teljesSzoveg.ToCharArray();
            }
            // Itt dekódolunk
            while (i < szoveg.Length && szoveg[i] != '\0')
            {
                if (j == d)
                    j = 0;


                if (szoveg[i] >= 'A' && szoveg[i] <= 'Z')
                {
                    //A dekódolandó szöveg karaktere nagybetû
                    if ((szoveg[i] - 65) - (kulcs[j] - 65) >= 0)
                        szoveg[i] = (char)(szoveg[i] - (kulcs[j] - 65));
                    else
                        szoveg[i] = (char)(szoveg[i] - (kulcs[j] - 65) + 26);
                }

                i++;
                j++;
            }
            using (StreamWriter writer = new StreamWriter(fajlDekodolas))
            {
                // A string tömb minden elemét kiírjuk a fájlba
                writer.Write(new string(szoveg));
            }
            
            Console.WriteLine("A fájl dekódolva --> {0}", fajlDekodolas);

        }

        Console.ReadLine();
    }

    static char[] ConcatenateArrays(char[] array1, char[] array2)
    {
        //itt adom össze a karaktertömböket annyiszor, amennyiszer meghívom azt.
        char[] result = new char[array1.Length + array2.Length];
        Array.Copy(array1, result, array1.Length);
        Array.Copy(array2, 0, result, array1.Length, array2.Length);
        return result;
    }
}



