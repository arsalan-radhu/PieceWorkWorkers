// SeniorWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: 11 November 2021
//    Written By: Arsalan Arif Radhu
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a class representing individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieceWorkWorkers.Classes
{
    public class SeniorWorker : PieceworkWorker
    {
        #region "Variable Declarations"
        
        //Constants
        internal const decimal FixedPay = 270;

        #endregion

        #region "Class Methods"

        protected override void FindPay()
        {

            if (employeeMessages < firstThreshold && employeeMessages > zero)
            {
                employeePay = (decimal)((employeeMessages * firstThresholdPay)+FixedPay);
            }
            else if (employeeMessages < secondThreshold && employeeMessages >= firstThreshold)
            {
                employeePay = (decimal)((employeeMessages * secondThresholdPay)+FixedPay);
            }
            else if (employeeMessages < thirdThreshold && employeeMessages >= secondThreshold)
            {
                employeePay = (decimal)((employeeMessages * thirdThresholdPay)+FixedPay);
            }
            else if (employeeMessages < lastThreshold && employeeMessages >= thirdThreshold)
            {
                employeePay = (decimal)((employeeMessages * fourthThresholdPay)+FixedPay);
            }
            else if (employeeMessages >= lastThreshold && employeeMessages <= maxMessages)
            {
                employeePay = (decimal)((employeeMessages * lastThresholdPay)+FixedPay);
            }
            else
            {
                throw new ArgumentOutOfRangeException(MessagesParameters,
                    "Enter less than 15000!");
            }

            // Update all summary variables
            overallNumberOfEmployees++;
            overallMessages += employeeMessages;
            overallPayroll += employeePay;


        }

        #endregion
    }
}
