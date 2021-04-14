using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATApplication.DATA.EF//.Metadata
{
    public class StudentMetadata
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage = "* First Name is required.")]
        [StringLength(20, ErrorMessage = "* Must not exceed 20 characters")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "* Last Name is required.")]
        [StringLength(20, ErrorMessage = "* Must not exceed 20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [StringLength(15, ErrorMessage = "* Must not exceed 15 characters")]
        public string Major { get; set; }
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        public string Address { get; set; }
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [StringLength(25, ErrorMessage = "* Must not exceed 25 characters")]
        public string City { get; set; }
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [StringLength(2, ErrorMessage ="* Must not exceed 2 characters (eg. \"MO\"")]
        [Display(Name ="State Code")]
        public string State { get; set; }
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [StringLength(10, ErrorMessage = "* Must not exceed 10 characters")]
        [Display(Name ="Zip Code")]
        public string ZipCode { get; set; }
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [StringLength(13, ErrorMessage = "* Must not exceed 13 characters")]
        [Display(Name ="Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "* Email Address is required.")]
        [StringLength(60, ErrorMessage = "* Must not exceed 60 characters")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [StringLength(100, ErrorMessage = "* Must not exceed 100 characters")]
        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }
        [Required(ErrorMessage ="* Student Status is required")]
        [Display(Name ="Student Status")]
        public int SSID { get; set; }
    }
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    public class CourseMetadata
    {
        public int CourseID { get; set; }
        [Required(ErrorMessage ="* Course Name is required")]
        [StringLength(50, ErrorMessage ="* Must not exceed 50 chracters")]
        [Display(Name ="Course Name")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "* Course Description is required")]
        [Display(Name = "Course Description")]
        [UIHint("MultilineText")]
        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "* Credit Hours are required")]
        [Display(Name = "Credit Hours")]
        public byte CreditHours { get; set; }
        [StringLength(250, ErrorMessage = "* Must not exceed 250 chracters")]
        [DisplayFormat(NullDisplayText ="[N/A]")]
        [UIHint("MultilineText")]
        public string Curriculum { get; set; }
        [StringLength(500, ErrorMessage = "* Must not exceed 500 chracters")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [UIHint("MultilineText")]
        public string Notes { get; set; }
        //bools can't have metadata aside from displays
        [Display(Name ="Active?")]
        public bool IsActive { get; set; }
    }
    [MetadataType(typeof(CourseMetadata))]
    public partial class Course
    {

    }

    public class ScheduledClassMetadata
    {
        public int ScheduledClassID { get; set; }
        [Required(ErrorMessage = "* Course is required")]
        [Display(Name = "Course")]
        public int CourseID { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage ="* Start date is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "* End date is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime EndDate { get; set; }
        [Display(Name = "Instructor")]
        [Required(ErrorMessage ="* Instructor Name is required")]
        [StringLength(40, ErrorMessage = "* Must not exceed 40 chracters")]
        public string InstructorName { get; set; }
        [Required(ErrorMessage ="* Location is required")]
        [StringLength(20, ErrorMessage = "* Must not exceed 20 chracters")]
        public string Location { get; set; }
        [Display(Name = "Class Status")]
        [Required(ErrorMessage ="* Status is required")]
        public int SCSID { get; set; }
    }
    [MetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass
    {

    }

    public class EnrollmentMetadata
    {
        public int EnrollmentID { get; set; }
        [Required(ErrorMessage ="* Student ID is required")]
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }
        [Display(Name = "Scheduled Class")]
        public int ScheduledClassID { get; set; }
        [Required(ErrorMessage ="* Emrollment Date is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime EnrollmentDate { get; set; }
    }
    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment
    {

    }

    public class ScheduledClassStatusMetadata
    {
        public int SCSID { get; set; }
        [Display(Name = "Class Status Name")]
        [StringLength(50, ErrorMessage = "* Must not exceed 50 chracters")]
        [Required(ErrorMessage ="* Class Status Name is required")]
        public string SCSName { get; set; }
    }
    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus
    {

    }

    public class StudentStatusMetadata
    {
        public int SSID { get; set; }
        [StringLength(30, ErrorMessage = "* Must not exceed 30 chracters")]
        [Required(ErrorMessage ="* Student Status Name is required")]
        public string SSName { get; set; }
        [StringLength(250, ErrorMessage = "* Must not exceed 250 chracters")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        [UIHint("MultilineText")]
        public string SSDescription { get; set; }
    }
    [MetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus
    {

    }

}
