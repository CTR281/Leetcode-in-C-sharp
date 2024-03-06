using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.extensions;

namespace Leetcode.models
{
    internal class TestCase
    {
        private IList<object> inputParameters;  // TODO: use interface ? or get by reflexivity
        private object expectedOutput; // TODO: use interface ?

        public IList<object> InputParameters { get { return inputParameters; } }
        public object ExpectedOutput { get { return expectedOutput; } }

        public TestCase(string userInput, IList<Type> argTypes)
        {
            parseTestCase(userInput, argTypes, out inputParameters, out expectedOutput);
        }

        // inputParameters: [1, [3, 4, 5], true]
        // expectedOutput: [1, 2, 3] || true || 1
        // testCase: [
        //  [1, [3, 4, 5], true],
        //  [1, 2, 3]
        // ]
        // testCases: [
        //  [
        //      [1, [3, 4, 5], true],
        //      [1, 2, 3]
        //  ],
        //  [
        //      [1, [3, 4, 5], true],
        //      [1, 2, 3]
        //  ]
        // ]
        // userInput: [[1, [3, 4, 5], true], [1, 2, 3]]
        private static dynamic ParseText(string text, IEnumerator<Type> argTypes) // TODO ParseText<T> ? invoked with reflection ? https://stackoverflow.com/questions/232535/how-do-i-call-a-generic-method-using-a-type-variable
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text)) return text;
            if (text[0] == '[')
            {
                List<dynamic> res = new(); // would become List<T>
                int argStart = 1;
                int openBrackets = 0;
                for (int k = 0; k < text.Length; k++)
                {
                    char c = text[k];
                    switch (c)
                    {
                        case '[':
                            {
                                openBrackets++;
                                break;
                            }
                        case ']':
                            {
                                openBrackets--;
                                if (openBrackets == 0)
                                {
                                    res.Add(ParseText(text.Substring(argStart, k - argStart), argTypes));
                                }
                                break;
                            }
                        case ',':
                            {
                                if (openBrackets == 1)
                                {
                                    res.Add(ParseText(text.Substring(argStart, k - argStart), argTypes));
                                    argStart = k + 1;
                                }
                                break;
                            }
                        default: continue;
                    }
                }
                Type type = argTypes.Current.GetGenericArguments().Length > 0 ? argTypes.Current.GetGenericArguments()[0] : argTypes.Current.GetElementType();
                argTypes.MoveNext();
                return type == typeof(object) || type is null ? res.ToArray() : res.ConvertAll(x => Convert.ChangeType(x, type)).ToArray();
            }
            else
            {
                /*                if (bool.TryParse(text, out bool boolean)) return boolean;
                                if (int.TryParse(text, out int num)) return num;
                                return text;*/
                Type type = argTypes.Current.GetGenericArguments().Length > 0 ? argTypes.Current.GetGenericArguments()[0] : argTypes.Current.GetElementType() is not null ? argTypes.Current.GetElementType() : argTypes.Current;
                dynamic res = Convert.ChangeType(text, type);
                return res;
            }
        }
        public void parseTestCase(string userInput, IList<Type> argTypes, out IList<object> inputParameters, out object expectedOutput)
        {
            IEnumerator<Type> argTypesEnumerator = argTypes.GetEnumerator();
            argTypesEnumerator.MoveNext();
            object[] parsedText = (object[])ParseText(userInput, argTypesEnumerator) ?? throw new Exception("Test case is malformed. It should be a list of 2 elements.");
            if (parsedText.Length == 0) throw new Exception("Test case is malformed.");
            inputParameters = (object[])parsedText[0] ?? throw new Exception("Could not parse input params.");
/*            if (inputParameters is IList<object>)
            {
                int b = 0;
                inputParameters[0] = ((IList<object>)inputParameters[0]).Select(x => ((IList<object>)x).Select(y => (int)y).ToArray()).ToArray();
            }
            inputParameters = inputParameters.Select(arg =>
            {
                if (arg is IList<object>) return ((object[])arg).Cast<int>().ToArray();
                return arg;
            }).ToArray();*/
            expectedOutput = parsedText[1];
/*            if (expectedOutput is IList<object>)
            {
                int b = 0;
                expectedOutput = ((IList<object>)expectedOutput).Select(x => ((IList<object>)x).Select(y => (int)y).ToArray()).ToArray();
            }*/
            int a = 0;
        }
    }
}
