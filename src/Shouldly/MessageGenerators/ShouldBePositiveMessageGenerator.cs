using System.Text.RegularExpressions;

namespace Shouldly.MessageGenerators
{
    internal class ShouldBePositiveMessageGenerator : ShouldlyMessageGenerator
    {
        static readonly Regex Validator = new Regex("ShouldBePositive");

        public override bool CanProcess(IShouldlyAssertionContext context)
        {
            return Validator.IsMatch(context.ShouldMethod);
        }

        public override string GenerateErrorMessage(IShouldlyAssertionContext context)
        {
            var codePart = context.CodePart;
            var actual = context.Actual.ToStringAwesomely();
            var actualValue = codePart != actual ? $@"
{actual}
    " : " ";

            return
$@"{codePart}
    {context.ShouldMethod.PascalToSpaced()} but{actualValue}is negative";
        }
    }
}