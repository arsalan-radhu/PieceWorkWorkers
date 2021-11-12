// SeniorWorker.cs
//         Title: IncInc Payroll (Senior Piecework Worker)
// Last Modified: 11 November 2021
//    Written By: Arsalan Arif Radhu
// This is a class representing senior individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.


using System;

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

        /// <summary>
        /// Currently called in the constructor, the FindPay() method is
        /// used to calculate a senior worker's pay using threshold values to
        /// change how much a worker is paid per message. This also updates
        /// all summary values.
        /// </summary>
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

        /// <summary>
        /// Returns a string that represents the current Senior worker
        /// </summary>
        /// <returns>the object formatted as a descriptive string</returns>
        public override string ToString()
        {
            return Name + " " + LastName + " - " + Messages + " messages - " + Pay.ToString("C") + " - Senior Worker";
        }

        #endregion

        #region Constructors

        /// <summary>
        /// SeniorWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public SeniorWorker()
        {

        }


        /// <summary>
        /// SeniorWorker constructor: accepts a senior worker's first name, last name and number of
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
