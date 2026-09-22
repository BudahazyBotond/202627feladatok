namespace HanoiTorony_lib
{
    public class Torony
    {
        public bool GameState { get; set; }
        public List<int> ToronyA { get; set; }
        public List<int> ToronyB { get; set; }
        public List<int> ToronyC { get; set; }
        private List<string> validTornyok = new List<string>();
        public int HanyKorong { get; init; }
        public Torony(int hanyKorong)
        {
            validTornyok.Add("a");
            validTornyok.Add("b");
            validTornyok.Add("c");
            GameState = true;
            HanyKorong = hanyKorong;
            ToronyA = new List<int>();
            ToronyB = new List<int>();
            ToronyC = new List<int>();
            for (int i = hanyKorong; i > 0; i--)
            {
                ToronyA.Add(i);
            }
        }
        public void Mozgat(string honnan, string hova)
        {
            if (honnan == hova || !validTornyok.Contains(hova) || !validTornyok.Contains(honnan))
            {
                return;
            }
            switch(honnan)
            {
                case "a":
                    if(ToronyA.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        switch (hova)
                        {
                            case "b":
                                ToronyB.Add(ToronyA.Last());
                                break;
                            case "c":
                                ToronyC.Add(ToronyA.Last());
                                break;
                        }
                        ToronyA.RemoveAt(ToronyA.Count-1);
                    }
                    break;
                case "b":
                    if (ToronyB.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        switch (hova)
                        {
                            case "a":
                                ToronyA.Add(ToronyB.Last());
                                break;
                            case "c":
                                ToronyC.Add(ToronyB.Last());
                                break;
                        }
                        ToronyB.RemoveAt(ToronyB.Count - 1);
                    }
                    break;
                case "c":
                    if (ToronyC.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        switch (hova)
                        {
                            case "b":
                                ToronyB.Add(ToronyC.Last());
                                break;
                            case "a":
                                ToronyA.Add(ToronyC.Last());
                                break;
                        }
                        ToronyC.RemoveAt(ToronyC.Count - 1);
                    }
                    break;
            }
        }
        public void WinCon()
        {
            bool isOver = true;
            if (ToronyC.Count == HanyKorong)
            {
                for (int i = 0; i < ToronyC.Count; i++)
                {
                        if(!(ToronyC[i] == HanyKorong-i))
                        {
                            isOver = false;
                        }
                }
                GameState = !isOver;
            }
        }

        public override string ToString()
        {
            List<string> stringBuilder = new List<string>();
            for (int i = HanyKorong; i > 0; i--)
            {
                string whatToAddA = (ToronyA.Count() >= i) ? ToronyA[i-1].ToString() : "x";
                string whatToAddB = (ToronyB.Count() >= i) ? ToronyB[i-1].ToString() : "x";
                string whatToAddC = (ToronyC.Count() >= i) ? ToronyC[i-1].ToString() : "x";
                stringBuilder.Add($"{whatToAddA}\t{whatToAddB}\t{whatToAddC}\t");
            }
            return string.Join("\n",stringBuilder);
        }
    }
}
