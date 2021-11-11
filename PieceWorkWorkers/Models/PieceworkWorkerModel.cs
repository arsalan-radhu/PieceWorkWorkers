// PieceworkWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: 10 November 2021
//    Written By: Arsalan Arif Radhu
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a model for the data required by the pages.
// It effectively holds and validates all the user input so that a
// worker object can be created by the controller.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PieceWorkWorkers.Classes;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic.CompilerServices;

namespace PieceWorkWorkers.Models
{
    public class PieceworkWorkerModel
    {
        /// <summary>
        /// The worker's first name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The worker must have a first name.")]
        public string Name { get; set; }

        /// <summary>
        /// The worker's messages
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter number of messages sent.")]
        [Range((int)PieceworkWorker.zero, (int)PieceworkWorker.maxMessages, ErrorMessage = "The number of messages should be between 0 and 15,000")]
        public int Messages { get; set; }

        /// <summary>
        /// The workers total messages
        /// </summary>
        public int TotalMessages { get; set;}
        
        /// <summary>
        /// The worker's Pay
        /// </summary>
        public decimal Pay { get; set;}

        /// <summary>
        /// The workers Total Pay
        /// </summary>
        public decimal TotalPay { get; set;}

        public PieceworkWorkerModel(string nameValue, string lastName, string messages)
        {

        }
    }
}
