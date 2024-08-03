using WordFinderChallenge;

namespace WordFinderTests
{
    [TestClass]
    public class WordFinderTests
    {
        [TestMethod]
        public void TestInitializationWithValidMatrix()
        {
            IEnumerable<string> matrix = ["abcdc", "fgwio", "chill", "pqnsd", "uvdxy"];
            WordFinder wordFinder = new(matrix);
            Assert.IsNotNull(wordFinder);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrix1()
        {
            //matrix with not all words with the same Length
            IEnumerable<string> matrix = ["abcdc", "fgwio", "chill", "pqnsd", "uvd"];
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrix2()
        {
            //matrix empty
            IEnumerable<string> matrix = [];
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrix3()
        {
            //matrix null
            IEnumerable<string> matrix = null;
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrix4()
        {
            //matrix with more than 64 columns
            IEnumerable<string> matrix = ["abcdcertyujighfjdnsowrithskftokeortgdwoktifrjethsjerigrolawpmjerg"];
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrix5()
        {
            //matrix with more than 64 rows
            IEnumerable<string> matrix = ["a","b","c","d","c","e","r","t","y","u","j","i","g","h","f","j","d","n","s","o","w","r",
                                          "i","t","h","s","k","f","t","o","k","e","o","r","t","g","d","w","o","k","t","i","f","r",
                                          "j","e","t","h","s","j","e","r","i","g","r","o","l","a","w","p","m","j","e","r","g"];
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        public void TestFindWords1()
        {
            //matrix 7x5
            IEnumerable<string> matrix = ["abcdc", "fgwio", "chill", "pqnsd", "uvdxy", "lkioe", "qwert"];
            var wordFinder = new WordFinder(matrix);
            IEnumerable<string> wordStream = ["cold", "wind", "snow", "chill"];
            var foundWords = wordFinder.Find(wordStream).ToList();
            CollectionAssert.AreEqual(new List<string> { "cold", "wind", "chill"}, foundWords);
        }

        [TestMethod]
        public void TestFindWords2()
        {
            //matrix 40x40
            //Words present in the Matrix: wind(5), cold(4), chill(4), snow(3), square(3), letter(3), house(2), circle(2),
            //                             sun(2), storm(2), car(1), bike(1), dog(1), cat(1), smile(1), wonderful(1),
            //                             happy(1), amazing(1)
            IEnumerable<string> matrix = ["fcokuoxnbzqktvrhrusajljwmjllqujmltvbilgl","omzawstqqnxpbbehxuwcprlkqeagtjaykogavnjs",
                                          "bygjukaihhtkmguvjjyhlpdsahqcagdlkkthtnxq","nbkghhcunxahffksaqjifqruibwpaqtgsknsdmhu",
                                          "xnttpeamgbfdzqsmprvlphlnpocdpxhbdyysooaa","movaxvlrugehttviwaelmnnrsunjncdficyxxtwr",
                                          "pugeimlhdrutnmtlaibfyhaaccqmszrcjhkttlde","zyyokdzhqsmvksnesvdbyoasgoiobqfbfpmumjpc",
                                          "gqvxjxiyrxnkyfbppegxxalehlkhxmufxvchkeum","vrbqzipzlrxlbaotlelhtslyidcnnclwoitiyrfn",
                                          "mxdrohvuauqapcosbttyxsqgpkujhbfrwvritunk","udrymlmaleuvihwlfmclttpklzdllzvxusxutrvw",
                                          "pdocuffwlaipqynelioszoohcrjxoqjjkcofbqmu","squareihbwnkpmktrwldmrilmrnuosiggkkyccov",
                                          "tyhlesqkhzbkbywtxvdqamgkiabvrihngkrzsglw","vdogkxwwmngdutiewdatfaigcwggsuqyndlftdeh",
                                          "iauzhfyilfiszdnrutfvqhnqpenrsnvrfoahadtj","umsojhtnoxspradfbgkandpgmeutikqqogukhxta",
                                          "zeebcamdlaqgwbjkhghjexcusnowhpgdotezjhet","wvwaiwilfuscosnowkpcjkpfawwbjadxxexnnirb",
                                          "ygfprxyqrsyddnzotrbvqabxleiywkdfdjfeczgq","fltbcjkevfiskobbsoontlziauneutnjeczgtvps",
                                          "hultlqqtocgeawwaizibikegrodtzxnobcscholc","asltevebyduopboielrzytcatsamazfzxwoyzjux",
                                          "bndwckrncxsjmufngrrgqdquesmhhtfgcfjocjoz","fdapoudmybuauemorkrcscxstormndrxcgcaolyj",
                                          "pguewonderfulxhupcarzcaaxrrhomzksuzmseyk","onsdocmwindtnvrerweokhkvwnqejquinxqalitg",
                                          "knlgivdlechsbrcpeiwliihjobigaxrdtvezfpgv","pjhblcwceuwuhphpuzwexlruxbvsgprmtuyicfum",
                                          "xrwwjolpidtgemihvmgcoldplxekaedifdhnoznb","xsiillwxkvkevnlbvbxinmnvspfwzonawgsgshzp",
                                          "tnhnpdxlckzigolqvztpdopfggmcpeqhkfjpwrkf","sdqdeuolettervpepordclvezujblpeajnigbhlw",
                                          "sacamojszejbzpcrspnxihhikgvjbzrqyjjemajo","mqvrtmoosdotuuvrmygbrooymkqqyfsufaaanpfn",
                                          "loqxloifchillkoajxtycfucslnjdeowbikkxpqs","tvlwoinbnnwyxgvwtnxglosppyrockfwazeqdyac",
                                          "sverqbpiobjqsjpnwvblegeytfpqsosquarezkbg","ibuimtzszyjgzlwnivwlgwyproauuqudfeffdoph"];
            var wordFinder = new WordFinder(matrix);
            IEnumerable<string> wordStream = ["cold", "wind", "snow", "chill", "house", "square", "circle", "letter", "sun", "storm",
                                              "car", "bike", "dog", "cat", "smile", "wonderful", "happy", "amazing", "great", "pencil"];
            var foundWords = wordFinder.Find(wordStream).ToList();
            CollectionAssert.AreEqual(new List<string> { "wind", "cold", "chill", "snow", "square", "letter", "house", "circle",
                                                         "sun", "storm"}, foundWords);
        }

        [TestMethod]
        public void TestFindWordsNotPresent()
        {
            IEnumerable<string> matrix = ["abcd", "efgh", "ijkl", "mnop"];
            var wordFinder = new WordFinder(matrix);
            IEnumerable<string> wordStream = ["xyz", "uvw"];
            var foundWords = wordFinder.Find(wordStream).ToList();
            Assert.AreEqual(0, foundWords.Count);
        }

        [TestMethod]
        public void TestEmptyWordStream()
        {
            IEnumerable<string> matrix = ["abcd", "efgh", "ijkl", "mnop"];
            var wordFinder = new WordFinder(matrix);
            IEnumerable<string> wordStream = [];
            var foundWords = wordFinder.Find(wordStream).ToList();
            Assert.AreEqual(0, foundWords.Count);
        }

        [TestMethod]
        public void TestNullWordStream()
        {
            IEnumerable<string> matrix = ["abcd", "efgh", "ijkl", "mnop"];
            var wordFinder = new WordFinder(matrix);
            IEnumerable<string> wordStream = null;
            var foundWords = wordFinder.Find(wordStream).ToList();
            Assert.AreEqual(0, foundWords.Count);
        }
    }
}