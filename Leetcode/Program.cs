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

            DivideArray problem = new DivideArray();
            Console.WriteLine(problem.test.RunTests());
        }
    }
}
