using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Database.Tables
{
    /// <summary>
    /// 
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Employee Identification key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public Guid EmployeeGuid { get; set; }

        /// <summary>
        /// Employee Payroll number(Номер платежной ведомости)
        /// </summary>
        [Display(Name = "Payroll number")]
        [MaxLength(15)]
        public String PayrollNumber { get; set; }

        /// <summary>
        /// Employee forenames(отчество)
        /// </summary>
        [Display(Name = "Forenames")]
        [MaxLength(20)]
        public String Forenames { get; set; }

        /// <summary>
        /// Employee Surname(Фамилия)
        /// </summary>
        [Display(Name = "Surname")]
        [MaxLength(20)]
        public String Surname { get; set; }

        /// <summary>
        /// Employee Date of birth (Дата рождения)
        /// </summary>
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "dd.mm.yyyy", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Employee Telephone number (телефон)
        /// </summary>
        [Display(Name = "Telephone number")]
        [MaxLength(15)]
        public String Telephone { get; set; }

        /// <summary>
        /// Employee mobile number (мобильный)
        /// </summary>
        [Display(Name = "Mobile number")]
        [MaxLength(15)]
        public String Mobile { get; set; }

        /// <summary>
        /// Employee address
        /// </summary>
        [Display(Name = "Address")]
        [MaxLength(150)]
        public String Address { get; set; }

        /// <summary>
        /// Employee address
        /// </summary>
        [Display(Name = "Address_2")]
        [MaxLength(150)]
        public String Address2 { get; set; }

        /// <summary>
        /// Employee postcode (почтовый индекс)
        /// </summary>
        [Display(Name = "Postcode")]
        [MaxLength(15)]
        public String PostCode { get; set; }

        /// <summary>
        /// Employee email address
        /// </summary>
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public String Email { get; set; }

        /// <summary>
        /// Employee start date
        /// </summary>
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "dd.mm.yyyy", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

    }
}