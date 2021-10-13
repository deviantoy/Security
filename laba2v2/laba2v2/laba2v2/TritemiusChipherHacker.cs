using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Numerics;

namespace laba2v2
{
    class TritemiusChipherHacker
    {
        private ListView _listView;

        public List<int> _attempts { get; set; }
        public List<int> _keyLength { get; set; }

        private List<char> _alphabet = new List<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ё',
                                                          'ж', 'з', 'и', 'й', 'к', 'л', 'м',
                                                          'н', 'о', 'п', 'р', 'с', 'т', 'у',
                                                          'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
                                                          'ы', 'ь', 'э', 'ю', 'я', ',', '-',
                                                          ':', '(', '?', '.', ')', ' ', '!' };
        private List<string> _dict = new List<string>();

        private string _textToHack = "";
        public string hackedText = "";
        public bool workDone = false;
        private bool _cancel = false;


        private int keyWordSize = Settings.sizeOfKeyword; // размер ключа
        private ulong attempt = 1; // Количество попыток

        public TritemiusChipherHacker()
        {
            _attempts = new List<int>();
            _keyLength = new List<int>();
        }

        public TritemiusChipherHacker(ListView listView)
        {
            _listView = listView;
        }


        public void setListView(ListView lst) { _listView = lst; }
        public void setDict(List<string> dict) { _dict = dict; }
        public void setText(string text) { _textToHack = text.Replace('\n', '\0').Replace('\r','\0'); }
        public void setCancel(bool cancel) { _cancel = cancel; }

        public void UpdateInfo() { SaveDataForGraph((int)attempt, keyWordSize); }

        public void Start()
        {
            string result = String.Empty;

            int upperLineLeft = 0,
                upperLineRight = 6;

            List<char> curAlphabet = new List<char>();
            List<string> words = new List<string>();

            StringBuilder sb = new StringBuilder();
            foreach (var c in _alphabet)
                sb.Append(c);


            startPoint:
            List<string> curPossibleKeywords = Combinations(keyWordSize, sb.ToString());
            SaveDataForGraph((int)attempt, keyWordSize);

            foreach (var keyword in curPossibleKeywords)
            {
                if (_cancel)
                {
                    SaveDataForGraph((int)attempt, keyWordSize);
                    attempt = 0;
                    return;
                }

                #region CreateAlphabet

                curAlphabet.AddRange(keyword.ToCharArray());
                _alphabet.ForEach((x) => { if (!curAlphabet.Contains(x)) { curAlphabet.Add(x); } });

                StringBuilder sb1 = new StringBuilder();
                foreach (var ch in curAlphabet)
                {
                    sb1.Append(ch);
                }
                #endregion

                #region ReadText

                for (int chIndex = 0; chIndex < _textToHack.Length; chIndex++)
                {
                    if ((byte)_textToHack[chIndex] == 0)
                        continue;

                    int curChIndex = curAlphabet.IndexOf(_textToHack[chIndex]); // индекс текущего символа
                    char curCh;
                    if (curChIndex >= upperLineLeft && curChIndex <= upperLineRight) // если верхняя строка
                    {
                        curCh = curAlphabet[curChIndex + 35]; // самая верхняя строка
                    }
                    else
                    {
                        curCh = curAlphabet[curChIndex - 7]; // на строку нихе
                    }
                    result += curCh;
                }
                #endregion

                #region Check For Collisions In dict

                words = result.Split(' ').ToList();
                int goodWord = 0;

                foreach (var trueWord in _dict)
                    if (words.Contains(trueWord))
                        goodWord++;

                if (goodWord < 5)
                {
                    result = String.Empty;
                    goodWord = 0;
                    words.Clear();
                    curAlphabet.Clear();
                }
                else
                {
                    hackedText = result;
                    AddItemToListView(attempt, DateTime.Now, $"Ключевое слово {keyword} подошло!");
                    SaveDataForGraph((int)attempt, keyWordSize);
                    workDone = true;
                    return;
                }
                AddItemToListView(attempt, DateTime.Now, $"Ключевое слово {keyword} не подходит!");
                attempt++; // следующая попытка
                #endregion
            }
            keyWordSize++;
            goto startPoint;
        }


        private void SaveDataForGraph(int att, int size)
        {
            _attempts.Add((int)att);
            _keyLength.Add(size);
        }

        static List<string> Combinations(int length, string chars)
        {
            string result = String.Empty;
            List<string> resChars = new List<string>();
            int[] index = new int[length];
            bool work = true;
            ulong cnt = 0;
            while (work)
            {
                foreach (int i in index)
                    result += chars[i];
                resChars.Add(result);
                result = String.Empty;
                index[index.Length - 1]++;

                
                for (int i = (index.Length - 1); i >= 0; i--)
                {
                    cnt++;
                    if (index[i] > (chars.Length - 1))
                    {
                        index[i] = 0;
                        if (--i < 0)
                        {
                            work = false;
                            break;
                        }
                        index[i]++;
                        i++;
                    }
                }
            }
            //MessageBox.Show($"{cnt}");
            return RemoveDups(resChars);
        }



        private static List<string> RemoveDups(List<string> keys)
        {
            List<string> result = new List<string>();
            foreach (string s in keys)
                result.Add(string.Join("", s.ToHashSet()));

            return result;
        }

        

        private static void CopyList(ref List<string> first, List<string> second)
        {
            foreach (var item in second)
                first.Add(item);
        }

        private void AddItemToListView(ulong attempt, DateTime dt, string _event)
        {
            ListViewItem item = new ListViewItem(new string[] { attempt.ToString(), dt.ToShortTimeString(), _event });
            _listView.Invoke(new Action(() => _listView.Items.Add(item)));
            _listView.Invoke(new Action(() => _listView.TopItem = item));
        }
    }
}
