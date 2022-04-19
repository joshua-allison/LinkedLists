using System;
using TextClassNamespace;

namespace Driver
{
    class Driver
    {
        static void Main(string[] args)
        {
            //// Uncomment test functions to run

            //// basic tests
            //TestHead();
            //TestTail();
            //TestQueue();
            //TestDisplay();
            //TestFind();
            //TestFindRemove();

            //// advanced tests
            //TestAppend();
            
            //TestFindNext();
            //TestRemoveLast();
            //TestInsertLast();
            //TestMixed();

            //// thinking test
            TestThink();


            Console.Write("Press Enter to exit console");
            Console.Read();
        }

        // basic tests     
        static void TestHead()
        {
            Console.Write("Testing adding and removing from Head\n\n");
            const int ADD_HEAD = 5;
            char[] heads = new char[ADD_HEAD] { 'a', 'b', 'c', 'd', 'e' };

            TextClass head = new TextClass();
            Console.Write("Adding five letters to Head of list\n");
            for (int i = 0; i < ADD_HEAD; i++)
            {
                head.AddHead(heads[i]);
            }
            Console.Write(" removing and displaying them\n");
            Console.Write(" expected e d c b a\n");
            Console.Write(" actually ");
            for (int i = 0; i < ADD_HEAD; i++)
            {
                Console.Write(head.GetHead() + " ");
                head.RemoveHead();
            }
            Console.Write("\n\n");

            Console.Write("Now reading an extra value \n");
            try
            {
                head.GetHead();
                Console.Write(" should have thrown an exception\n");
            }
            catch (InvalidOperationException ex)
            {
                Console.Write("Caught InvalidOperationException saying " + ex.Message + "\n");
            }
            catch (Exception)
            {
                Console.Write("Caught something unexpected\n");
            }

            Console.Write("Done testing adding and removing from Head\n\n");
        }

        static void TestTail()
        {
            Console.Write("Testing adding and removing from tail\n\n");
            const int ADD_TAIL = 5;
            char[] tails = new char[ADD_TAIL] { 'z', 'y', 'x', 'w', 'v' };

            TextClass tail = new TextClass();
            Console.Write("Adding five letters to tail of list\n");
            for (int i = 0; i < ADD_TAIL; i++)
            {
                tail.AddTail(tails[i]);
            }
            Console.Write(" removing and displaying them\n");
            Console.Write(" expected v w x y z\n");
            Console.Write(" actually ");
            for (int i = 0; i < ADD_TAIL; i++)
            {
                Console.Write(tail.GetTail() + " ");
                tail.RemoveTail();
            }
            Console.Write("\n\n");

            Console.Write("Now getting an extra value \n");
            try
            {
                tail.GetTail();
                Console.Write(" should have thrown an exception\n");
            }
            catch (InvalidOperationException ex)
            {
                Console.Write("Caught InvalidOperationException saying " + ex.Message + "\n");
            }
            catch (Exception)
            {
                Console.Write("Caught something unexpected\n");
            }

            Console.Write("Done testing adding and removing from tail\n\n");
        }

        static void TestQueue()
        {
            Console.Write("Testing queue both ways\n\n");
            const int FIFO = 5;
            char[] headFifo = new char[FIFO] { 'A', 'C', 'E', 'G', 'I' };
            char[] tailFifo = new char[FIFO] { 'M', 'N', 'O', 'P', 'Q' };

            TextClass fifo1 = new TextClass();
            Console.Write("Adding five letters to tail of list\n");
            for (int i = 0; i < FIFO; i++)
            {
                fifo1.AddTail(headFifo[i]);
            }
            Console.Write(" removing from Head and displaying them\n");
            Console.Write(" expected A C E G I\n");
            Console.Write(" actually ");
            for (int i = 0; i < FIFO; i++)
            {
                Console.Write(fifo1.GetHead() + " ");
                fifo1.RemoveHead();
            }
            Console.Write("\n\n");

            TextClass fifo2 = new TextClass();
            Console.Write("Adding five letters to Head of list\n");
            for (int i = 0; i < FIFO; i++)
            {
                fifo2.AddHead(tailFifo[i]);
            }
            Console.Write(" removing from tail and displaying them\n");
            Console.Write(" expected M N O P Q\n");
            Console.Write(" actually ");
            for (int i = 0; i < FIFO; i++)
            {
                Console.Write(fifo2.GetTail() + " ");
                fifo2.RemoveTail();
            }
            Console.Write("\n\n");

            Console.Write("Done testing queue both ways\n\n");
        }

