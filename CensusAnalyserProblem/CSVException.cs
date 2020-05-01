///---------------------------------------------------------------------------
///   Class:--------> CSVException                                            
///   Description:--> Created seperate enum Exception Type as FILE_IS_EMPLTY                          -///
///   Author:-------> Nitikesh Shinde                     Date: 01/05/2020    
///---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
    public class CSVException:Exception
    {
        // exception variable declared
        ExceptionType exception;

        // enum declaration to give constant value
        public enum ExceptionType
        {
            FILE_IS_EMPTY
        }

        public CSVException(ExceptionType exception,string message):base(message)
        {
            this.exception = exception;
        }
    }
}
