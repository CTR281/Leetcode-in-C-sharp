namespace Leetcode
{
    public class MainClass
    {
        static void Main()
        {
            // Instantiate problem classes here
            CloseStrings.Solution closeStrings = new CloseStrings.Solution();
            Console.WriteLine(closeStrings.CloseStrings("cabbb", "abbccc"));
        }
    }
}
