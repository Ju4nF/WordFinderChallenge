using WordFinderChallenge;

namespace WordFinderTests
{
    [TestClass]
    public class WordFinderTests
    {
        [TestMethod]
        [Description("Verifies the matrix is valid. It means, it's not null, all its words have the same Length and " +
                     "if its size does not exceed 64x64")]
        public void TestInitializationWithValidMatrix()
        {
            IEnumerable<string> matrix = ["abcdc", "fgwio", "chill", "pqnsd", "uvdxy"];
            WordFinder wordFinder = new(matrix);
            Assert.IsNotNull(wordFinder);
        }

        [TestMethod]
        [Description("Verifies the matrix is invalid since not all its words have the same Lenght")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrixWordsDifferentLength()
        {
            IEnumerable<string> matrix = ["abcdc", "fgwio", "chill", "pqnsd", "uvd"];
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        [Description("Verifies the matrix is invalid since it's empty")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrixEmpty()
        {
            IEnumerable<string> matrix = [];
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        [Description("Verifies the matrix is invalid since it's null")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrixNull()
        {
            IEnumerable<string> matrix = null;
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        [Description("Verifies the matrix is invalid since it has more than 64 columns")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrixMore64Columns()
        {
            IEnumerable<string> matrix = ["abcdcertyujighfjdnsowrithskftokeortgdwoktifrjethsjerigrolawpmjerg"];
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        [Description("Verifies the matrix is invalid since it has more than 64 rows")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializationWithInvalidMatrixMore64Rows()
        {
            IEnumerable<string> matrix = ["a","b","c","d","c","e","r","t","y","u","j","i","g","h","f","j","d","n","s","o","w","r",
                                          "i","t","h","s","k","f","t","o","k","e","o","r","t","g","d","w","o","k","t","i","f","r",
                                          "j","e","t","h","s","j","e","r","i","g","r","o","l","a","w","p","m","j","e","r","g"];
            _ = new WordFinder(matrix);
        }

        [TestMethod]
        [Description("Verifies that 3 words are found in a matrix of 7x5")]
        public void TestFindWordsInMatrix7x5()
        {
            IEnumerable<string> matrix = ["abcdc", "fgwio", "chill", "pqnsd", "uvdxy", "lkioe", "qwert"];
            var wordFinder = new WordFinder(matrix);
            IEnumerable<string> wordStream = ["cold", "wind", "snow", "chill"];
            var foundWords = wordFinder.Find(wordStream).ToList();
            CollectionAssert.AreEqual(new List<string> { "cold", "wind", "chill"}, foundWords);
        }

        [TestMethod]
        [Description("Verifies that the 10 most repeated words in the matrix are found in a matrix of 40x40. Words present in the Matrix: " +
                     "wind(5), cold(4), chill(4), snow(3), square(3), letter(3), house(2), circle(2), sun(2), storm(2), car(1), " +
                     "bike(1), dog(1), cat(1), smile(1), wonderful(1), happy(1), amazing(1)")]

        public void TestFindWordsInMatrix40x40()
        {
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
        [Description("Verifies that a repeated word in the word stream is only once in the result in a matrix of 7x5")]
        public void TestFindRepeatedWordsInMatrix7x5()
        {
            IEnumerable<string> matrix = ["abcdc", "fgwio", "chill", "pqnsd", "uvdxy", "lkioe", "qwert"];
            var wordFinder = new WordFinder(matrix);
            IEnumerable<string> wordStream = ["cold", "cold", "COLD", "cOLd"];
            var foundWords = wordFinder.Find(wordStream).ToList();
            CollectionAssert.AreEqual(new List<string> { "cold" }, foundWords);
        }

        [TestMethod]
        [Description("Verifies that the words in the word stream are not found in a matrix of 4x4")]
        public void TestFindWordsNotPresent()
        {
            IEnumerable<string> matrix = ["abcd", "efgh", "ijkl", "mnop"];
            var wordFinder = new WordFinder(matrix);
            IEnumerable<string> wordStream = ["xyz", "uvw"];
            var foundWords = wordFinder.Find(wordStream).ToList();
            Assert.AreEqual(0, foundWords.Count);
        }

        [TestMethod]
        [Description("Verifies that, for an empty word stream, not words are found in a matrix of 4x4")]
        public void TestEmptyWordStream()
        {
            IEnumerable<string> matrix = ["abcd", "efgh", "ijkl", "mnop"];
            var wordFinder = new WordFinder(matrix);
            IEnumerable<string> wordStream = [];
            var foundWords = wordFinder.Find(wordStream).ToList();
            Assert.AreEqual(0, foundWords.Count);
        }

        [TestMethod]
        [Description("Verifies that, for a null word stream, not words are found in a matrix of 4x4")]
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