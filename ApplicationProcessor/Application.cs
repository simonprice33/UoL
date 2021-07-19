using System;
using System.Globalization;
using System.Text;
using Ulaw.ApplicationProcessor.Enums;
using Ulaw.ApplicationProcessor.Extensions;
using ULaw.ApplicationProcessor.Enums;

namespace ULaw.ApplicationProcessor
{
    public class Application
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Application"/>
        /// </summary>
        /// <param name="faculty"></param>
        /// <param name="courseCode"></param>
        /// <param name="startDate"></param>
        /// <param name="title"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="requiresVisa"></param>
        public Application(string faculty, string courseCode, DateTime startDate, string title, string firstName, string lastName, DateTime dateOfBirth, bool requiresVisa)
        {
            Id = new Guid();
            Faculty = faculty;
            CourseCode = courseCode;
            StartDate = startDate;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            RequiresVisa = requiresVisa;
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// Gets the Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the Faculty
        /// </summary>
        public string Faculty { get; private set; }

        /// <summary>
        /// Gets the Course Code
        /// </summary>
        public string CourseCode { get; private set; }

        /// <summary>
        /// Gets the start date
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Gets the Title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the First Name
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the Last Name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the Date of Birth
        /// </summary>
        public DateTime DateOfBirth { get; private set; }

        /// <summary>
        /// Gets the Required Visa Flag
        /// </summary>
        public bool RequiresVisa { get; private set; }

        /// <summary>
        /// Gets or Sets Degree Grade
        /// </summary>
        public DegreeGrade DegreeGrade { get; set; }

        /// <summary>
        /// Gets or Sets Degree Subject
        /// </summary>
        public DegreeSubject DegreeSubject { get; set; }

        /// <summary>
        /// Processes a Application
        /// </summary>
        /// <returns>String of HTML Response</returns>
        public string Process()
        {
            var result = new StringBuilder();
            result.Append("<html><body><h1>Your Recent Application from the University of Law</h1>");

            switch (DegreeGrade)
            {
                case DegreeGrade.TwoTwo:
                    ApplicationTwoTwoResponse(result);
                    break;
                case DegreeGrade.Third:
                    ApplicationThirdResponse(result);
                    break;
                default:
                {
                   
                    switch (DegreeSubject)
                    {
                        case DegreeSubject.Law:
                        case DegreeSubject.LawAndBusiness:
                            ApplicationLawAndBusinessResponse(result);
                            break;
                        default:
                            ApplicationDefaultDegreeSubjectResponse(result);
                            break;
                    }

                    break;
                }
            }

            result.Append("</body></html>");

            return result.ToString();
        }

        private void ApplicationTwoTwoResponse(StringBuilder result)
        {
            result.Append($"<p> Dear {FirstName}, </p>");
            result.Append($"<p/> Further to your recent application for our course reference: {CourseCode} starting on {StartDate.ToLongDateString()}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.");
            result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
        }

        private void ApplicationThirdResponse(StringBuilder result)
        {
            result.Append($"<p> Dear {FirstName}, </p>");
            result.Append("<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.");
            result.Append("<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            result.Append("<br> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
        }

        private void ApplicationLawAndBusinessResponse(StringBuilder result)
        {
            var depositAmount = 350.00M;

            result.Append($"<p> Dear {FirstName}, </p>");
            result.Append($"<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {CourseCode} starting on {StartDate.ToLongDateString()}.");
            result.Append($"<br/> This offer will be subject to evidence of your qualifying {DegreeSubject.ToDescription()} degree at grade: {DegreeGrade.ToDescription()}.");
            result.Append($"<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{depositAmount.ToString(CultureInfo.InvariantCulture)} deposit fee to secure your place.");
            result.Append("<br/> We look forward to welcoming you to the University,");
            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
        }

        private void ApplicationDefaultDegreeSubjectResponse(StringBuilder result)
        {
            result.Append($"<p> Dear {FirstName}, </p>");
            result.Append($"<p/> Further to your recent application for our course reference: {CourseCode} starting on {this.StartDate.ToLongDateString()}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.");
            result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
        }
    }
}

