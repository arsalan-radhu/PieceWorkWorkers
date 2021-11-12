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

        internal const decimal firstThresholdPaySenior = 0.018M;
        internal const decimal secondThresholdPaySenior = 0.021M;
        internal const decimal thirdThresholdPaySenior = 0.024M;
        internal const decimal fourthThresholdPaySenior = 0.027M;
        internal const decimal lastThresholdPaySenior = 0.03M;

        #endregion

        #region "Class Methods"

        protected override void FindPay()
        {

            if (employeeMessages < firstThreshold && employeeMessages > zero)
            {
                employeePay = (decimal)((employeeMessages * firstThresholdPaySenior)+FixedPay);
            }
            else if (employeeMessages < secondThreshold && employeeMessages >= firstThreshold)
            {
                employeePay = (decimal)((employeeMessages * secondThresholdPaySenior)+FixedPay);
            }
            else if (employeeMessages < thirdThreshold && employeeMessages >= secondThreshold)
            {
                employeePay = (decimal)((employeeMessages * thirdThresholdPaySenior)+FixedPay);
            }
            else if (employeeMessages < lastThreshold && employeeMessages >= thirdThreshold)
            {
                employeePay = (decimal)((employeeMessages * fourthThresholdPaySenior)+FixedPay);
            }
            else if (employeeMessages >= lastThreshold && employeeMessages <= maxMessages)
            {
                employeePay = (decimal)((employeeMessages * lastThresholdPaySenior)+FixedPay);
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

        #region Constructors

        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public SeniorWorker()
        {

        }


        /// <summary>
        /// PieceworkWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate.
        /// </summary>
        /// <param name="nameValue">the worker's name</param>
        /// <param name="lastNameValue">the worker's last name</param>
        /// <param name="messageValue">a worker's number of messages sent</param>
        public SeniorWorker(string nameValue, string lastNameValue, string messagesValue)
        {
            // Validate and set the worker's name
            this.Name = nameValue;
            // Validate and set the worker's last name
            this.LastName = lastNameValue;
            // Validate Validate and set the worker's number of messages
            this.Messages = messagesValue;
            // Calculcate the worker's pay and update all summary values
            FindPay();

        }

        #endregion

    }
}
