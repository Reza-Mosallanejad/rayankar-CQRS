using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Domain.DTOs
{
    public class OperationResult<ResultType>
    {
        private static string SuccessMsg = "Operation Succeed!";
        private static string FailMsg = "Operation Failed!";

        public bool Status { get; set; } = true;
        public string Message { get; set; } = SuccessMsg;
        public ResultType? Result { get; set; }

        public OperationResult()
        {
        }

        public void Succeed()
        {
            Status = true;
            Message = SuccessMsg;
        }

        public void Failed()
        {
            Status = false;
            Message = FailMsg;
        }

    }
}
