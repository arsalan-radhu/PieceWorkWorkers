// Worker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: 10 November 2021
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PieceWorkWorkers.Classes
{
    public abstract class Worker
    {
        #region "Variable declarations"

        // Instance variables
        protected string employeeName;
        protected string employeeLastName;
        protected decimal employeePay;

        //Constants
        private const int zero = 0;
        
        // Shared class variables
        protected static int overallNumberOfEmployees;
        protected static decimal overallPayroll;

        // Constants for exception parameter name
        public const string NameParameters = "name";
        public const string LastNameParameters = "lastname";
        


        #endregion

        #region "Constructors"

        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public Worker()
        {

        }

        #endregion

        #region "Class Methods"

        /// <summary>
        /// All worker objects have a method of determining their pay
        /// </summary>
        protected abstract void FindPay();

        /// <summary>
        /// Returns a string that represents the current worker
        /// </summary>
        /// <returns>the object formatted as a descriptive string</returns>
        public override string ToString()
        {
            return Name + LastName + " - " + Pay.ToString("C");
        }

        #endregion
        #region "Property Procedures"

        /// <summary>
        /// Gets and sets a worker's name
        /// </summary>
        /// <returns>an employee's name</returns>
        protected internal string Name
        {
            get
            {
                return employeeName.ToString();
            }
            set
            {
                // Add validation for the worker's name based on the requirement.
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameParameters, "Name cannot be blank.");
                }
                else
                {
                    employeeName = value;
                }

            }
        }

        /// <summary>
        /// Gets and sets a worker's last name
        /// </summary>
        protected internal string LastName
        {
            get
            {
                return employeeLastName.ToString();
            }
            set
            {
                // Add validation for the worker's last name based on the requirement.
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(LastNameParameters, "Last name cannot be blank.");
                }
                else
                {
                    employeeLastName = value;
                }

            }
        }

        /// <summary>
        /// Gets the worker's pay
        /// </summary>
        /// <returns>a worker's pay</returns>
        protected internal decimal Pay
        {
            get
            {
                return employeePay;
            }
        }

        /// <summary>
        /// Gets the overall total pay among all workers
        /// </summary>
        /// <returns>the overall total pay among all workers</returns>
        protected internal static decimal TotalPay
        {
            get
            {
                return overallPayroll;
            }
        }

        /// <summary>
        /// Gets the overall number of workers
        /// </summary>
        /// <returns>the overall number of workers</returns>
        protected internal static int TotalWorkers
        {
            get
            {
                return overallNumberOfEmployees;
            }
        }


        /// <summary>
        /// Calculates and returns an average pay among all workers
        /// </summary>
        /// <returns>the average pay among all workers</returns>
        protected internal static decimal AveragePay
        {
            get
            {

                if (TotalWorkers == 0 || TotalPay == 0)
                {
                    return zero;
                }
                else
                {
                    return Decimal.Round(TotalPay / TotalWorkers, 2);
                }

            }
        }

        #endregion
    }

}
