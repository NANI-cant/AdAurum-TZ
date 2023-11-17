using System.Collections.Generic;
using CodeBase.Quiz;
using LitJson;
using UnityEngine;

namespace CodeBase.Infrastructure.Impl {
    public class JsonQuestionGenerator : IQuestionGenerator {
        private readonly TextAsset _jsonFile;

        public JsonQuestionGenerator(TextAsset jsonFile) {
            _jsonFile = jsonFile;
        }
        
        public Question[] Generate() {
            JsonData questionsData = JsonMapper.ToObject(_jsonFile.text);

            List<Question> questions = new List<Question>();

            foreach (JsonData jsonQuestion in questionsData) {
                var answers = new List<Answer>();
                foreach (JsonData jsonAnswer in jsonQuestion["answers"]) {
                    answers.Add(new Answer(
                        (string)jsonAnswer["text"], 
                        (bool)jsonAnswer["correct"]
                    ));
                }
                
                questions.Add(new Question(
                    (string)jsonQuestion["question"], 
                    answers.ToArray(),
                    Resources.Load<Sprite>((string)jsonQuestion["background"])
                ));
            }
            
            return questions.ToArray();
        }
    }
}