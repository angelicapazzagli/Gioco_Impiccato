Random r = new Random();
string scelta_livello()
{
    bool scelta = false;
    while (scelta == false)
    {
        Console.WriteLine("Scegli il livello di difficoltà:\n1. Facile\n2. Medio\n3. Difficile");
        string livello = Console.ReadLine();
        if (livello == "Facile" || livello == "1")
        {
            scelta = true;
            return "parole_facili.txt";
        }
        else if (livello == "Medio" || livello == "2")
        {
            scelta = true;
            return "parole_medie.txt";
        }
        else if (livello == "Difficile" || livello == "3")
        {
            scelta = true;
            return "parole_difficili.txt";
        }
        else
        {
            Console.WriteLine("Livello di difficoltà non valido. Per favore reinseriscilo.");
        }
    }
    return "Errore";
}
void scelta_tema(string[] parole, string[] range)
{
    int inizio = 0, fine = 0;
    bool scelta = false;
    while (scelta == false)
    {
        Console.WriteLine("Scegli il tema:\n1. Paesi\n2. Calciatori\n3. Mestieri\n4. Brand");
        string tema = Console.ReadLine();
        if (tema == "Paesi" || tema == "1")
        {
            scelta = true;
            inizio = 0;
            fine = 9;
        }
        else if (tema == "Calciatori" || tema == "2")
        {
            scelta = true;
            inizio = 10;
            fine = 19;
        }
        else if (tema == "Mestieri" || tema == "3")
        {
            scelta = true;
            inizio = 20;
            fine = 29;
        }
        else if (tema == "Brand" || tema == "4")
        {
            scelta = true;
            inizio = 30;
            fine = 39;
        }
        else
        {
            Console.WriteLine("Tema non valido. Per favore reinseriscilo.");
        }
        int pos = 0;
        for (int i = inizio; i <= fine; i++)
        {
            range[pos++] = parole[i];
        }
    }
}
string sostituzione(string segreta)
{
    string sostituita = "";
    for(int i = 0; i < segreta.Length; i++)
    {
        sostituita += "_";
    }
    return sostituita;
}
Console.WriteLine("Benvenuto nel gioco dell'impiccato.\nIl gioco consiste nell'indovinare una parola, dovrai scegliere la difficoltà e se vorrai il tema, inserendo un carattere o provando direttamente la parola.\nBuona fortuna!");
bool chiudi = false;
while (chiudi == false)
{
    string file = scelta_livello();
    string[] parole = File.ReadAllLines(file);
    string[] range = new string[10];
    scelta_tema(parole, range);
    int indice_casuale = r.Next(range.Length);
    string segreta = range[indice_casuale - 1];
    Console.WriteLine(segreta);
    string sostituita = sostituzione(segreta);
    Console.WriteLine("\nCaricamento della parola in corso....\n");
    Console.WriteLine(sostituita);
    int tent = 0;
    while(sostituita != segreta)
    {
        if(tent < 2)
        {
            Console.WriteLine("1. Inserisci lettera\n2. Chiudi");
            string comando = Console.ReadLine();
            if (comando == "2" || comando == "Chiudi")
            {
                sostituita = segreta;
                chiudi = true;
            }
            else if(comando == "1" || comando == "Inserisci lettera")
            {
                Console.WriteLine("\nInserisci lettera: ");
                string lettera = Console.ReadLine();
                if (segreta.Contains(lettera))
                {
                    Console.WriteLine("\nBravo, lettera indovinata!\n");
                    for(int i = 0; i < segreta.Length; i++)
                    {
                        if (segreta[i] == lettera)
                        {
                            sostituita[i] = lettera;
                        }
                    }
                }
            }
        }
    }
}
