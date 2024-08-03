namespace WordFinderChallenge
{
    public class WordFinder
    {
        private readonly char[,] _characterMatrix;
        private readonly int _rows = 0;
        private readonly int _columns = 0;
        private readonly Dictionary<string, int> _foundWords = [];

        /// <summary>
        /// Receives a set of strings and creates a character matrix. Also prints the matrix in the Console
        /// </summary>
        /// <param name="matrix">set of strings</param>
        public WordFinder(IEnumerable<string> matrix)
        {
            if (IsMatrixValid(matrix))
            {
                _rows = matrix.Count();
                _columns = matrix.First().Length;
                _characterMatrix = new char[_rows, _columns];
                PopulateMatrix(matrix);
                PrintMatrix();
            }
            else
            {
                throw new ArgumentException("Matrix can not be null, its size can not exceed 64x64 and all strings have to contain the same number of characters.");
            }
        }

        /// <summary>
        /// Returns the top 10 most repeated words from the word stream found in the matrix. 
        /// If no words are found, returns an empty set of strings. 
        /// If any word in the word stream is found more than once within the stream, it should be counted only once
        /// </summary>
        /// <param name="wordStream">set of strings to be found</param>
        /// <returns>an IEnumerable<string> containing the top 10 most repeated words from the word stream found in the matrix</returns>
        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            if (wordStream == null || !wordStream.Any())
            {
                return [];
            }

            // the dictionary foundWords is to search the words from the word stream (without repetitions)
            // and count how many each word is found in the Matrix
            foreach (string word in wordStream.Distinct().Select(w => w.ToLower()))
            {
                _foundWords.Add(word, 0);
            }

            // Iteration in the matrix from left to right and from top to bottom, checking if each word is found horizontally or vertically
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {

                    foreach (string word in _foundWords.Keys)
                    {
                        CheckHorizontally(row, col, word);
                        CheckVertically(row, col, word);
                    }
                }
            }

            // Returning the top 10 most repeated words found in the matrix
            return _foundWords.Where(kv => kv.Value > 0)
                              .OrderByDescending(kv => kv.Value)
                              .Take(10)
                              .Select(kv => kv.Key);
        }

        /// <summary>
        /// Checks if the given word exists horizontally starting from the point (row, col) in the matrix 
        /// </summary>
        /// <param name="row">row number</param>
        /// <param name="col">col number</param>
        /// <param name="word">word to search</param>
        private void CheckHorizontally(int row, int col, string word)
        {
            // Checking whether it makes sense to search for the word, considering its length and the available space in the matrix,
            // starting from the point (row, col)
            if (string.IsNullOrEmpty(word) || word.Length > _columns || word.Length > _columns - col)
            {
                return;
            }

            // Horizontally iterate through the matrix while ensuring that each character in the matrix
            // matches with the corresponding character of the word
            var wordIndex = 0;
            for (int currentCol = col; currentCol < word.Length + col; currentCol++)
            {
                if (_characterMatrix[row, currentCol] != word[wordIndex])
                {
                    return;
                }
                wordIndex++;
            }

            // At this point the word was found so the word counter is incremented
            _foundWords[word]++;
        }

        /// <summary>
        /// Checks if the given word exists vertically starting from the point (row, col) in the matrix 
        /// </summary>
        /// <param name="row">row number</param>
        /// <param name="col">col number</param>
        /// <param name="word">word to search</param>
        private void CheckVertically(int row, int col, string word)
        {
            // Checking whether it makes sense to search for the word, considering its length and the available space in the matrix,
            // starting from the point (row, col)
            if (string.IsNullOrEmpty(word) || word.Length > _rows || word.Length > _rows - row)
            {
                return;
            }

            // Vertically iterate through the matrix while ensuring that each character in the matrix
            // matches with the corresponding character of the word
            var wordIndex = 0;
            for (int currentRow = row; currentRow < word.Length + row; currentRow++)
            {
                if (_characterMatrix[currentRow, col] != word[wordIndex])
                {
                    return;
                }
                wordIndex++;
            }

            // At this point the word was found so the word counter is incremented
            _foundWords[word]++;
        }

        /// <summary>
        /// Populates the global char[,] characterMatrix with the IEnumerable<string> received
        /// </summary>
        /// <param name="matrix">IEnumerable<string> with the matrix words</param>
        private void PopulateMatrix(IEnumerable<string> matrix)
        {
            int row = 0;
            foreach (string word in matrix.Select(w => w.ToLower()))
            {
                for (int col = 0; col < _columns; col++)
                {
                    _characterMatrix[row, col] = word[col];
                }
                row++;
            }
        }

        /// <summary>
        /// Prints the matrix in the Console
        /// </summary>
        private void PrintMatrix()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {
                    Console.Write(_characterMatrix[row, col]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Checks if the matrix is valid, it means, if the matrix is not null, if it has words,
        /// if all its words has the same Length and if its size does not exceed 64x64
        /// </summary>
        /// <param name="matrix">IEnumerable<string> with the matrix words</param>
        /// <returns>true if the matrix is valid, false otherwise</returns>
        private static bool IsMatrixValid(IEnumerable<string> matrix)
        {
            if (matrix != null && matrix.Any() && matrix.Count() <= 64 && matrix.All(s => s.Length == matrix.First().Length && s.Length <= 64))
            {
                return true;
            }
            return false;
        }
    }
}
