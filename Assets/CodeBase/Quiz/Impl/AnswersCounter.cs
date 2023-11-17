namespace CodeBase.Quiz.Impl {
    public class AnswersCounter : IAnswersCounter {
        public uint CorrectCount { get; private set; }
        public uint NotCorrectCount { get; private set;}
        public uint TotalCount => CorrectCount + NotCorrectCount;

        public void AddCorrect() => CorrectCount++;
        public void AddNotCorrect() => NotCorrectCount++;
    }
}