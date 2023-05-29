namespace QA.Contribution.Test.Journey.Validator
{
    public class ValidationRule
    {
        public string Name { get; set; }
        public bool HasValue { get; set; }
        public int? minLength { get; set; }
        public int? maxLength { get; set; }

        public ValidationRule() { }
    }
}