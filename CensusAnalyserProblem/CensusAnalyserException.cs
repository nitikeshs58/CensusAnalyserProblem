﻿///-----------------------------------------------------------------------------
///   Class:--------> CensusAnalyserException                                    
///   Description:--> Declared enum Exception types                              
///   Author:-------> Nitikesh Shinde                     Date: 01/05/2020       
///-----------------------------------------------------------------------------

using System;

namespace CensusAnalyserProblem
{

    public class CensusAnalyserException:Exception
    {
        // ExceptionType variable declared
        ExceptionType exception;

        // enum declaration to give constant values
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INVALID_EXTENSION_OF_FILE,
            INCORRECT_DELIMETER,
            INVALID_HEADER_ERROR
        }

        public CensusAnalyserException(ExceptionType exception, string exceptionMessage) : base(exceptionMessage)
        {
            this.exception = exception;
        }
    }// End of public class CensusAnalyserException:Exception
}
