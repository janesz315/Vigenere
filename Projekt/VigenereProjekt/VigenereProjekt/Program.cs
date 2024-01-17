using System;

class Program
{
    static void Main()
    {
        int i = 0, j = 0, k = 0, d = 0;
        char c;
        char[] kulcs = new char[128]; // 127 karakter + a stringet lezáró karakter (\0)
        char[] szoveg = new char[256]; // 255 karakter + a stringet lezáró karakter (\0)

        Console.WriteLine("[K]odolni vagy [D]ekodolni szeretnel? (K/D)");
        c = Console.ReadKey().KeyChar;
        Console.WriteLine("\nKerem a kulcsot!");
        kulcs = Console.ReadLine().ToCharArray();
        Console.WriteLine("Kerem a nyilt szoveget!");
        szoveg = Console.ReadLine().ToCharArray();

        for (k = 0; k < kulcs.Length && kulcs[k] != '\0'; k++)
        {
            // Kisbetű->nagybetű konvertálás a kulcsban
            if (kulcs[k] >= 'a' && kulcs[k] <= 'z')
                kulcs[k] = (char)(kulcs[k] - 32);
            d++;
        }

        if (c == 'K')
        {
            // Itt kódolunk
            while (i < szoveg.Length && szoveg[i] != '\0')
            {
                if (j == d)
                    j = 0;

                if (szoveg[i] >= 'a' && szoveg[i] <= 'z')
                {
                    // A eset: a nyílt szöveg karaktere kisbetű
                    if (((szoveg[i] - 97) + (kulcs[j] - 65)) <= 25)
                        szoveg[i] = (char)(szoveg[i] + (kulcs[j] - 65));
                    else
                        szoveg[i] = (char)(szoveg[i] + (kulcs[j] - 65) - 26);
                }

                if (szoveg[i] >= 'A' && szoveg[i] <= 'Z')
                {
                    // B eset: a nyílt szöveg karaktere nagybetű
                    if ((szoveg[i] - 65) + (kulcs[j] - 65) <= 25)
                        szoveg[i] = (char)(szoveg[i] + (kulcs[j] - 65));
                    else
                        szoveg[i] = (char)(szoveg[i] + (kulcs[j] - 65) - 26);
                }

                i++;
                j++;
            }

            Console.WriteLine("A kodolt szoveg: " + new string(szoveg));
        }
        else if (c == 'D')
        {
            // Itt dekódolunk
            while (i < szoveg.Length && szoveg[i] != '\0')
            {
                if (j == d)
                    j = 0;

                if (szoveg[i] >= 'a' && szoveg[i] <= 'z')
                {
                    // A eset: a dekódolandó szöveg karaktere kisbetű
                    if ((szoveg[i] - 97) - (kulcs[j] - 65) >= 0)
                        szoveg[i] = (char)(szoveg[i] - (kulcs[j] - 65));
                    else
                        szoveg[i] = (char)(szoveg[i] - (kulcs[j] - 65) + 26);
                }

                if (szoveg[i] >= 'A' && szoveg[i] <= 'Z')
                {
                    // B eset: a dekódolandó szöveg karaktere nagybetű
                    if ((szoveg[i] - 65) - (kulcs[j] - 65) >= 0)
                        szoveg[i] = (char)(szoveg[i] - (kulcs[j] - 65));
                    else
                        szoveg[i] = (char)(szoveg[i] - (kulcs[j] - 65) + 26);
                }

                i++;
                j++;
            }

            Console.WriteLine("A dekodolt szoveg: " + new string(szoveg));
        }

        Console.ReadLine();
    }
}



