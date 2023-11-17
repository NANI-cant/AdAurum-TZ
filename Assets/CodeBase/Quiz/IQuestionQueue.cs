namespace CodeBase.Quiz {
    public interface IQuestionQueue {
        int Remaining { get; }
        int Count { get; }

        void Setup(Question[] allQuestions);
        void Restore();
        bool Next(out Question question);
    }
}