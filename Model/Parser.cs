using System.Text.RegularExpressions;

namespace AIAssistant.Model
{
    public class ShortQA
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
    public class QA
    {
        public string Question { get; set; }
        public string[] Answers { get; set; }
        public string CorrectAnswer { get; set; }
    }
    public static class Parser
    {
        public static string[] ParseFreeAnswer(string text)
        {
            try
            {
                return text.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return default;
        }

        public static ShortQA[] ParseShortQa(string text)
        {
            var shortQas = new List<ShortQA>();
            try
            {
                var lines = text.Split("\n", StringSplitOptions.RemoveEmptyEntries);
              
                for (int i = 0; i < lines.Length - 1; i = i + 2)
                {
                    shortQas.Add(new ShortQA()
                    {
                        Question = lines[i],
                        Answer = lines[i + 1]
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return shortQas.ToArray();
        }
        public static QA[] ParseMultiChoice(string text)
        {
            var qas = new List<QA>();
            try
            {

                var questionSeparated = text.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
                foreach (var questionWithAnswers in questionSeparated)
                {
                    var lines = questionWithAnswers.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                    qas.Add(new QA()
                    {
                        Question = lines[0],
                        Answers = new[] { lines[1], lines[2], lines[3] },
                        CorrectAnswer = lines[4]
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return qas.ToArray();
        }
    }
}
