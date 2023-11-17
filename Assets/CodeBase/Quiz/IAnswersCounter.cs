namespace CodeBase.Quiz {
    public interface IAnswersCounter {
        uint CorrectCount { get; }
        uint NotCorrectCount { get; }
        uint TotalCount { get; }
        
        void AddCorrect();
        void AddNotCorrect();
    }
}