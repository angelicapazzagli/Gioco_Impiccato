Random r = new Random();
//FUNZIONE PER FAR SCEGLIERE ALL'UTENTE IL LIVELLO DI DIFFICOLTA'
string scelta_livello(ref int n_tentativi, ref string livello, int n_indizi, int n_bonus)
{
    bool scelta = false;
    while (scelta == false)
    {
        Console.WriteLine("\nScegli il livello di difficoltà:\n1. Facile\n2. Medio\n3. Difficile");
        livello = Console.ReadLine();
        if (livello == "Facile" || livello == "1")
        {
            scelta = true;
            n_tentativi = 3;
            Console.WriteLine("\nGuadagnerai 5 punti se indovinerai la parola.\nTentativi disponibili: " + n_tentativi);
            return "parole_facili.txt";
        }
        else if (livello == "Medio" || livello == "2")
        {
            scelta = true;
            n_tentativi = 5;
            Console.WriteLine("\nGuadagnerai 10 punti se indovinerai la parola.\nHai " + n_bonus + " bonus lettere casuali a disposizione.\nTentativi disponibili: " + n_tentativi);
            return "parole_medie.txt";
        }
        else if (livello == "Difficile" || livello == "3")
        {
            scelta = true;
            n_tentativi = 7;
            Console.WriteLine("\nGuadagnerai 20 punti se indovinerai la parola.\nHai " + n_indizi + " indizi a disposizione.\nTentativi disponibili: " + n_tentativi);
            return "parole_difficili.txt";
        }
        else
        {
            Console.WriteLine("\nLivello di difficoltà non valido. Per favore reinseriscilo.\n");
        }
    }
    return "Errore";
}
//FUNZIONE PER FAR SCEGLIERE ALL'UTENTE L'ARGOMENTO DEL GIOCO
void scelta_tema(string[] parole, string[] range, string[] range_ind, string[] indizi_diff)
{
    int inizio = 0, fine = 0;
    bool scelta = false;
    while (scelta == false)
    {
        Console.WriteLine("\nScegli il tema:\n1. Paesi\n2. Calciatori\n3. Mestieri\n4. Brand");
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
            Console.WriteLine("\nTema non valido. Per favore reinseriscilo.\n ");
        }
        int pos = 0, pos1 = 0;
        for (int i = inizio; i <= fine; i++)
        {
            range[pos++] = parole[i];
            range_ind[pos1++] = indizi_diff[i]; 
        }
    }
}
char[] sostituzione(string segreta)
{
    char[] sostituita = new char[segreta.Length];
    for(int i = 0; i < segreta.Length; i++)
    {
        sostituita[i] = '_';
    }
    return sostituita;
}
char[] stringa_array(string segreta)
{
    char[] parola_segreta = new char[segreta.Length];
    for (int i = 0; i < segreta.Length; i++)
    {
        parola_segreta[i] = segreta[i];
    }
    return parola_segreta;
}
//FUNZIONE CHE CONTROLLA QUELLO CHE FARE NEL CASO FINISCANO I TENTATIVI A DISPOSIZIONE
void tentativi_finiti(int n_tentativi, string segreta, ref string non_indovinate, char[] sostituta, char[] parola_segreta)
{
    if(n_tentativi <= 0)
    {
        Console.WriteLine("\nHai esaurito i tentativi. Parola non indovinata.");
        non_indovinate += segreta + " ";
        for (int i = 0; i < sostituta.Length; i++)
        {
            sostituta[i] = parola_segreta[i];
        }
    }
}
//FUNZIONE PER ASSEGNARE I DIVERSI PUNTEGGI IN CASO DI PAROLA CORRETTA A SECONDA DELLA DIFFICOLTA'
int punteggio(string livello)
{
    int punti = 0;
    if (livello == "Facile" || livello == "1")
    {
        punti = 5;
    }
    else if (livello == "Medio" || livello == "2")
    {
        punti = 10;
    }
    else if (livello == "Difficile" || livello == "3")
    {
        punti = 20;
    }
    return punti;
}
//FUNZIONE PER L'UTILIZZO DEL JOLLY CHE FORNISCE LA PRIMA ED ULTIMA LETTERA
void jolly(ref char[] sostituta, string segreta, ref int n_jolly, ref bool utilizzato_j)
{
    if (utilizzato_j == false)
    {
        if (n_jolly > 0)
        {
            if (sostituta[0] == '_' || sostituta[sostituta.Length - 1] == '_')
            {
                Console.WriteLine("\n\nVuoi utilizzare il jolly? (si o no)");
                string ut_jolly = Console.ReadLine();
                if (ut_jolly == "si")
                {
                    sostituta[0] = segreta[0];
                    sostituta[sostituta.Length - 1] = segreta[sostituta.Length - 1];
                    Console.WriteLine("\nJolly utilizzato. Prima e ultima lettera indovinate.");
                    n_jolly--;
                    utilizzato_j = true;
                    for (int i = 0; i < sostituta.Length; i++)
                    {
                        Console.Write(sostituta[i] + " ");
                    }
                }
            }
        }
    }
}
//FUNZIONI PER ASSEGNARE GLI INDIZI E CONTROLLARE IL LORO FUNZIONAMENTO NEL CASO DI LIVELLO DIFFICILE
string ins_indizi(string livello)
{
    if (livello == "Difficile" || livello == "3")
    {
        return "indizi_difficili.txt";
    }
    return "";
}
void utilizzo_indizi(ref int n_indizi, string livello, char[] sostituta, string indizio, ref bool utilizzato_i)
{
    if (utilizzato_i == false)
    {
        if (n_indizi > 0)
        {
            if (livello == "3" || livello == "Difficile")
            {
                Console.WriteLine("\n\nVuoi l'indizio? (si o no)");
                string utilizzo = Console.ReadLine();
                if (utilizzo == "si")
                {
                    n_indizi--;
                    utilizzato_i = true;
                    Console.WriteLine(indizio);
                    for (int i = 0; i < sostituta.Length; i++)
                    {
                        Console.Write(sostituta[i] + " ");
                    }
                }
            }
        }
    }
}
//FUNZIONE PER BONUS RIVELAZIONE LETTERA CASUALE NEL CASO DI DIFFICOLTA' MEDIA
void bonus(ref int bonus_lettera, string segreta, ref char[] sostituta, string livello, ref bool utilizzato_b)
{
    int indice = -1, casuale;
    char lettera;
    if (livello == "2" || livello == "Medio")
    {
        if (utilizzato_b == false)
        {
            if (bonus_lettera > 0)
            {
                Console.WriteLine("\n\nVuoi utilizzare il bonus lettera? (si o no)");
                string risp_bonus = Console.ReadLine();
                if (risp_bonus == "si")
                {
                    bonus_lettera--;
                    utilizzato_b = true;
                    while (indice == -1)
                    {
                        casuale = r.Next(0, sostituta.Length);
                        if (sostituta[casuale] == '_')
                        {
                            indice = casuale;
                        }
                    }
                    lettera = segreta[indice];
                    for (int i = 0; i < sostituta.Length; i++)
                    {
                        if (segreta[i] == lettera)
                        {
                            sostituta[i] = lettera;
                        }
                    }
                }
                Console.WriteLine("\nParola con lettera aggiunta: ");
                for (int i = 0; i < sostituta.Length; i++)
                {
                    Console.Write(sostituta[i] + " ");
                }
            }
        }
    }
}
//FUNZIONE CHE CONTIENE IL FUNZIONAMENTO GENERALE DEL GIOCO E GESTISCE I CASI POSSIBILI
void indovina_parola(ref char[] sostituta, char[] parola_segreta, ref bool chiudi, string segreta, ref int n_tentativi, ref string p_indovinate, ref string non_indovinate, string livello, ref int punteggio_tot, ref int n_jolly, ref int n_indizi, string[] indizi_diff, string indizio, ref int bonus_lettera)
{
    int lettere_indovinate = 0, punti;
    string l_provate = "", p_provate = "";
    bool utilizzato_i = false, utilizzato_j = false, utilizzato_b = false;
    while (sostituta.Contains('_'))
    {
        punti = 0;
        for(int i = 0; i < sostituta.Length; i++)
        {
            Console.Write(sostituta[i] + " ");
        }
        jolly(ref sostituta, segreta, ref n_jolly, ref utilizzato_j);
        utilizzo_indizi(ref n_indizi, livello, sostituta, indizio, ref utilizzato_i);
        bonus(ref bonus_lettera, segreta, ref sostituta, livello, ref utilizzato_b);
        Console.WriteLine("\n\n1. Inserisci lettera\n2. Prova parola\n3. Chiudi");
        string comando = Console.ReadLine();
        if (comando != "3" && comando != "Chiudi")
        {
            Console.WriteLine("\nTentativi rimasti: " + n_tentativi);
        }           
        if (comando == "3" || comando == "Chiudi")
        {
            for(int i = 0; i < sostituta.Length; i++)
            {
                sostituta[i] = parola_segreta[i];
            }
            chiudi = true;
        }
        else if (comando == "1" || comando == "Inserisci lettera")
        {
            char[] lettere_provate = stringa_array(l_provate);
            Console.WriteLine("\nLettere provate: ");
            for (int i = 0; i < lettere_provate.Length; i++)
            {
                Console.Write(lettere_provate[i] + "  ");
            }
            Console.WriteLine("\nInserisci lettera: ");
            char lettera = Console.ReadLine()[0];
            if (l_provate.Contains(lettera))
            {
                Console.WriteLine("\nLettera già inserita.\n");
            }
            else
            {
                l_provate += lettera;
                if (segreta.Contains(lettera))
                {                    
                    Console.WriteLine("\nBravo, lettera indovinata!\n");
                    for (int i = 0; i < parola_segreta.Length; i++)
                    {
                        if (parola_segreta[i] == lettera && sostituta[i] != lettera)
                        {
                            sostituta[i] = lettera;
                            lettere_indovinate++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nLettera errata. Tentativo perso.");
                    n_tentativi--;
                }
                tentativi_finiti(n_tentativi, segreta, ref non_indovinate, sostituta, parola_segreta);
            }
            if (!sostituta.Contains('_'))
            {
                Console.WriteLine("\nComplimenti! Parola indovinata.");
                p_indovinate += segreta + " ";
                punti = punteggio(livello);
            }
        }
        else if (comando == "2" || comando == "Prova parola")
        {
            string[] parole_provate = p_provate.Split(' ');
            Console.WriteLine("\nParole provate: ");
            for (int i = 0; i < parole_provate.Length; i++)
            {
                Console.Write(parole_provate[i] + " ");
            }
            Console.WriteLine("\nInserisci parola:");
            string parola_utente = Console.ReadLine();
            if (p_provate.Contains(parola_utente))
            {
                Console.WriteLine("\nParola già inserita.\n");
            }
            else
            {
                p_provate += parola_utente + " ";
                if (parola_utente.ToLower() == segreta.ToLower())
                {
                    Console.WriteLine("\nComplimenti! Parola indovinata.");
                    p_indovinate += parola_utente + " ";
                    for (int i = 0; i < sostituta.Length; i++)
                    {
                        sostituta[i] = parola_segreta[i];
                    }
                    punti = punteggio(livello);
                }
                else
                {
                    Console.WriteLine("\nParola errata. Ritenta quando sarai più sicuro.");
                    n_tentativi--;
                }
                tentativi_finiti(n_tentativi, segreta, ref non_indovinate, sostituta, parola_segreta);
            }
        }
        punteggio_tot += punti;
    }
}
//OUTPUT INDICAZIONI
Console.WriteLine("Benvenuto nel gioco dell'impiccato.\nIl gioco consiste nell'indovinare una parola, scegliendo la difficoltà ed il tema ed inserendo un carattere o la parola.\nHai a disposizione tre jolly in totale, permettono di rivelare la prima e l'ultima lettera.\nBuona fortuna!");
bool chiudi = false, utilizzata;
int indice_casuale = -1, n_tentativi = 0, punteggio_tot = 0, n_jolly = 3, n_indizi = 3, n_bonus = 3;
string livello = "", file, segreta = "", p_indovinate = "", non_indovinate = "", indizi, indizio = "";
//CICLO CHE RIPETE IL FUNZIONAMENTO DEL GIOCO CON I VARI CASI FINCHE' L'UTENTE NON DECIDE DI CHIUDERE
while (chiudi == false)
{
    //ASSEGNAZIONE E SCELTA DI FILE, PAROLE, INDIZI
    file = scelta_livello(ref n_tentativi, ref livello, n_indizi, n_bonus);
    string[] parole = File.ReadAllLines(file);
    string[] range = new string[10];
    indizi = ins_indizi(livello);
    string[] indizi_diff = new string[parole.Length];
    if (livello == "3" || livello == "Difficile")
    {
        indizi_diff = File.ReadAllLines(indizi);
    }
    string[] range_ind = new string[10];
    scelta_tema(parole, range, range_ind, indizi_diff);
    utilizzata = true;
    while(utilizzata == true)
    {
        indice_casuale = r.Next(range.Length - 1);
        segreta = range[indice_casuale];
        indizio = range_ind[indice_casuale];
        if (p_indovinate.Contains(segreta) == false)
        {
            utilizzata = false;
        }
    }
    char[] parola_segreta = stringa_array(segreta);
    char[] sostituta = sostituzione(segreta);
    Console.WriteLine("\nCaricamento della parola in corso....\n");
    indovina_parola(ref sostituta, parola_segreta, ref chiudi, segreta, ref n_tentativi, ref p_indovinate, ref non_indovinate, livello, ref punteggio_tot, ref n_jolly, ref n_indizi, indizi_diff, indizio, ref n_bonus);
}
string[] parole_indovinate = p_indovinate.Split(' ');
string[] parole_non_indovinate = non_indovinate.Split(' ');
//CICLO CHE CONTROLLA CHE SE LA PAROLA SI TROVA SIA SU INDOVINATE CHE NON LA TOGLIE DALLE NON INDOVINATE
for(int i = 0; i < parole_non_indovinate.Length; i++)
{
    for(int j = 0; j < parole_indovinate.Length; j++)
    {
        if (parole_non_indovinate[i] == parole_indovinate[j])
        {
            parole_non_indovinate[i] = "";
        }
    }
}
//OUTPUT RISULTATI FINALI DEL GIOCO
Console.WriteLine("\nParole indovinate: ");
for(int i = 0; i < parole_indovinate.Length;  i++)
{
    Console.Write(parole_indovinate[i] + "  ");
}
Console.WriteLine("\nParole non indovinate: ");
for (int i = 0; i < parole_non_indovinate.Length; i++)
{
    Console.Write(parole_non_indovinate[i] + "  ");
}
Console.WriteLine("\n\nPunteggio totale: " + punteggio_tot);
Console.WriteLine("\n\nGioco terminato.");