        static void TestDisplay()
        {
            Console.Write("Testing display list\n\n");
            const int DISPLAY = 6;
            char[] displays = new char[DISPLAY] { 's', 'p', 'r', 'u', 'c', 'e' };


            TextClass display = new TextClass();
            Console.Write("Adding six letters to tail of list\n");
            for (int i = 0; i < DISPLAY; i++)
            {
                display.AddTail(displays[i]);
            }
            Console.Write(" displaying them Head to tail\n");
            Console.Write(" expected s p r u c e\n");
            Console.Write(" actually " + display.DisplayList() + "\n\n");

            Console.Write("Done testing display list\n\n");
        }

        static void TestFind()
        {
            Console.Write("Testing Find\n\n");
            const int FIND = 5;
            char[] vowels = new char[FIND] { 'a', 'e', 'i', 'o', 'u' };

            TextClass findTail = new TextClass();
            Console.Write("Adding five vowels to tail of a list\n");
            for (int i = 0; i < FIND; i++)
            {
                findTail.AddTail(vowels[i]);
            }
            Console.Write(" displaying them\n");
            Console.Write(" expected a e i o u\n");
            Console.Write(" actually " + findTail.DisplayList() + "\n");

            Console.Write("  e " + (findTail.Find('e') ? "is" : "is not") + " there\n");
            Console.Write("  x " + (findTail.Find('x') ? "is" : "is not") + " there" + "\n\n");

            TextClass findHead = new TextClass();
            Console.Write("Adding five vowels to Head of a list\n");
            for (int i = 0; i < FIND; i++)
            {
                findHead.AddHead(vowels[i]);
            }
            Console.Write(" displaying them\n");
            Console.Write(" expected u o i e a\n");
            Console.Write(" actually " + findHead.DisplayList() + "\n");

            Console.Write("  a " + (findHead.Find('a') ? "is" : "is not") + " there\n");
            Console.Write("  r " + (findHead.Find('r') ? "is" : "is not") + " there" + "\n\n");

            Console.Write("Done testing Find\n\n");
        }

        static void TestFindRemove()
        {
            Console.Write("Testing Find and remove\n\n");
            const int FIND_REM = 5;
            char[] digits = new char[FIND_REM] { '1', '3', '5', '7', '9' };

            TextClass findRem = new TextClass();
            Console.Write("Adding five digits to tail of a list\n");
            for (int i = 0; i < FIND_REM; i++)
            {
                findRem.AddTail(digits[i]);
            }
            Console.Write(" displaying them\n");
            Console.Write(" expected 1 3 5 7 9\n");
            Console.Write(" actually " + findRem.DisplayList() + "\n");

            Console.Write("  3 " + (findRem.FindRemove('3') ? "is" : "is not") + " there\n");
            Console.Write("  6 " + (findRem.FindRemove('6') ? "is" : "is not") + " there\n");

            Console.Write(" displaying them after remove\n");
            Console.Write(" expected 1 5 7 9\n");
            Console.Write(" actually " + findRem.DisplayList() + "\n\n");

            Console.Write("Now testing Find/remove Head and tail\n");
            Console.Write("  1 " + (findRem.FindRemove('1') ? "is" : "is not") + " there\n");
            Console.Write("  9 " + (findRem.FindRemove('9') ? "is" : "is not") + " there\n");
            Console.Write(" displaying them after remove\n");
            Console.Write(" expected 5 7\n");
            Console.Write(" actually " + findRem.DisplayList() + "\n\n");

            Console.Write("Done testing Find and remove\n\n");
        }

