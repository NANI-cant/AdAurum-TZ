using System.Collections.Generic;
using CodeBase.Extensions;

namespace CodeBase.Quiz.Impl {
    public class QuestionQueue : IQuestionQueue {
        private Question[] _allQuestions;
        private Queue<Question> _remainingQuestions;

        public int Remaining => _remainingQuestions.Count;
        public int Count => _allQuestions.Length;

        public void Setup(Question[] allQuestions) {
            _allQuestions = allQuestions;
            Restore();
        }

        public void Restore() {
            List<Question> shuffledQuestions = new List<Question>(_allQuestions);
            shuffledQuestions.Shuffle();
            _remainingQuestions = new Queue<Question>(shuffledQuestions);
        }

        public bool Next(out Question question) => _remainingQuestions.TryDequeue(out question);
    }
}