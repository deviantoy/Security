using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace laba1
{
    class TritemiusCipher
    {
        private List<char> pre_alphabet = new List<char>() { 'а', 'б', 'в', 'г', 'д', 'е', 'ё',
                                                             'ж', 'з', 'и', 'й', 'к', 'л', 'м',
                                                             'н', 'о', 'п', 'р', 'с', 'т', 'у',
                                                             'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
                                                             'ы', 'ь', 'э', 'ю', 'я', ',', '-',
                                                             ':', '(', '?', '.', ')', ' ', '!'};
        List<char> matrix = new List<char>();
        private string keyword = "";



        public string Encrypt(string text)
        {
            return Process(text, Mode.Encrypt);
        }
        public string Decrypt(string text)
        {
            return Process(text, Mode.Decrypt);
        }

        private string Process(string text, Mode mode)
        {
            int start_of_lower_line = matrix.Count - 7,
                end_of_lower_line   = matrix.Count - 1,
                start_of_upper_line = 0,
                end_of_upper_line   = 6;
            switch (mode)
            {
                case Mode.Encrypt:
                    string encrypted = "";

                    for (int cnt = 0; cnt < text.Length; cnt++)
                    {
                        if((byte)text[cnt] == 10 || (byte)text[cnt] == 13)
                        {
                            encrypted += text[cnt];
                            continue;
                        } 


                        int chIndex = matrix.IndexOf(text[cnt]);
                        if(chIndex >= start_of_lower_line && chIndex <= end_of_lower_line) // если это последняя строка
                        {
                            // здесь нужно заменять на символы из верхней строки
                            encrypted += matrix[chIndex - 35];
                            continue;
                        }
                        // здесь нужно заменить на символ под символом
                        encrypted += matrix[chIndex + 7];
                    }
                    return encrypted;

                case Mode.Decrypt:
                    string decrypted = "";
                    for (int cnt = 0; cnt < text.Length; cnt++)
                    {
                        if ((byte)text[cnt] == 10 || (byte)text[cnt] == 13)
                        {
                            decrypted += text[cnt];
                            continue;
                        }


                        int chIndex = matrix.IndexOf(text[cnt]);
                        if (chIndex >= start_of_upper_line && chIndex <= end_of_upper_line) // если это первая строка
                        {
                            // здесь нужно заменять на символы с самой нижней строки
                            decrypted += matrix[chIndex + 35];
                            continue;
                        }
                        // здесь нужно заменить на символ сверху
                        decrypted += matrix[chIndex - 7];
                    }

                    return decrypted;

                default: return "never will go on";
            }
        }

        public TritemiusCipher() { }

        public bool setKeyword(string key)
        {
            bool isGenerated = true;
            foreach(var ch in key)
            {
                if (!pre_alphabet.Contains(ch))
                    isGenerated = false;
                break;
            }
            if (isGenerated)
                GenerateMatrix(key);
            return isGenerated;
        }


        public int getAlphabetLenght()
        {
            return pre_alphabet.Count;
        }

        public char getCharFromAlphabet(int pos)
        {
            return pre_alphabet[pos];
        }
        public IEnumerable<char> getMatrix()
        {
            foreach (var ch in matrix)
                yield return ch;
        } 

        public bool inMatrix(char ch)
        {
            if (pre_alphabet.Contains(ch))
                return true;
            return false;
        }
        private void GenerateMatrix(string key)
        {
            keyword = new string(key.Distinct().ToArray()); // убираем повторения из слова
            matrix.Clear();

            keyword.ToList().ForEach((x) => { matrix.Add(x); });

            foreach (var ch in pre_alphabet)
            {
                if (matrix.Contains(ch)) 
                { 
                    continue;
                }
                matrix.Add(ch);
            }
        }

      

        enum Mode
        {
            Encrypt,
            Decrypt
        }
    }
}
