using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message) // burada base Result ı işaret eder oradaki verileri esas alır
        {

        }
        public ErrorResult() : base(false)

        {

        }
    }
}
