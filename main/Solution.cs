using System.Collections;
using System.Text;

public class Solution
{
    #region Questão 779 - HARD
    public static string CountOfAtoms(string formula)
    {
        #region Define Elements 
        ArrayList elements = new ArrayList();
        char str;
        for (int i = 0; i < formula.Length; i++)
        {
            str = formula[i];
            if (str == '(' || str == ')' || int.TryParse(str.ToString(), out int va))
                elements.Add(str);

            else if (str == char.ToUpper(str))
            {
                var element = new Element();
                element.Letter += str;

                while (true)
                {
                    ++i;
                    if (formula.Length > i)
                    {
                        str = formula[i];

                        if (int.TryParse(str.ToString(), out int result))
                            element.Value = int.Parse($"{element.Value}{result}");

                        else if (str == char.ToUpper(str) || (str == '(' || str == ')'))
                            break;

                        else if (str == char.ToLower(str))
                            element.Letter += str;
                    }
                    else
                        break;
                }

                --i;

                if (element.Value == 0)
                    element.Value = 1;

                elements.Add(element);
            }
        }
        #endregion

        int fisrstPL = 0;
        #region Calculate Elements v2 
        do
        {
            fisrstPL = elements.IndexOf('(');

            if (fisrstPL != -1)
                GetElementsToCalculate(elements, fisrstPL);

        } while (fisrstPL != -1);


        #endregion

        #region Reorganize Elements 
        List<Element> elementsList = elements.Cast<Element>().ToList();
        List<Element> elementsListReformed = new List<Element>();

        elementsList.ForEach(el =>
        {
            var elr = elementsListReformed.Find(prop => prop.Letter == el.Letter);

            if (elr is null)
                elementsListReformed.Add(el);
            else
                elr.Value += el.Value;
        });

        var query = elementsListReformed.OrderBy(x => x.Letter);
        #endregion

        var mont = string.Empty;
        foreach (var element in query)
        {
            mont += element is Element ? ((Element)element).View : element.ToString();
        }

        return mont;
    }

    private static void GetElementsToCalculate(ArrayList elements, int index)
    {
        for (int i = index + 1; i <= elements.Count; i++)
        {
            if (elements[i].ToString() == ")")
            {
                CalculateElements(elements, index, i);
                break;
            }
            else if (elements[i].ToString() == "(")
                GetElementsToCalculate(elements, i);
        }
    }

    private static void CalculateElements(ArrayList elements, int startIndex, int finalIndex)
    {
        int multiplierIndex = finalIndex + 1;
        int? multiplier = getMultiplier(elements, multiplierIndex);

        if (multiplier != null)
        {
            for (int i = startIndex; i <= finalIndex; i++)
            {
                if (elements[i] is Element)
                    ((Element)elements[i]).Value = ((Element)elements[i]).Value == 0 ? multiplier.Value : ((Element)elements[i]).Value * multiplier.Value;
            }

            elements.RemoveRange(multiplierIndex, multiplier.ToString().Length); //Remove Multiplier
        }

        elements.RemoveAt(finalIndex); //Remove )
        elements.RemoveAt(startIndex); //Remove (
    }

    private static int? getMultiplier(ArrayList elements, int multiplierRange)
    {
        string multiplierStr = string.Empty;

        while (elements.Count > multiplierRange && int.TryParse(elements[multiplierRange].ToString(), out int result))
        {
            multiplierStr += result;
            multiplierRange++;
        }

        return multiplierStr == string.Empty ? null : int.Parse(multiplierStr);
    }

    internal class Element
    {
        public string Letter { get; set; }

        public int Value { get; set; } = 0;

        public string View
        {
            get
            {
                var value = Value == 1 ? string.Empty : Value.ToString();
                return $"{Letter}{value}";
            }
        }
    }

    #region Best Awnser
    //using System.Text;

    //public class Solution
    //{
    //    private static int i;
    //    public static string CountOfAtoms(string formula)
    //    {
    //        StringBuilder ans = new StringBuilder();
    //        i = 0;
    //        var counts = CountOfAtoms(formula.ToCharArray());
    //        foreach (var name in counts.Keys)
    //        {
    //            ans.Append(name);
    //            int count = counts[name];
    //            if (count > 1) ans.Append(count);
    //        }
    //        return ans.ToString();
    //    }

    //    private static SortedDictionary<string, int> CountOfAtoms(char[] f)
    //    {
    //        var ans = new SortedDictionary<string, int>();
    //        while (i < f.Length)
    //        {
    //            if (f[i] == '(')
    //            {
    //                i++;
    //                var tmp = CountOfAtoms(f);
    //                int count = GetCount(f);
    //                foreach (var entry in tmp)
    //                {
    //                    if (ans.ContainsKey(entry.Key))
    //                    {
    //                        ans[entry.Key] += entry.Value * count;
    //                    }
    //                    else
    //                    {
    //                        ans[entry.Key] = entry.Value * count;
    //                    }
    //                }
    //            }
    //            else if (f[i] == ')')
    //            {
    //                i++;
    //                return ans;
    //            }
    //            else
    //            {
    //                string name = GetName(f);
    //                if (ans.ContainsKey(name))
    //                {
    //                    ans[name] += GetCount(f);
    //                }
    //                else
    //                {
    //                    ans[name] = GetCount(f);
    //                }
    //            }
    //        }
    //        return ans;
    //    }

    //    private static string GetName(char[] f)
    //    {
    //        StringBuilder name = new StringBuilder();
    //        name.Append(f[i++]);
    //        while (i < f.Length && char.IsLower(f[i]))
    //        {
    //            name.Append(f[i++]);
    //        }
    //        return name.ToString();
    //    }

    //    private static int GetCount(char[] f)
    //    {
    //        int count = 0;
    //        while (i < f.Length && char.IsDigit(f[i]))
    //        {
    //            count = count * 10 + (f[i] - '0');
    //            i++;
    //        }
    //        return count == 0 ? 1 : count;
    //    }
    //}
    #endregion

    #endregion


    #region Questão
    #endregion

    #region Questão
    #endregion

    #region Questão
    #endregion

    #region Questão
    #endregion

    #region Questão
    #endregion
}