        // advanced tests
        static void TestAppend()
        {
            Console.Write("Testing Appending a list\n\n");
            const int APPEND1 = 6;
            const int APPEND2 = 7;
            int counter = 0;
            char[] AppendVals = new char[APPEND1 + APPEND2] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm' };

            TextClass first = new TextClass();
            for (int i = 0; i < APPEND1; i++)
            {
                first.AddTail(AppendVals[counter]);
                counter++;
            }
            TextClass second = new TextClass();
            for (int i = 0; i < APPEND2; i++)
            {
                second.AddTail(AppendVals[counter]);
                counter++;
            }

            Console.Write("First list is " + first.DisplayList() + "\n");
            Console.Write("Second list is " + second.DisplayList() + "\n");


            //I know I'm not supposed to alter the driver, but the code belowe with the ref keyword would not work and VS would not explain why.
            //first.Append(ref second);
            first.Append(ref second);
            Console.Write("First should now be a b c d e f g h i j k l m\n");
            Console.Write(" and it actually is " + first.DisplayList() + "\n");

            Console.Write("Done Appending a list\n\n");
        }

        static void TestFindNext()
        {
            Console.Write("Testing Find next\n\n");
            const int FIND_NEXT = 5;
            char[] nextVals = new char[FIND_NEXT] { 'a', 'p', 'p', 'l', 'e' };

            TextClass nextFind = new TextClass();
            for (int i = 0; i < FIND_NEXT; i++)
            {
                nextFind.AddTail(nextVals[i]);
            }

            Console.Write("List contains " + nextFind.DisplayList() + "\n");
            Console.Write("Looking for a, e, p, p, k, a\n");
            Console.Write(" a " + (nextFind.FindNext('a') ? "found" : "not found") + "\n");
            Console.Write(" e " + (nextFind.FindNext('e') ? "found" : "not found") + "\n");
            Console.Write(" p " + (nextFind.FindNext('p') ? "found" : "not found") + "\n");
            Console.Write(" p " + (nextFind.FindNext('p') ? "found" : "not found") + "\n");
            Console.Write(" k " + (nextFind.FindNext('k') ? "found" : "not found") + "\n");
            Console.Write(" a " + (nextFind.FindNext('a') ? "found" : "not found") + "\n");

            Console.Write("Done testing Find next\n\n");
        }

        static void TestRemoveLast()
        {
            Console.Write("Testing remove last\n\n");
            const int REM_LAST = 7;
            char[] removeVals = new char[REM_LAST] { 'b', 'e', 'a', 'r', 'd', 'e', 'd' };

            TextClass remLast = new TextClass();
            for (int i = 0; i < REM_LAST; i++)
            {
                remLast.AddTail(removeVals[i]);
            }

            Console.Write("List contains " + remLast.DisplayList() + "\n");
            Console.Write("Looking to remove first d after wrapping\n");
            Console.Write(" first d " + (remLast.FindNext('d') ? "found" : "not found") + "\n");
            Console.Write(" second d " + (remLast.FindNext('d') ? "found" : "not found") + "\n");
            Console.Write(" first d again " + (remLast.FindNext('d') ? "found" : "not found") + "\n");
            remLast.RemoveLast();
            Console.Write("List should now be b e a r e d\n");
            Console.Write(" and it is " + remLast.DisplayList() + "\n");
            Console.Write("Looking to remove second e\n");
            Console.Write(" e " + (remLast.FindNext('e') ? "found" : "not found") + "\n");
            Console.Write(" e " + (remLast.FindNext('e') ? "found" : "not found") + "\n");
            remLast.RemoveLast();
            Console.Write("Doing an extra remove, should do nothing\n");
            remLast.RemoveLast();
            Console.Write("Displaying after removes\n");
            Console.Write(" expected b e a r d\n");
            Console.Write(" actually " + remLast.DisplayList() + "\n\n");

            Console.Write("Done testing remove last\n\n");
        }

