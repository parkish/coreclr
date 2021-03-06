using System;
using System.Globalization;
/// <summary>
///MoveNext
/// </summary>
public class TextElementEnumeratorMoveNext
{
    public static int Main()
    {
        TextElementEnumeratorMoveNext TextElementEnumeratorMoveNext = new TextElementEnumeratorMoveNext();
        TestLibrary.TestFramework.BeginTestCase("TextElementEnumeratorMoveNext");
        if (TextElementEnumeratorMoveNext.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Calling MoveNext method.");
        try
        {
            // Creates and initializes a String containing the following:
            //   - a surrogate pair (high surrogate U+D800 and low surrogate U+DC00)
            //   - a combining character sequence (the Latin small letter "a" followed by the combining grave accent)
            //   - a base character (the ligature "")
            String myString = "\uD800\uDC00\u0061\u0300\u00C6";
            string[] expectValue = new string[5];
            expectValue[0] = "\uD800\uDC00";
            expectValue[1] = "\uD800\uDC00";
            expectValue[2] = "\u0061\u0300";
            expectValue[3] = "\u0061\u0300";
            expectValue[4] = "\u00C6";
            // Creates and initializes a TextElementEnumerator for myString.
            TextElementEnumerator myTEE = StringInfo.GetTextElementEnumerator(myString);
            myTEE.Reset();
            string acutalValue = null;
            int i = 0;
            while (myTEE.MoveNext())
            {
                acutalValue = myTEE.GetTextElement();
                if (acutalValue != expectValue[myTEE.ElementIndex])
                {
                    TestLibrary.TestFramework.LogError("001." + (i + 1).ToString(), " after Calling MoveNext, GetTextElement method should return " + expectValue[i]);
                    retVal = false;
                    i++;
                }
               
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
   
   
}

