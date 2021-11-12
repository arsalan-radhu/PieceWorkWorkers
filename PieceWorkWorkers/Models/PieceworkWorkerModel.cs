// PieceworkWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: 11 November 2021
//    Written By: Arsalan Arif Radhu
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a model for the data required by the pages.
// It effectively holds and validates all the user input so that a
// worker object can be created by the controller.

using System;
using System.Collections.Generic;
// PieceworkWorkerModel.cs
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


using PieceWorkWorkers.Classes;
using System.ComponentModel.DataAnnotations;


namespace PieceWorkWorkers.Models
{
    public class PieceworkWorkerModel
    {
        /// <summary>
        /// The worker's first name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a first name.")]
        [Display(Name = "First Name: ")]
        public string Name { get; set; }

        /// <summary>
        /// The worker's last name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a last name.")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        /// <summary>
        /// The worker's messages
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter number of messages sent.")]
        [Range(PieceworkWorker.zero+1, PieceworkWorker.maxMessages, ErrorMessage = "The number of messages should be between 0 and 15,000")]
        [Display(Name = "Messages: ")]
        public int Messages { get; set; }

        /// <summary>
        /// The workers total messages
        /// </summary>
        public static int TotalMessages { get; set;}
        
        /// <summary>
        /// The worker's Pay
        /// </summary>
        public static decimal Pay { get; set;}

        /// <summary>
        /// The workers Total Pay
        /// </summary>
        public static decimal TotalPay { get; set;}

        /// <summary>
        /// The total number of workers 
        /// </summary>
        public static decimal TotalWorkers { get; set; }

        /// <summary>
        /// The average pay of workers 
        /// </summary>
        public static decimal AveragePay { get; set; }

        /// <summary>
        /// Indicates whether the worker is Senior or not
        /// </summary>
        public bool IsSenior { get; set; }
        
        /// <summary>
        /// Outputs the formatted string.
        /// </summary>
        public static string ToString { get; set; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="nameValue"></param>
        /// <param name="lastNameValue"></param>
        /// <param name="messagesValue"></param>
        public PieceworkWorkerModel(string nameValue, string lastNameValue, string messagesValue)
        {

        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PieceworkWorkerModel()
        {

        }
    }
}