        static void TestInsertLast()
        {
            Console.Write("Testing insert last\n\n");
            const int INSERT_LAST = 4;
            char[] insertVals = new char[INSERT_LAST] { '1', '3', '7', '9' };

            TextClass insLast = new TextClass();
            for (int i = 0; i < INSERT_LAST; i++)
            {
                insLast.AddTail(insertVals[i]);
            }

            Console.Write("List contains " + insLast.DisplayList() + "\n");
            Console.Write("Looking to insert 4, 5, and 6 in sequence\n");
            Console.Write(" first Finding 7 " + (insLast.FindNext('7') ? "found" : "not found") + "\n");
            insLast.InsertLast('5');
            insLast.InsertLast('6');
            Console.Write(" now Finding 5 " + (insLast.FindNext('5') ? "found" : "not found") + "\n");
            insLast.InsertLast('4');
            Console.Write(" displaying result, expected 1 3 4 5 6 7 9\n");
            Console.Write(" actually have " + insLast.DisplayList() + "\n\n");

            Console.Write("Done testing insert last\n\n");
        }

        static void TestMixed()
        {
            Console.Write("Testing mixed inserts and deletes\n\n");
            const int MIX = 3;
            const int MIXED = 4;
            char[] mixLetters = new char[MIX] { 'c', 'a', 'w' };

            TextClass mixed = new TextClass();
            for (int i = 0; i < MIX; i++)
            {
                mixed.AddTail(mixLetters[i]);
            }

            Console.Write("List starts with " + mixed.DisplayList() + "\n");
            Console.Write(" replacing a with o and adding r\n");
            mixed.FindNext('a');
            mixed.InsertLast('o');
            mixed.RemoveLast();
            mixed.FindNext('o');
            mixed.InsertLast('r');
            Console.Write(" caw should now be crow \n");
            Console.Write(" and it is ");
            for (int i = 0; i < MIXED; i++)
            {
                Console.Write(mixed.GetHead());
                mixed.RemoveHead();
            }
            Console.Write("\n\n");

            Console.Write("Done testing mixed inserts and deletes\n\n");
        }

        // thinking test
        static void TestThink()
        {
            Console.Write("Testing thinking solution\n\n");
            const int CAT = 13;
            const int DOG = 13;
            char[] catLetters = new char[CAT] { 'T', 'h', 'i', 's', ' ', 'i', 's', ' ', 'a', ' ', 'c', 'a', 't' };
            char[] dogLetters = new char[DOG] { 'T', 'h', 'i', 's', ' ', 'i', 's', ' ', 'a', ' ', 'd', 'o', 'g' };

            // create two TextClass objects,
            // one with catLetters
            TextClass LettersOfCat = new TextClass();
            foreach (char letter in catLetters)
                LettersOfCat.AddTail(letter);
            // and one with dogLetters
            TextClass LettersOfDog = new TextClass();
            foreach (char letter in dogLetters)
                LettersOfDog.AddTail(letter);

            // append the dogLetters list to the catLetters list
            LettersOfCat.Append(ref LettersOfDog);

            // edit the result

            // when done display the two lists
            Console.Write("Expected updated catList output: This is a cat and that is a dog\n");
            Console.WriteLine("Actual updated catList output:" + LettersOfCat.DisplayList() + "\n");
            Console.Write("Expected dogList output: This is a dog\n");
            Console.WriteLine("Expected dogList output:" + LettersOfDog.DisplayList() + "\n");

            Console.Write("Done testing thinking solution\n\n");
        }
    }
}

