
class Program
{
    static void Main(string[] args)
    {
        int[] poleCisel = { 5, 4, 3, 2, 1 };
        Console.WriteLine("Původní pole: " + string.Join(", ", poleCisel)); // nasel jsem jak pridat , mezi cisla aby to vypadalo o neco uhledneji


        var serazenePole = SerazeniVzestupne(poleCisel);
        Console.WriteLine("Serazene pole: " + string.Join(", ", serazenePole));


        var obracenePole = ObratitElemntyVpoli(poleCisel);
        Console.WriteLine("Obracene pole: " + string.Join(", ", obracenePole));


        var odebraniPrvnihoPrvku = OdebratPrvniPrvek(poleCisel);
        Console.WriteLine("Bez prvniho elementu: " + string.Join(", ", odebraniPrvnihoPrvku));


        var OdebraniPoslednihoPrvku = OdebratPosledniPrvek(poleCisel);
        Console.WriteLine("Bez posledního elementu: " + string.Join(", ", OdebraniPoslednihoPrvku));


        var OdebraniPrvkuNaIndexu = OdeberNaIndexu(poleCisel, 2);
        Console.WriteLine("Bez elementu na indexu 2: " + string.Join(", ", OdebraniPrvkuNaIndexu));


        var PridaninaZacatek = PridejNaZacatek(poleCisel, 0);
        Console.WriteLine("Element pridan na zacatek: " + string.Join(", ", PridaninaZacatek));


        var PridaninaKonec = PridejNaKonec(poleCisel, 0);
        Console.WriteLine("Element pridan na konec: " + string.Join(", ", PridaninaKonec));


        var PridaniPrvkuNaIndexu = PridejNaIndexu(poleCisel, 2, 0);
        Console.WriteLine("Element pridan na indexu 2 : "  + string.Join(", ", PridaniPrvkuNaIndexu));
    }

    static int[] SerazeniVzestupne(int[] pole)
    {
        if (pole == null) return null;
        Array.Sort(pole);
        return pole;
    }


    static int[] ObratitElemntyVpoli(int[] pole)
    {
        if (pole == null) return null;
        Array.Reverse(pole);
        return pole;
    }


    static int[] OdebratPrvniPrvek(int[] pole)
    {
        if (pole == null || pole.Length == 0) return pole;
        int[] zkracenePole = new int[pole.Length - 1];
        Array.Copy(pole, 1, zkracenePole, 0, zkracenePole.Length);
        return zkracenePole;
    }


    static int[] OdebratPosledniPrvek(int[] pole)
    {
        if (pole == null || pole.Length == 0) return pole;
        int[] zkracenepole = new int[pole.Length - 1];
        Array.Copy(pole, 0, zkracenepole, 0, zkracenepole.Length);
        return zkracenepole;
    }

    static int[] OdeberNaIndexu(int[] pole, int index)
    {
        if (pole is null || index < 0 || index >= pole.Length)
            return pole;

        var novePole = new int[pole.Length - 1];
        int i = 0;
        foreach (var item in pole)
        {
            if (i != index)
                novePole[i < index ? i : i - 1] = item; // tady mi pomohl ChatGPT
            i++;
        }
        return novePole;
    }

    static int[] PridejNaZacatek(int[] pole, int element)
    {
        if (pole is null)
            return new[] { element };

        var novePole = new int[pole.Length + 1];
        novePole[0] = element;
        pole.CopyTo(novePole, 1); //  od indexu 1 nakopiruje pocatecni pole
        return novePole;
    }

    static int[] PridejNaKonec(int[] pole, int element)
    {
        if (pole is null)
            return new[] { element };

        var novePole = new int[pole.Length + 1];
        pole.CopyTo(novePole, 0); // zacina od indexu 0 a nakopiruje pocatecni pole
        novePole[^1] = element; // [^1] presune se na posledni index v poli
        return novePole;
    }

    static int[] PridejNaIndexu(int[] pole, int index, int element)
    {
        if (pole is null)
            return new[] { element };

        var novePole = new int[pole.Length + 1];
        for (int i = 0; i < novePole.Length; i++)
        {
            if (i < index)
                novePole[i] = pole[i];
            else if (i == index)
                novePole[i] = element;
            else
                novePole[i] = pole[i - 1];
        }
        return novePole;
    }
}
