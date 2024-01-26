using System.IO;
using System;

class Program
{
    static void Main()
    {
        int i = 0, j = 0, k = 0, d = 0;

        char c;

        char[] kulcsE = new char[6]; // 5 karakter + a stringet lez�r� karakter (\0)

        char[] szoveg = new char[256]; // 255 karakter + a stringet lez�r� karakter (\0)

        char[] szovegKodolt = new char[256]; // 255 karakter + a stringet lez�r� karakter (\0)
        string szovege = "nyiltSzoveg.txt";
        string fajlKodolas = "kodolt.txt";
        string fajlDekodolas = "kodoltMegfejt�s.txt";
        


        Console.WriteLine("[K]odolni vagy [D]ekodolni szeretnel? (K/D)");
        c = Console.ReadKey().KeyChar;
        Console.WriteLine("\nKerem a kulcsot!");
        kulcsE = Console.ReadLine().ToCharArray();

        for (int l = 0; l < kulcsE.Length; l++)
        {
            kulcsE[l] = char.ToUpper(kulcsE[l]);
        }
        //Console.WriteLine("Kerem a nyilt szoveget!");
        //szoveg = Console.ReadLine().ToCharArray();

        int x = szoveg.Length;

        // Ha az elsoCharArray r�videbb, ism�teld meg annyiszor, hogy el�rje a masodikCharArray hossz�t
        while (kulcsE.Length < x)
        {
            kulcsE = ConcatenateArrays(kulcsE,kulcsE );
        }

        // Vegy�k csak az x hossz�s�g� r�sz�t az elsoCharArray-nek
        char[] kulcs = new char[x];
        Array.Copy(kulcsE, kulcs, x);

        //for (k = 0; k < kulcs.Length && kulcs[k] != '\0'; k++)
        //{
        //    //Kisbet�->nagybet� konvert�l�s a kulcsban
        //    if (kulcs[k] >= 'a' && kulcs[k] <= 'z')
        //        kulcs[k] = (char)(kulcs[k] - 32);
        //    d++;
        //}

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

                //if (szoveg[i] >= 'a' && szoveg[i] <= 'z')
                //{
                //    // A eset: a ny�lt sz�veg karaktere kisbet�
                //    if (((szoveg[i] - 97) + (kulcs[j] - 65)) <= 25)
                //        szoveg[i] = (char)(szoveg[i] + (kulcs[j] - 65));
                //    else
                //        szoveg[i] = (char)(szoveg[i] + (kulcs[j] - 65) - 26);
                //}

                if (szoveg[i] >= 'A' && szoveg[i] <= 'Z')
                {
                    // B eset: a ny�lt sz�veg karaktere nagybet�
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
            //Console.WriteLine("A kodolt szoveg: " + new string(szoveg));
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

                //if (szoveg[i] >= 'a' && szoveg[i] <= 'z')
                //{
                //    // A eset: a dek�doland� sz�veg karaktere kisbet�
                //    if ((szoveg[i] - 97) - (kulcs[j] - 65) >= 0)
                //        szoveg[i] = (char)(szoveg[i] - (kulcs[j] - 65));
                //    else
                //        szoveg[i] = (char)(szoveg[i] - (kulcs[j] - 65) + 26);
                //}

                if (szoveg[i] >= 'A' && szoveg[i] <= 'Z')
                {
                    // B eset: a dek�doland� sz�veg karaktere nagybet�
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
            //Console.WriteLine("A dekodolt szoveg: " + new string(szoveg));
            Console.WriteLine("A f�jl dek�dolva --> {0}", fajlDekodolas);

        }

        Console.ReadLine();
    }

    static char[] ConcatenateArrays(char[] array1, char[] array2)
    {
        char[] result = new char[array1.Length + array2.Length];
        Array.Copy(array1, result, array1.Length);
        Array.Copy(array2, 0, result, array1.Length, array2.Length);
        return result;
    }
}



