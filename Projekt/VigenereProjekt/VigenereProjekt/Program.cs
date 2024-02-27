using System.IO;
using System;

class Program
{
    static void Main()
    {
        //V�ltoz�k deklar�l�sa
        int i = 0, j = 0, k = 0, d = 0;
        char c;
        //karaktert�mb�k k�sz�t�se
        char[] kulcsE = new char[6]; // 5 karakter + a stringet lez�r� karakter (\0)
        char[] szoveg = new char[256]; // 255 karakter + a stringet lez�r� karakter (\0)
        char[] szovegKodolt = new char[256]; // 255 karakter + a stringet lez�r� karakter (\0)
        //Haszn�latba szeretn�m venni a f�jlokat.
        string szovege = "nyiltSzoveg.txt";
        string fajlKodolas = "kodolt.txt";
        string fajlDekodolas = "kodoltMegfejt�s.txt";
        //A kulcs �s a m�dszer bek�r�se
        Console.WriteLine("[K]�dolni vagy [D]ek�dolni szeretn�l? (K/D)");
        c = Console.ReadKey().KeyChar;
        Console.WriteLine("\nK�rem a kulcsot!");
        kulcsE = Console.ReadLine().ToCharArray();
        //A kulcs bet�it nagybet�v� alak�tom.
        for (int l = 0; l < kulcsE.Length; l++)
        {
            kulcsE[l] = char.ToUpper(kulcsE[l]);
        }
        
        int x = szoveg.Length;

        // Ha az els� karaktert�mb r�videbb, ism�teld meg annyiszor, hogy el�rje a m�sodik karaktert�mb hossz�t
        while (kulcsE.Length < x)
        {
            kulcsE = ConcatenateArrays(kulcsE,kulcsE);
        }

        // Vegy�k csak az x hossz�s�g� r�sz�t az els� karaktert�mbnek
        char[] kulcs = new char[x];
        Array.Copy(kulcsE, kulcs, x);

        //Ha k�dolunk
        if (c == 'K' || c == 'k')
        {
        
        using (StreamReader reader = new StreamReader(szovege))
        {
            // Teljes sz�veg beolvas�sa a f�jlb�l
            string teljesSzoveg = reader.ReadToEnd();

            // Karaktert�mb l�trehoz�sa a sz�vegb�l
            szoveg = teljesSzoveg.ToCharArray();
        }
            // Itt k�dolunk
            while (i < szoveg.Length && szoveg[i] != '\0')
            {
                if (j == d)
                    j = 0;

                
                if (szoveg[i] >= 'A' && szoveg[i] <= 'Z')
                {
                    // A ny�lt sz�veg karaktere nagybet�
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
                // A string t�mb minden elem�t ki�rjuk a f�jlba
                writer.Write(new string(szoveg));
            }
            
            Console.WriteLine("A f�jl k�dolva --> {0}", fajlKodolas);

        }
        else if (c == 'D' || c == 'd')
        {
            using (StreamReader reader = new StreamReader(fajlKodolas))
            {
                // Teljes sz�veg beolvas�sa a f�jlb�l
                string teljesSzoveg = reader.ReadToEnd();

                // Karaktert�mb l�trehoz�sa a sz�vegb�l
                szoveg = teljesSzoveg.ToCharArray();
            }
            // Itt dek�dolunk
            while (i < szoveg.Length && szoveg[i] != '\0')
            {
                if (j == d)
                    j = 0;


                if (szoveg[i] >= 'A' && szoveg[i] <= 'Z')
                {
                    //A dek�doland� sz�veg karaktere nagybet�
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
                // A string t�mb minden elem�t ki�rjuk a f�jlba
                writer.Write(new string(szoveg));
            }
            
            Console.WriteLine("A f�jl dek�dolva --> {0}", fajlDekodolas);

        }

        Console.ReadLine();
    }

    static char[] ConcatenateArrays(char[] array1, char[] array2)
    {
        //itt adom �ssze a karaktert�mb�ket annyiszor, amennyiszer megh�vom azt.
        char[] result = new char[array1.Length + array2.Length];
        Array.Copy(array1, result, array1.Length);
        Array.Copy(array2, 0, result, array1.Length, array2.Length);
        return result;
    }
}



