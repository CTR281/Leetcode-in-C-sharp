using Leetcode.problems;

namespace Leetcode
{
    public class MainClass
    {
        static void Main()
        {
            // Instantiate problem classes here
            CloseStrings.Solution closeStrings = new CloseStrings.Solution();
            Console.WriteLine(closeStrings.CloseStrings("cabbb", "abbccc"));

/*            SequentialDigits sequentialDigits = new SequentialDigits(new SequentialDigits.Solution());
            Console.WriteLine(sequentialDigits.ExecuteTests());*/

/*            DivideArray divideArray = new DivideArray(new DivideArray.Solution());
            Console.WriteLine(divideArray.ExecuteTests());*/

            GroupAnagrams.Solution3 groupAnagrams = new GroupAnagrams.Solution3();
            groupAnagrams.GroupAnagrams(new string[] { "bdddddddddd", "bbbbbbbbbbc" });

/*            Rob rob = new Rob(new Rob.Solution());
            Console.WriteLine(rob.ExecuteTests());*/
        }
    }
}
