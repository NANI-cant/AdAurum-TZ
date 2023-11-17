using CodeBase.Quiz;

namespace CodeBase.Infrastructure {
    public interface IQuestionGenerator {
        Question[] Generate();
    }
}