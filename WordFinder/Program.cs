// Presented with a character matrix and a large stream of words, your task is to create a Class
// that searches the matrix to look for the words from the word stream. Words may appear
// horizontally, from left to right, or vertically, from top to bottom. In the example below, the word
// stream has four words and the matrix contains only three of those words ("chill", "cold" and
// "wind"):

//  cold            a   b   c   d   c
//  wind            f   g   w   i   o
//  snow            c   h   i   l   l
//  chill           p   q   n   s   d
//                  u   v   d   x   y
//

// The search code must be implemented as a class with the following interface:
// public class WordFinder
// {
//      public WordFinder(IEnumerable<string> matrix)
//      {
//        ...
//      }
//      public IEnumerable<string> Find(IEnumerable<string> wordstream)
//      {
//        ...
//      }
// }

// The WordFinder constructor receives a set of strings which represents a character matrix. The
// matrix size does not exceed 64x64, all strings contain the same number of characters. The
// "Find" method should return the top 10 most repeated words from the word stream found in the
// matrix. If no words are found, the "Find" method should return an empty set of strings. If any
// word in the word stream is found more than once within the stream, the search results
// should count it only once
// Due to the size of the word stream, the code should be implemented in a high performance
// fashion both in terms of efficient algorithm and utilization of system resources. Where possible,
// please include your analysis and evaluation.

using WordFinderChallenge;

WordFinder wf = new(["fcokuoxnbzqktvrhrusajljwmjllqujmltvbilgl","omzawstqqnxpbbehxuwcprlkqeagtjaykogavnjs",
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
                     "sverqbpiobjqsjpnwvblegeytfpqsosquarezkbg","ibuimtzszyjgzlwnivwlgwyproauuqudfeffdoph"]);

var result = wf.Find(["cold", "wind", "snow", "chill", "house", "square", "circle", "letter", "sun", "storm",
                      "car", "bike", "dog", "cat", "smile", "wonderful", "happy", "amazing", "great", "pencil"]);

if (result.Any())
{
    Console.WriteLine("The top 10 most repeated words are:");
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
}
else
{
    Console.WriteLine("No results");
}