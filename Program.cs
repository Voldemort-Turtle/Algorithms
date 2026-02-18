namespace Algorytmy
{
    public class Node
    {
        public Node lewy;
        public Node prawy;
        public int value;


        public Node(int value, Node lewy = null, Node prawy = null)
        {
            this.value = value;
            this.lewy = lewy;
            this.prawy = prawy;
        }
    }

    public class BST
    {
        private Node root;

        public BST(Node root = null)
        {
            this.root = root;
        }

        public void Dodaj(int value)
        {
            root = DodajRek(root, value);
        }
        private Node DodajRek(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }
            if (value < node.value)
            {
                node.lewy = DodajRek(node.lewy, value);
            }
            else if (value > node.value)
            {
                node.prawy = DodajRek(node.prawy, value);
            }
            return node;
        }
        public bool CzyZawiera(int value)
        {
            return CzyZawieraRek(root, value);
        }
        private bool CzyZawieraRek(Node node, int value)
        {
            if (node == null)
            {
                return false;
            }
            if (value == node.value)
            {
                return true;
            }
            if (value < node.value)
            {
                return CzyZawieraRek(node.lewy, value);
            }
            else
            {
                return CzyZawieraRek(node.prawy, value);
            }
        }
        public void WypiszPreOrder()
        {
            PreOrder(root);
            Console.WriteLine();
        }
        public void WypiszPreOrderIter()
        {
            if (root == null)
            {
                return;
            }
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                Node current = stack.Pop();
                Console.Write(current.value + " ");
                if (current.prawy != null)
                {
                    stack.Push(current.prawy);
                }
                if (current.lewy != null)
                {
                    stack.Push(current.lewy);
                }
            }
        }
        private void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.value + " ");

            PreOrder(node.lewy);
            PreOrder(node.prawy);
        }
        public void WypiszInOrder()
        {
            InOrder(root);
            Console.WriteLine();
        }
        private void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.lewy);
            Console.Write(node.value + " ");
            InOrder(node.prawy);
        }
        public void WypishPostOrder()
        {
            PostOrder(root);
            Console.WriteLine();
        }
        private void PostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.lewy);
            PostOrder(node.prawy);
            Console.Write(node.value + " ");
        }
    }
    public class Element
    {
        public int wartosc;
        public Element nastepny;
        public Element popszedni;

        public Element(int wartosc, Element nastepny = null, Element popszsedni = null)
        {
            this.wartosc = wartosc;
            this.nastepny = nastepny;
            this.popszedni = popszedni;
        }
    }
    public class ElementListyDwukierunkowej
    {
        private Element head;
        private Element tail;
        public ElementListyDwukierunkowej()
        {
            head = null;
            tail = null;
        }
        public void Dodaj(int wartosc)
        {
            if (head == null)
            {
                head = tail = new Element(wartosc);
            }
            else
            {
                Element nowy = new Element(wartosc, null, tail);
                tail.nastepny = nowy;
                tail = nowy;
            }
        }
        public void Wypisz()
        {
            Element current = head;
            while (current != null)
            {
                Console.Write(current.wartosc);
                if (current.nastepny != null)
                {
                    Console.Write(" -> ");
                }
                current = current.nastepny;
            }
            Console.WriteLine();
        }
        public bool CzyJest(int wartosc)
        {
            Element current = head;
            while (current != null)
            {
                if (current.wartosc == wartosc)
                {
                    return true;
                }
            }
            return false;
        }
        public void UsunPierwszy()
        {
            if (head != null)
            {
                head = head.nastepny;
                head.popszedni = null;
            }
        }
        public void UsunOstatni()
        {
            if (head == null)
            {
                return;
            }
            if (head.nastepny == null)
            {
                head = null;
                return;
            }
            Element current = head;
            while (current.nastepny.nastepny != null)
            {
                current = current.nastepny;
            }
            current.nastepny = null;
        }
        public void Usun(int wartosc)
        {
            Element current = head;
            while (current != null)
            {
                if (current.wartosc == wartosc)
                {
                    if (current == head)
                    {
                        head = head.nastepny;
                        if (head != null)
                        {
                            head.popszedni = null;
                        }
                        else
                        {
                            tail = null;
                        }
                        return;
                    }
                    if (current == tail)
                    {
                        tail = tail.popszedni;
                        tail.nastepny = null;
                        return;
                    }
                    current.popszedni.nastepny = current.nastepny;
                    current.nastepny.popszedni = current.popszedni;
                    return;
                }
                current = current.nastepny;
            }
        }
    }
    public class Kolejka<T>
    {
        private List<T> list;
        public Kolejka()
        {
            list = new List<T>();
        }
        public void enqueue(T x)
        {
            list.Add(x);
        }
        public T dequeue()
        {
            if (isEmpty())
            {
                throw new Exception("Kolejka jes pusta");
            }
            T value = list[0];
            list.RemoveAt(0);
            return value;
        }
        public T peek()
        {
            if (isEmpty())
            {
                throw new Exception("Kolejka jes pusta");
            }
            return list[0];
        }
        public bool isEmpty()
        {
            return list.Count == 0;
        }
        public int size()
        {
            return list.Count;
        }
    }
    public class Kolejka
    {
        private int[] tab;
        private int dol;
        private int gora;
        private int liczba_el;
        public Kolejka(int pojemnosc)
        {
            tab = new int[pojemnosc];
            liczba_el = 0;
            gora = 0;
            dol = 0;
        }
        public void enqueue(int x)
        {
            if (liczba_el == tab.Length)
            {
                throw new Exception("Kolejka przepelnia");
            }
            tab[dol] = x;
            dol = (dol + 1) % tab.Length;
            liczba_el++;

        }
        public int dequeue()
        {
            if (isEmpty())
            {
                throw new Exception("Kolejka jes pusta");
            }
            int value = tab[gora];
            gora = (gora + 1) % tab.Length;
            liczba_el--;
            return value;
        }
        public int peek()
        {
            if (isEmpty())
            {
                throw new Exception("Kolejka jes pusta");
            }
            return tab[gora];
        }
        public bool isEmpty()
        {
            return liczba_el == 0;
        }
        public int size()
        {
            return liczba_el;
        }
    }
    public class Stos<T>
    {
        private List<T> list;
        public Stos()
        {
            list = new List<T>();
        }
        public void push(T x)
        {
            list.Add(x);
        }
        public T pop()
        {
            if (isEmpty())
            {
                throw new Exception("Stos jest pusty");
            }
            int indeks = list.Count - 1;
            T value = list[indeks];
            list.RemoveAt(indeks);

            return value;
        }
        public T top()
        {
            if (isEmpty())
            {
                throw new Exception("Stos jest pusty");
            }
            return list[list.Count - 1];
        }
        public bool isEmpty()
        {
            return list.Count == 0;
        }
        public int size()
        {
            return list.Count;
        }
    }
    public class Stos
    {
        private int[] tablica;
        private int pojemnosc;
        private int gora;
        public Stos(int pojemnosc)
        {
            tablica = new int[pojemnosc];
            this.pojemnosc = pojemnosc;
            gora = -1;
        }
        public void push(int x)
        {
            if (gora == tablica.Length - 1)
            {
                throw new Exception("stos przepelniony");
            }
            tablica[++gora] = x;

        }
        public int pop()
        {
            if (isEmpty())
            {
                throw new Exception("Stos jest pusty");
            }
            return tablica[gora--];
        }
        public int peek()
        {
            if (isEmpty())
            {
                throw new Exception("Stos jest pusty");
            }
            return tablica[gora];
        }
        public bool isEmpty()
        {
            return gora == -1;
        }
        public int size()
        {
            return gora + 1;
        }
    }
    public class Licznik_operacji
    {
        private int licznik_zmian;
        private int licznik_porownan;

        public int Licznik_zmian { get => licznik_zmian; set => licznik_zmian = value; }
        public int Licznik_porownan { get => licznik_porownan; set => licznik_porownan = value; }

        public Licznik_operacji(int licznik_zmian, int licznik_porownan)
        {
            Licznik_zmian = licznik_zmian;
            Licznik_porownan = licznik_porownan;
        }
        public void Zwiększ_licznik_zmian()
        {
            Licznik_zmian++;
        }
        public void Zwiększ_licznik_porownan()
        {
            Licznik_porownan++;
        }
        public void Wypisz_statystyki()
        {
            Console.WriteLine("Liczba porównań: " + Licznik_porownan);
            Console.WriteLine("Liczba zmian: " + Licznik_zmian);
        }
        public void Reset()
        {
            Licznik_porownan = 0;
            Licznik_zmian = 0;
        }
    }
    internal class Program
    {
        static bool LiczbaNarcys(int n)
        {
            int liczba = n;
            int ilosc_cyfr = Convert.ToString(liczba).Length;
            int suma = 0;

            while (liczba > 0)
            {
                int cyfra = liczba % 10;
                suma += (int)(Math.Pow(cyfra, ilosc_cyfr));
                liczba /= 10;
            }

            if (suma == n)
            {
                return true;
            }
            return false;
        }
        static void RozkladNaCzynnikiPierwsze(int n)
        {
            int i = 2;
            while (n > 1)
            {
                while (n % i == 0)
                {
                    Console.Write(i + " ");
                    n = n / i;

                }
                i++;
            }
        }
        public static int EuklidesIteracyjny(int a, int b)
        {
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }
       
        static int NWW(int a, int b)
        {
            return (a * b) / EuklidesIteracyjny(a, b);
        }
        static int WyszukiwanieBinarne(int[] tab, int wyszukiwana)
        {
            int lewa = 0;
            int prawa = tab.Length - 1;
            if (prawa < lewa) { return -1; }
            int srednia = (lewa + prawa) / 2;
            while (tab[srednia] != wyszukiwana)
            {
                if (tab[srednia] < wyszukiwana)
                {
                    lewa = srednia + 1;
                }
                else if (tab[srednia] > wyszukiwana)
                {
                    prawa = srednia + 1;
                }
                srednia = (lewa + prawa) / 2;
            }
            return srednia;
        }
        static double Pierwiastek(double p, double eps)
        {
            double a = 1;
            double b = p;

            if (a - b >= eps)
            {
                a = (a + b) / 2.0;
                b = p / a;
            }
            return (a + b) / 2;
        }
        static string Cezar(string s)
        {
            string wynik = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    wynik += ' ';
                }
                else if (s[i] >= 'a' && s[i] <= 'z')
                {
                    int u = 'a' + ((Convert.ToInt32(s[i]) + 3 - 'a') % 26);
                    wynik += Convert.ToChar(u);
                }
                else if (s[i] >= 'A' && s[i] <= 'Z')
                {
                    int u = 'A' + ((Convert.ToInt32(s[i]) + 3 - 'A') % 26);
                    wynik += Convert.ToChar(u);
                }
            }
            return wynik;
        }
        static Dictionary<int, int> WydawanieResztZachlannie(int kwota, int[] nominaly)
        {
            Array.Sort(nominaly);
            Array.Reverse(nominaly);

            Dictionary<int, int> wynik = new Dictionary<int, int>();

            int pozostalaKwota = kwota;
            foreach (var nom in nominaly)
            {
                int liczbaSztuk = pozostalaKwota / nom;
                if (liczbaSztuk > 0)
                {
                    wynik[nom] = liczbaSztuk;
                    pozostalaKwota -= liczbaSztuk + nom;
                }
            }
            return wynik;
        }
        static int WyszukiwanieLiniowe(int[] tablica, int szukanaLiczba)
        {
            for (int i = 0; i < tablica.Length; i++)
            {
                if (tablica[i] == szukanaLiczba)
                {
                    return i;
                }

            }
            return -1;
        }
        public static (int maxSum, int startIndex, int endIndex) Kadane(int[] tab)
        {
            int maxSum = int.MinValue;
            int tempStart = 0;
            int currentSum = 0;
            int start = 0;
            int end = 0;

            for (int i = 0; i < tab.Length; i++)
            {
                currentSum += tab[i];
                if (currentSum < 0)
                {
                    currentSum = 0;
                    tempStart = i + 1;
                }
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    start = tempStart;
                    end = i;
                }
            }
            return (maxSum, start, end);
        }
        static int[] Sortowanie(int[] tab)
        {


            for (int i = 0; i < tab.Length - 1; i++)
            {
                int min = tab[i];
                int index = 0;
                for (int j = 0 + i; j < tab.Length; j++)
                {
                    if (tab[j] < min)
                    {
                        min = tab[j];
                        index = j;
                    }
                }
                if (index != 1)
                {
                    int temp = tab[i];
                    tab[i] = tab[index];
                    tab[index] = temp;
                }

            }
            return tab;
        }
        static int[] bubbleSort(int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab.Length - 1; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        int temp = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = temp;
                    }
                }
            }
            return tab;
        }
        static int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(minValue, maxValue + 1);
            }
            return array;
        }
        static string Decimal_to_binary(int n)
        {
            string wynik = "";
            if (n == 0)
            {
                return "0";
            }
            while (n > 0)
            {
                int reszta = n % 2;
                wynik += reszta;
                n /= 2;
            }
            return wynik;
        }
        static void Merge(int[] tab, int lewo, int srodek, int prawo)
        {
            int n1 = srodek - lewo + 1;
            int n2 = prawo - srodek;

            int[] l = new int[n1];
            int[] r = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                l[i] = tab[lewo + i];
            }
            for (int j = 0; j < n2; j++)
            {
                r[j] = tab[srodek + 1 + j];
            }
            int iL = 0;
            int iR = 0;
            int k = lewo;

            while (iL < n1 && iR < n2)
            {
                if (l[iL] <= r[iR])
                {
                    tab[k] = l[iL];
                    iL++;
                }
                else
                {
                    tab[k] = r[iR];
                    iR++;
                }
                k++;
            }
            while (iL < n1)
            {
                tab[k] = l[iL];
                iL++;
                k++;
            }
            while (iR < n2)
            {
                tab[k] = r[iR];
                iR++;
                k++;
            }
        }
        static void Merge_Sort(int[] tab, int lewo, int prawo)
        {
            if (lewo >= prawo)
            {
                return;
            }
            int srodek = lewo + (prawo - lewo) / 2;

            Merge_Sort(tab, lewo, srodek);
            Merge_Sort(tab, srodek + 1, prawo);

            Merge(tab, lewo, srodek, prawo);
        }
        static void Quick_Sort(int[] tab, int lewy, int prawy)
        {
            if (lewy > prawy)
            {
                return;
            }
            int i = lewy;
            int j = prawy;
            int privot = tab[(i + j) / 2];

            while (i <= j)
            {
                while (tab[i] < privot)
                {
                    i++;
                }
                while (tab[j] > privot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = tab[i];
                    tab[i] = tab[j];
                    tab[j] = temp;
                    i++;
                    j--;
                }
            }
            if (lewy < j)
            {
                Quick_Sort(tab, lewy, j);
            }
            if (prawy > i)
            {
                Quick_Sort(tab, i, prawy);
            }
        }
        static bool CzyPasujaca(char open, char close)
        {
            return ((open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']'));
        }
        static bool Sprawdzenie(string tekst)
        {
            Stack<char> stos = new Stack<char>();
            foreach (char c in tekst)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stos.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stos.Count == 0)
                    {
                        return false;
                    }
                    char nawias = stos.Pop();
                    if (!CzyPasujaca(nawias, c))
                    {
                        return false;
                    }
                }
            }
            return stos.Count == 0;
        }
        static void DFS(int[,] tab, int start)
        {
            int n = tab.GetLength(0);
            bool[] odwiedzony = new bool[n];
            Stack<int> stack = new Stack<int>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                int i = stack.Pop();
                if (!odwiedzony[i])
                {
                    odwiedzony[i] = true;
                    Console.WriteLine(i + " ");
                    for (int j = n - 1; j >= 0; j--)
                    {
                        if (tab[i, j] == 1 && !odwiedzony[j])
                        {
                            stack.Push(j);
                        }
                    }
                }
            }
            Console.WriteLine();
        }
        static void BFS(int[,] tab, int start)
        {
            int n = tab.GetLength(0);
            bool[] odwiedzony = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int i = queue.Dequeue();
                if (!odwiedzony[i])
                {
                    odwiedzony[i] = true;
                    Console.WriteLine(i + " ");
                    for (int j = 0; j < n; j++)
                    {
                        if (tab[i, j] == 1 && !odwiedzony[j])
                        {
                            queue.Enqueue(j);
                        }
                    }
                }
            }
            Console.WriteLine();
        }
        static void BFSrek(int[,] tab, int start)
        {
            int n = tab.GetLength(0);
            bool[] odwiedzona = new bool[n];
            DFSodw(tab, start, odwiedzona);

        }
        static void DFSodw(int[,] tab, int v, bool[] odwiedzona)
        {
            odwiedzona[v] = true;
            Console.Write(v + " ");
            for (int j = tab.GetLength(0) - 1; j >= 0; j--)
            {
                if (tab[v, j] == 1 && !odwiedzona[j])
                {
                    DFSodw(tab, j, odwiedzona);
                }
            }
        }
        public static int[] Djiksty(int[,] graf, int start)
        {
            int INF = int.MaxValue;
            int n = graf.GetLength(0);

            int[] odleglosci = new int[n];
            bool[] odwiedzone = new bool[n];

            for (int i = 0; i < n; i++)
            {
                odleglosci[i] = INF;
                odwiedzone[i] = false;
            }

            odleglosci[start] = 0;

            for (int i = 0; i < n; i++)
            {
                int u = -1;
                int minOdleglosc = INF;

                for (int j = 0; j < n; j++)
                {
                    if (!odwiedzone[j] && odleglosci[j] < minOdleglosc)
                    {
                        minOdleglosc = odleglosci[j];
                        u = j;
                    }
                }

                if (u == -1)
                {
                    break;
                }

                odwiedzone[u] = true;

                for (int v = 0; v < n; v++)
                {
                    if (!odwiedzone[v] && graf[u, v] != INF && odleglosci[u] != INF && odleglosci[u] + graf[u, v] < odleglosci[v])
                    {
                        odleglosci[v] = odleglosci[u] + graf[u, v];
                    }
                }
            }

            return odleglosci;
        }
        public static int[] Bellman_Ford(int[,] graf, int start)
        {
            int INF = int.MaxValue;
            int n = graf.GetLength(0);
            int[] odleglosci = new int[n];

            for (int i = 0; i < n; i++)
            {
                odleglosci[i] = INF;
            }

            odleglosci[start] = 0;

            for (int k = 0; k < n - 1; k++)
            {
                for (int u = 0; u < n; u++)
                {
                    for (int v = 0; v < n; v++)
                    {
                        if (graf[u, v] != INF && odleglosci[u] != INF && odleglosci[u] + graf[u, v] < odleglosci[v])
                        {
                            odleglosci[v] = odleglosci[u] + graf[u, v];
                        }
                    }
                }
            }

            for (int u = 0; u < n; u++)
            {
                for (int v = 0; v < n; v++)
                {
                    if (graf[u, v] != INF && odleglosci[u] != INF && odleglosci[u] + graf[u, v] < odleglosci[v])
                    {
                        throw new Exception("graf zawiera cykl ujemny");
                    }
                }
            }
            return odleglosci;
        }
        static void Main(string[] args)
        {
           /* Console.WriteLine(NWW(12, 18));
            int kwota = 299;
            int[] nominaly = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };

            var wynik = WydawanieResztZachlannie(kwota, nominaly);
            Console.WriteLine("Kwota do wydania: " + kwota);
            Console.WriteLine("Wydane nominaly:");
            foreach (var x in wynik)
            {
                Console.WriteLine(wynik);
            }*/
            Licznik_operacji licznikBubble = new Licznik_operacji(0, 0);
            Licznik_operacji licznikSelekt = new Licznik_operacji(0, 0);
            int[] tab1 = GenerateRandomArray(100, 1, 100);
            int[] tab2 = GenerateRandomArray(100, 1, 100);

            Sortowanie(tab1);
            bubbleSort(tab2);
            ElementListyDwukierunkowej lista = new ElementListyDwukierunkowej();
            lista.Dodaj(4);
            lista.Dodaj(8);
            lista.Dodaj(12);
            lista.Dodaj(5);
            lista.Dodaj(23);
            lista.Wypisz();
            lista.Usun(12);
            lista.Wypisz();
            Console.ReadKey();

            //
            BST tree = new BST();
            tree.Dodaj(5);
            tree.Dodaj(2);
            tree.Dodaj(8);
            tree.Dodaj(7);
            tree.Dodaj(6);
            Console.WriteLine(tree.CzyZawiera(8));

            tree.WypiszPreOrder();

            tree.WypiszInOrder();

            tree.WypishPostOrder();

            tree.WypiszPreOrderIter();
            Console.ReadKey();

            int[,] tab =
           {
               {0, 1, 0, 0, 0, 0, 1 },
               {1, 0, 1, 0, 0, 0, 0 },
               {0, 1, 0, 1, 1, 1, 0 },
               {0, 0, 1, 0, 0, 0, 0 },
               {0, 0, 1, 0, 0, 1, 0 },
               {0, 0, 1, 0, 1, 0, 0 },
               {1, 0, 0, 0, 0, 0, 0 }
            };
            DFS(tab, 5);
            Console.ReadKey();

            int INF = int.MaxValue;
            int[,] graf =
            {
                {0, 4, 1, INF, INF },
                {INF, 0, 2, 1, INF },
                {INF, INF, 0, 5, INF },
                {INF, INF, INF, 0, 3 },
                {INF, INF, INF, INF, 0 },
            };
            int start = 0;

            int[] odleglosci = Djiksty(graf, start);

            foreach (int u in odleglosci)
            {
                Console.WriteLine(u);
            }
            Console.ReadKey();

            //bellman ford
            int INFF = int.MaxValue;
            int startt = 0;
            int[,] graff =
            {//   s    A   B    C    D    E
                {INF, 10, INF, INF, INF, INF },//S
                {INF, INF, INF, 2, INF, INF },//A
                {INF, 1, INF, INF, INF, INF },//B
                {INF, INF, -2, INF, INF, INF },//C
                {INF, -4, INF, -1, INF, INF },//D
                {INF, INF, INF, INF, 1, INF },//E
                
            };
            int[] odlegloscii = Bellman_Ford(graf, start);

            foreach (int u in odleglosci)
            {
                Console.WriteLine(u);
            }
            Console.ReadKey();
        }
    }
}
